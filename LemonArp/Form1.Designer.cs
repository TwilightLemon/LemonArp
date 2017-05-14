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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbDeviceList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbIPMap = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbGetwayIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbGetwayMAC = new System.Windows.Forms.TextBox();
            this.txbLocalMAC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbLocalIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbStartIP = new System.Windows.Forms.TextBox();
            this.txbEndIP = new System.Windows.Forms.TextBox();
            this.btnArpStorm = new System.Windows.Forms.Button();
            this.btnArpGetway = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbDeviceList
            // 
            this.cmbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceList.FormattingEnabled = true;
            this.cmbDeviceList.Location = new System.Drawing.Point(63, 38);
            this.cmbDeviceList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDeviceList.Name = "cmbDeviceList";
            this.cmbDeviceList.Size = new System.Drawing.Size(401, 25);
            this.cmbDeviceList.TabIndex = 0;
            this.cmbDeviceList.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "网卡:";
            // 
            // lsbIPMap
            // 
            this.lsbIPMap.FormattingEnabled = true;
            this.lsbIPMap.ItemHeight = 17;
            this.lsbIPMap.Location = new System.Drawing.Point(7, 105);
            this.lsbIPMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbIPMap.Name = "lsbIPMap";
            this.lsbIPMap.Size = new System.Drawing.Size(261, 293);
            this.lsbIPMap.TabIndex = 3;
            this.lsbIPMap.SelectedIndexChanged += new System.EventHandler(this.lsbIPMap_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "网关IP：";
            // 
            // txbGetwayIP
            // 
            this.txbGetwayIP.Enabled = false;
            this.txbGetwayIP.Location = new System.Drawing.Point(349, 102);
            this.txbGetwayIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbGetwayIP.Name = "txbGetwayIP";
            this.txbGetwayIP.Size = new System.Drawing.Size(116, 23);
            this.txbGetwayIP.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "网关MAC：";
            // 
            // txbGetwayMAC
            // 
            this.txbGetwayMAC.Enabled = false;
            this.txbGetwayMAC.Location = new System.Drawing.Point(349, 141);
            this.txbGetwayMAC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbGetwayMAC.Name = "txbGetwayMAC";
            this.txbGetwayMAC.Size = new System.Drawing.Size(116, 23);
            this.txbGetwayMAC.TabIndex = 7;
            // 
            // txbLocalMAC
            // 
            this.txbLocalMAC.Enabled = false;
            this.txbLocalMAC.Location = new System.Drawing.Point(349, 217);
            this.txbLocalMAC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbLocalMAC.Name = "txbLocalMAC";
            this.txbLocalMAC.Size = new System.Drawing.Size(116, 23);
            this.txbLocalMAC.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "本地MAC：";
            // 
            // txbLocalIP
            // 
            this.txbLocalIP.Enabled = false;
            this.txbLocalIP.Location = new System.Drawing.Point(349, 179);
            this.txbLocalIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbLocalIP.Name = "txbLocalIP";
            this.txbLocalIP.Size = new System.Drawing.Size(116, 23);
            this.txbLocalIP.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "本地IP：";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(396, 71);
            this.btnScan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(69, 23);
            this.btnScan.TabIndex = 14;
            this.btnScan.Text = "搜索";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "开始IP段:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "结束IP段:";
            // 
            // txbStartIP
            // 
            this.txbStartIP.Location = new System.Drawing.Point(63, 71);
            this.txbStartIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbStartIP.Name = "txbStartIP";
            this.txbStartIP.Size = new System.Drawing.Size(132, 23);
            this.txbStartIP.TabIndex = 17;
            // 
            // txbEndIP
            // 
            this.txbEndIP.Location = new System.Drawing.Point(256, 71);
            this.txbEndIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbEndIP.Name = "txbEndIP";
            this.txbEndIP.Size = new System.Drawing.Size(132, 23);
            this.txbEndIP.TabIndex = 18;
            // 
            // btnArpStorm
            // 
            this.btnArpStorm.Location = new System.Drawing.Point(274, 326);
            this.btnArpStorm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnArpStorm.Name = "btnArpStorm";
            this.btnArpStorm.Size = new System.Drawing.Size(191, 72);
            this.btnArpStorm.TabIndex = 20;
            this.btnArpStorm.Text = "ARP攻击全部";
            this.btnArpStorm.UseVisualStyleBackColor = true;
            this.btnArpStorm.Click += new System.EventHandler(this.btnArpStorm_Click);
            // 
            // btnArpGetway
            // 
            this.btnArpGetway.Enabled = false;
            this.btnArpGetway.Location = new System.Drawing.Point(274, 250);
            this.btnArpGetway.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnArpGetway.Name = "btnArpGetway";
            this.btnArpGetway.Size = new System.Drawing.Size(191, 72);
            this.btnArpGetway.TabIndex = 19;
            this.btnArpGetway.Text = "ARP攻击";
            this.btnArpGetway.UseVisualStyleBackColor = true;
            this.btnArpGetway.Click += new System.EventHandler(this.btnArpGetway_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(322, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "©Twilight./Lemon 2017";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 416);
            this.Controls.Add(this.btnArpStorm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbGetwayMAC);
            this.Controls.Add(this.txbEndIP);
            this.Controls.Add(this.btnArpGetway);
            this.Controls.Add(this.txbStartIP);
            this.Controls.Add(this.txbLocalMAC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lsbIPMap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbLocalIP);
            this.Controls.Add(this.txbGetwayIP);
            this.Controls.Add(this.cmbDeviceList);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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

        private System.Windows.Forms.ComboBox cmbDeviceList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbIPMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbGetwayIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbGetwayMAC;
        private System.Windows.Forms.TextBox txbLocalMAC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbLocalIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbStartIP;
        private System.Windows.Forms.TextBox txbEndIP;
        private System.Windows.Forms.Button btnArpGetway;
        private System.Windows.Forms.Button btnArpStorm;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
    }
}