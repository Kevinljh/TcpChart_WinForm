namespace Win32_A6
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
            this.inMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inMsg
            // 
            this.inMsg.BackColor = System.Drawing.SystemColors.Window;
            this.inMsg.Location = new System.Drawing.Point(12, 12);
            this.inMsg.Multiline = true;
            this.inMsg.Name = "inMsg";
            this.inMsg.ReadOnly = true;
            this.inMsg.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.inMsg.Size = new System.Drawing.Size(525, 468);
            this.inMsg.TabIndex = 0;
            this.inMsg.TextChanged += new System.EventHandler(this.inMsg_TextChanged);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 492);
            this.Controls.Add(this.inMsg);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inMsg;
    }
}

