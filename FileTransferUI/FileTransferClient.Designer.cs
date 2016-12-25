namespace FileTransfer.UI
{
    partial class FileTransferClient
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnBreakConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(159, 41);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(168, 25);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "192.168.1.102";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(159, 102);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(168, 25);
            this.txtPort.TabIndex = 0;
            this.txtPort.Text = "6666";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(159, 149);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(168, 40);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnBreakConnect
            // 
            this.btnBreakConnect.Location = new System.Drawing.Point(159, 204);
            this.btnBreakConnect.Name = "btnBreakConnect";
            this.btnBreakConnect.Size = new System.Drawing.Size(168, 40);
            this.btnBreakConnect.TabIndex = 1;
            this.btnBreakConnect.Text = "断开连接";
            this.btnBreakConnect.UseVisualStyleBackColor = true;
            this.btnBreakConnect.Click += new System.EventHandler(this.btnBreakConnect_Click);
            // 
            // FileTransferClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 421);
            this.Controls.Add(this.btnBreakConnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Name = "FileTransferClient";
            this.Text = "接收文件";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileTransferClient_FormClosed);
            this.Load += new System.EventHandler(this.FileTransferClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnBreakConnect;
    }
}