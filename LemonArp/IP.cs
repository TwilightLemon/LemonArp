using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LemonArp
{
    class IP
    {
        public byte[] IPBytes { get; private set; }

        public IPAddress IPAddress
        {
            get
            {
                return new IPAddress(IPBytes);
            }
        }

        public IP(IPAddress ip)
        {
            IPBytes = ip.GetAddressBytes();
        }

        public void AddOne()
        {
            int i = 3;
            while (i >= 0)
            {
                if (IPBytes[i] == 255)
                {
                    IPBytes[i] = 0;
                    i--;
                }
                else
                {
                    IPBytes[i]++;
                    break;
                }
            }
        }

        public override bool Equals(object obj)
        {
            var ip = obj as IP;
            for (int i = 0; i < IPBytes.Length; ++i)
            {
                if (ip.IPBytes[i] != IPBytes[i])
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool SmallerThan(IP ip)
        {
            for (int i = 0; i < IPBytes.Length; ++i)
            {
                if (IPBytes[i] < ip.IPBytes[i])
                    return true;
            }
            return false;
        }
    }
}
