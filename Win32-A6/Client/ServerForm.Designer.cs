namespace Client
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outMsg = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ListenBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerIPTxt = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // outMsg
            // 
            this.outMsg.Location = new System.Drawing.Point(16, 462);
            this.outMsg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.outMsg.Multiline = true;
            this.outMsg.Name = "outMsg";
            this.outMsg.Size = new System.Drawing.Size(592, 92);
            this.outMsg.TabIndex = 0;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(617, 462);
            this.send.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(99, 92);
            this.send.TabIndex = 1;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(108, 7);
            this.PortTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(252, 25);
            this.PortTxt.TabIndex = 3;
            this.PortTxt.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // ListenBtn
            // 
            this.ListenBtn.Location = new System.Drawing.Point(561, 7);
            this.ListenBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ListenBtn.Name = "ListenBtn";
            this.ListenBtn.Size = new System.Drawing.Size(155, 50);
            this.ListenBtn.TabIndex = 5;
            this.ListenBtn.Text = "Listen";
            this.ListenBtn.UseVisualStyleBackColor = true;
            this.ListenBtn.Click += new System.EventHandler(this.Connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Server IP:";
            // 
            // ServerIPTxt
            // 
            this.ServerIPTxt.Location = new System.Drawing.Point(108, 37);
            this.ServerIPTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ServerIPTxt.Name = "ServerIPTxt";
            this.ServerIPTxt.Size = new System.Drawing.Size(252, 25);
            this.ServerIPTxt.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(16, 67);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(700, 379);
            this.listBox1.TabIndex = 8;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(384, 7);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(155, 50);
            this.ConnectBtn.TabIndex = 9;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 562);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ServerIPTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListenBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortTxt);
            this.Controls.Add(this.send);
            this.Controls.Add(this.outMsg);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ServerForm";
            this.Text = "Sever";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outMsg;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox PortTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ListenBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerIPTxt;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ConnectBtn;
    }
}

