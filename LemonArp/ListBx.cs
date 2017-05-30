using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LemonArp
{
    class TransparentListBox : ListBox
    {
        public TransparentListBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Focused && this.SelectedItem != null)
            {
                Rectangle itemRect = this.GetItemRectangle(this.SelectedIndex);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100,0,122,204)), itemRect);
            }
            for (int i = 0; i < Items.Count; i++)
            {
                e.Graphics.DrawString(this.GetItemText(this.Items[i]), this.Font,
                new SolidBrush(this.ForeColor), this.GetItemRectangle(i));
            }
            base.OnPaint(e);
        }

    }
    class CustomeComboBox : ComboBox
    {
        //导入API函数  
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);//返回hWnd参数所指定的窗口的设备环境。  

        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC); //函数释放设备上下文环境（DC）  

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //WM_PAINT = 0xf; 要求一个窗口重画自己,即Paint事件时  
            //WM_CTLCOLOREDIT = 0x133;当一个编辑型控件将要被绘制时发送此消息给它的父窗口；  
            //通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色  
            //windows消息值表,可参考:http://hi.baidu.com/dooy/blog/item/0e770a24f70e3b2cd407421b.html  
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0) //如果取设备上下文失败则返回  
                {
                    return;
                }

                //建立Graphics对像  
                Graphics g = Graphics.FromHdc(hDC);
                ControlPaint.DrawBorder(g, new Rectangle(0, 0, Width - 17, Height), Color.FromArgb(0, 122, 204), ButtonBorderStyle.Solid);
                ReleaseDC(m.HWnd, hDC);
            }
        }
    }
}
