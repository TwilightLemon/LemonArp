using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace LemonArp
{
    class ResolvedEventArgs:EventArgs
    {
        public IPAddress IPAddress { get; set; }

        public PhysicalAddress PhysicalAddress { get; set; }
    }
}
