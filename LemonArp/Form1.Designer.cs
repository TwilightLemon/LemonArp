using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LemonArp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void SetWindowRegion()
        {
            GraphicsPath FormPath;

            FormPath = new System.Drawing.Drawing2D.GraphicsPath();

            Rectangle rect = new Rectangle(-1, -1, this.Width + 1, this.Height);

            FormPath = GetRoundedRectPath(rect, 10);

            this.Region = new Region(FormPath);
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;

            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            GraphicsPath path = new GraphicsPath();

            //   左上角   
            path.AddArc(arcRect, 185, 90);

            //   右上角   
            arcRect.X = rect.Right - diameter;

            path.AddArc(arcRect, 275, 90);

            //   右下角   
            arcRect.Y = rect.Bottom - diameter;

            path.AddArc(arcRect, 356, 90);

            //   左下角   
            arcRect.X = rect.Left;

            arcRect.Width += 2;

            arcRect.Height += 2;

            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();

            return path;
        }

        protected override void OnResize(System.EventArgs e)
        {
            SetWindowRegion();
            SetShadow();
        }
        int x, y;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lsbIPMap = new LemonArp.TransparentListBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbEndIP = new System.Windows.Forms.TextBox();
            this.btnArpStorm = new System.Windows.Forms.Button();
            this.btnArpGetway = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txbStartIP = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsbIPMap
            // 
            this.lsbIPMap.BackColor = System.Drawing.Color.Transparent;
            this.lsbIPMap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsbIPMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lsbIPMap.FormattingEnabled = true;
            this.lsbIPMap.ItemHeight = 16;
            this.lsbIPMap.Location = new System.Drawing.Point(7, 35);
            this.lsbIPMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbIPMap.Name = "lsbIPMap";
            this.lsbIPMap.Size = new System.Drawing.Size(207, 224);
            this.lsbIPMap.TabIndex = 3;
            this.lsbIPMap.SelectedIndexChanged += new System.EventHandler(this.lsbIPMap_SelectedIndexChanged);
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnScan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnScan.Location = new System.Drawing.Point(227, 90);
            this.btnScan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(199, 27);
            this.btnScan.TabIndex = 14;
            this.btnScan.Text = "搜索";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label7.Location = new System.Drawing.Point(222, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "开始IP段:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label8.Location = new System.Drawing.Point(223, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "结束IP段:";
            // 
            // txbEndIP
            // 
            this.txbEndIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txbEndIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbEndIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.txbEndIP.Location = new System.Drawing.Point(277, 64);
            this.txbEndIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbEndIP.Multiline = true;
            this.txbEndIP.Name = "txbEndIP";
            this.txbEndIP.Size = new System.Drawing.Size(148, 21);
            this.txbEndIP.TabIndex = 18;
            this.txbEndIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnArpStorm
            // 
            this.btnArpStorm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnArpStorm.Enabled = false;
            this.btnArpStorm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnArpStorm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArpStorm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnArpStorm.Location = new System.Drawing.Point(328, 120);
            this.btnArpStorm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnArpStorm.Name = "btnArpStorm";
            this.btnArpStorm.Size = new System.Drawing.Size(99, 43);
            this.btnArpStorm.TabIndex = 20;
            this.btnArpStorm.Text = "ARP攻击全部";
            this.btnArpStorm.UseVisualStyleBackColor = false;
            this.btnArpStorm.Click += new System.EventHandler(this.btnArpStorm_Click);
            // 
            // btnArpGetway
            // 
            this.btnArpGetway.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnArpGetway.Enabled = false;
            this.btnArpGetway.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnArpGetway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArpGetway.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnArpGetway.Location = new System.Drawing.Point(225, 120);
            this.btnArpGetway.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnArpGetway.Name = "btnArpGetway";
            this.btnArpGetway.Size = new System.Drawing.Size(99, 43);
            this.btnArpGetway.TabIndex = 19;
            this.btnArpGetway.Text = "ARP攻击";
            this.btnArpGetway.UseVisualStyleBackColor = false;
            this.btnArpGetway.Click += new System.EventHandler(this.btnArpGetway_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.label6.Location = new System.Drawing.Point(222, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "©Twilight./Lemon 2017";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(222, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 73);
            this.label2.TabIndex = 22;
            this.label2.Text = "IP MAC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button1.CausesValidation = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(276, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 25);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txbStartIP
            // 
            this.txbStartIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txbStartIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbStartIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.txbStartIP.Location = new System.Drawing.Point(277, 34);
            this.txbStartIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbStartIP.Multiline = true;
            this.txbStartIP.Name = "txbStartIP";
            this.txbStartIP.Size = new System.Drawing.Size(148, 21);
            this.txbStartIP.TabIndex = 24;
            this.txbStartIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button2.CausesValidation = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(276, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 25);
            this.button2.TabIndex = 25;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.CausesValidation = false;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(6, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 226);
            this.button3.TabIndex = 26;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.CausesValidation = false;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.button4.Location = new System.Drawing.Point(415, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 20);
            this.button4.TabIndex = 27;
            this.button4.Text = "✖";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "小萌 ARP断网攻击";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LemonArp.Properties.Resources._54_130FZ94010;
            this.ClientSize = new System.Drawing.Size(437, 269);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txbStartIP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnArpStorm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbEndIP);
            this.Controls.Add(this.btnArpGetway);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lsbIPMap);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button3);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "小萌ARP断网攻击";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbEndIP;
        private System.Windows.Forms.Button btnArpGetway;
        private System.Windows.Forms.Button btnArpStorm;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbStartIP;
        private System.Windows.Forms.Button button2;
        private TransparentListBox lsbIPMap;
        private System.Windows.Forms.Button button3;
        private Button button4;
        private Label label1;
    }
}