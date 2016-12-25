namespace FileTransfer.UI
{
    partial class FileTransferListener
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.openFileDialogLoad = new System.Windows.Forms.OpenFileDialog();
            this.lable4 = new System.Windows.Forms.Label();
            this.lable3 = new System.Windows.Forms.Label();
            this.lblClientDownCount = new System.Windows.Forms.Label();
            this.lblClientCount = new System.Windows.Forms.Label();
            this.dgvFileInfoShow = new System.Windows.Forms.DataGridView();
            this.btnStartListener = new System.Windows.Forms.Button();
            this.btnStopListener = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileInfoShow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口：";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(56, 503);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(55, 15);
            this.lblIP.TabIndex = 1;
            this.lblIP.Text = "label3";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(56, 535);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(55, 15);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "label3";
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Location = new System.Drawing.Point(251, 503);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(127, 15);
            this.lable4.TabIndex = 2;
            this.lable4.Text = "当前连接设备数：";
            // 
            // lable3
            // 
            this.lable3.AutoSize = true;
            this.lable3.Location = new System.Drawing.Point(221, 535);
            this.lable3.Name = "lable3";
            this.lable3.Size = new System.Drawing.Size(157, 15);
            this.lable3.TabIndex = 3;
            this.lable3.Text = "正在下载的客户端数：";
            // 
            // lblClientDownCount
            // 
            this.lblClientDownCount.AutoSize = true;
            this.lblClientDownCount.Location = new System.Drawing.Point(375, 535);
            this.lblClientDownCount.Name = "lblClientDownCount";
            this.lblClientDownCount.Size = new System.Drawing.Size(55, 15);
            this.lblClientDownCount.TabIndex = 1;
            this.lblClientDownCount.Text = "label3";
            // 
            // lblClientCount
            // 
            this.lblClientCount.AutoSize = true;
            this.lblClientCount.Location = new System.Drawing.Point(375, 503);
            this.lblClientCount.Name = "lblClientCount";
            this.lblClientCount.Size = new System.Drawing.Size(55, 15);
            this.lblClientCount.TabIndex = 1;
            this.lblClientCount.Text = "label3";
            // 
            // dgvFileInfoShow
            // 
            this.dgvFileInfoShow.AllowUserToAddRows = false;
            this.dgvFileInfoShow.AllowUserToDeleteRows = false;
            this.dgvFileInfoShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFileInfoShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileInfoShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileType,
            this.FileSize,
            this.FilePath});
            this.dgvFileInfoShow.Location = new System.Drawing.Point(12, 51);
            this.dgvFileInfoShow.Name = "dgvFileInfoShow";
            this.dgvFileInfoShow.ReadOnly = true;
            this.dgvFileInfoShow.RowTemplate.Height = 27;
            this.dgvFileInfoShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileInfoShow.Size = new System.Drawing.Size(699, 307);
            this.dgvFileInfoShow.TabIndex = 4;
            // 
            // btnStartListener
            // 
            this.btnStartListener.Location = new System.Drawing.Point(772, 309);
            this.btnStartListener.Name = "btnStartListener";
            this.btnStartListener.Size = new System.Drawing.Size(75, 36);
            this.btnStartListener.TabIndex = 5;
            this.btnStartListener.Text = "开始侦听";
            this.btnStartListener.UseVisualStyleBackColor = true;
            this.btnStartListener.Click += new System.EventHandler(this.btnStartListener_Click);
            // 
            // btnStopListener
            // 
            this.btnStopListener.Location = new System.Drawing.Point(772, 372);
            this.btnStopListener.Name = "btnStopListener";
            this.btnStopListener.Size = new System.Drawing.Size(75, 36);
            this.btnStopListener.TabIndex = 5;
            this.btnStopListener.Text = "停止侦听";
            this.btnStopListener.UseVisualStyleBackColor = true;
            this.btnStopListener.Click += new System.EventHandler(this.btnStopListener_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(772, 428);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 36);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出程序";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.Location = new System.Drawing.Point(772, 480);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(75, 36);
            this.btnMessage.TabIndex = 5;
            this.btnMessage.Text = "发送通知";
            this.btnMessage.UseVisualStyleBackColor = true;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(584, 384);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(127, 50);
            this.btnSelectFile.TabIndex = 6;
            this.btnSelectFile.Text = "选择上传文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "文件名称";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // FileType
            // 
            this.FileType.DataPropertyName = "FileType";
            this.FileType.HeaderText = "文件类型";
            this.FileType.Name = "FileType";
            this.FileType.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.DataPropertyName = "FileSize";
            this.FileSize.HeaderText = "文件大小(KB)";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "文件路径";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            // 
            // FileTransferListener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 558);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStopListener);
            this.Controls.Add(this.btnStartListener);
            this.Controls.Add(this.dgvFileInfoShow);
            this.Controls.Add(this.lable3);
            this.Controls.Add(this.lable4);
            this.Controls.Add(this.lblClientCount);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblClientDownCount);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FileTransferListener";
            this.Text = "上传文件";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileTransferListener_FormClosed);
            this.Load += new System.EventHandler(this.FileTransferListener_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileInfoShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoad;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.Label lable3;
        private System.Windows.Forms.Label lblClientDownCount;
        private System.Windows.Forms.Label lblClientCount;
        private System.Windows.Forms.DataGridView dgvFileInfoShow;
        private System.Windows.Forms.Button btnStartListener;
        private System.Windows.Forms.Button btnStopListener;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMessage;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
    }
}