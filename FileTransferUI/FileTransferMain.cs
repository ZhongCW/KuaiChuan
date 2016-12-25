using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer.UI
{
    /// <summary>
    /// 主界面
    /// </summary>
    public partial class FileTransferMain : Form
    {
        public FileTransferMain()
        {
            InitializeComponent();
        }
        private void FileTransferMain_Load(object sender, EventArgs e)
        {
            //窗口居中
            this.StartPosition = FormStartPosition.CenterParent;
            //不允许最大化
            this.MaximizeBox = false;
            //窗口边框
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }
        /// <summary>
        /// 打开Listener界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListener_Click(object sender, EventArgs e)
        {
            this.Hide();
            FileTransferListener listener = new FileTransferListener();
            listener.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// 打开Client界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            FileTransferClient client = new FileTransferClient();
            client.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
