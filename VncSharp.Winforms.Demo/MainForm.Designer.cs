namespace VncSharp.Winforms.Demo
{
    partial class MainForm
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
            this.remoteDesktop = new VncSharp.Winforms.RemoteDesktop();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // remoteDesktop
            // 
            this.remoteDesktop.AutoScroll = true;
            this.remoteDesktop.AutoScrollMinSize = new System.Drawing.Size(608, 427);
            this.remoteDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteDesktop.Location = new System.Drawing.Point(0, 37);
            this.remoteDesktop.Name = "remoteDesktop";
            this.remoteDesktop.Size = new System.Drawing.Size(638, 446);
            this.remoteDesktop.TabIndex = 0;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnConnect);
            this.pnlControl.Controls.Add(this.tbPort);
            this.pnlControl.Controls.Add(this.tbHost);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(638, 37);
            this.pnlControl.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(292, 7);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(209, 9);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(77, 20);
            this.tbPort.TabIndex = 1;
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(8, 9);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(195, 20);
            this.tbHost.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 483);
            this.Controls.Add(this.remoteDesktop);
            this.Controls.Add(this.pnlControl);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RemoteDesktop remoteDesktop;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbHost;
    }
}

