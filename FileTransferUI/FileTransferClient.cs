using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FileTransfer.BLL;

namespace FileTransfer.UI
{
    public partial class FileTransferClient : Form
    {
        public FileTransferClient()
        {
            clientManager = new ClientManager();
            //窗口居中
            this.StartPosition = FormStartPosition.CenterScreen;
            //不允许最大化
            this.MaximizeBox = false;
            //窗口边框
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 客户端操作对象
        /// </summary>
        public ClientManager clientManager { get; set; }

        #endregion

        #region 方法
        
        private void FileTransferClient_Load(object sender, EventArgs e)
        {
            //设置控件默认状态
            this.btnBreakConnect.Enabled = false;
        }

        /// <summary>
        /// 连接服务器（listener）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //非空校验
            if (string.IsNullOrEmpty(this.txtIP.Text) || string.IsNullOrEmpty(this.txtPort.Text))
            {
                this.showMessage("请完整输入IP地址和端口信息！");
                this.txtIP.Focus();
                return;
            }
            //连接
            bool hasConnectOk = clientManager.connectListener(this.txtIP.Text, this.txtPort.Text);
            //判断连接是否成功
            if (!hasConnectOk)
            {
                this.showMessage("连接失败！请检查输入的IP地址和端口信息是否正确！");
                this.txtIP.Focus();
                return;
            }
            else
            {
                this.showMessage("连接成功！");
                this.btnConnect.Enabled = false;
                this.btnBreakConnect.Enabled = true;
            }
        }


        /// <summary>
        /// 显示提示消息
        /// </summary>
        /// <param name="message">消息</param>
        private void showMessage(string message)
        {
            MessageBox.Show(message, "提示信息");
        }

        /// <summary>
        /// 断开与listener连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBreakConnect_Click(object sender, EventArgs e)
        {
            if (this.clientManager.blackConnectListener())
            {
                this.showMessage("断开连接成功！");
                this.btnConnect.Enabled = true;
                this.btnBreakConnect.Enabled = false;
            }
            else
            {
                this.showMessage("当前还未连接服务器端！");
            }
        }

        /// <summary>
        /// 关闭窗口之后
        /// </summary>
        private void FileTransferClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭所有关联进程
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        #endregion

    }
}
