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
using FileTransfer.Model;

namespace FileTransfer.UI
{
    public partial class FileTransferListener : Form
    {
        public FileTransferListener()
        {
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
        public ListenerManager listenerManager { get; set; }

        /// <summary>
        /// 刷新显示
        /// </summary>
        public Timer timerRenovateDisplay { get; set; }

        /// <summary>
        /// listenter的IP地址
        /// </summary>
        string IP;
        /// <summary>
        /// listenter的端口
        /// </summary>
        string Port;
        /// <summary>
        /// 当前客户端连接总数
        /// </summary>
        int ClientCount;
        /// <summary>
        /// 正在下载文件的客户端总数
        /// </summary>
        int ClientDownCount;

        /// <summary>
        /// 要传输的文件信息集合
        /// </summary>
        public List<TransferFileInfo> TransferFileInfo { get; set; }

        #endregion

        #region 方法
        
        private void FileTransferListener_Load(object sender, EventArgs e)
        {
            //创建服务器管理对象
            listenerManager = new ListenerManager();
            // 初始化显示连接状态控件
            this.timerRenovateDisplay = new Timer();
            this.timerRenovateDisplay.Interval = 1000;
            this.timerRenovateDisplay.Tick += timerRenovateDisplay_Tick;

            //设置控件允许接受拖入对象
            this.dgvFileInfoShow.AllowDrop = true;
            //设置文件拖入控件时触发的事件
            this.dgvFileInfoShow.DragEnter += FileTransferListener_DragEnter;
            this.dgvFileInfoShow.DragDrop += dataGridView1_DragDrop;

        }
        
        /// <summary>
        /// 文件拖入控件完成时获取文件地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == false)
            {
                this.showMessage("请不要拖入非文件对象！");
                return;
            }

            var obj = e.Data.GetData(DataFormats.FileDrop);
            //obj为你拖拽上来的文件或者文件夹的路径 数组
            string[] names = (string[])obj;
            //绑定数据到dgv
            this.bindingDgvSource(names);
        }

        /// <summary>
        /// 根据文件地址将文件信息绑定到dgv上
        /// </summary>
        /// <param name="names"></param>
        private void bindingDgvSource(string[] names)
        {
            //获取文件的信息
            this.TransferFileInfo = listenerManager.fileInfoLoadDgv(names);
            //绑定dgv的数据源
            this.dgvFileInfoShow.DataSource = TransferFileInfo;
        }

        /// <summary>
        /// 文件拖入控件时更鼠标显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FileTransferListener_DragEnter(object sender, DragEventArgs e)
        {
            // 确定拖放的是文档
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // 允许拖放动作继续,此时鼠标会显示为+
                e.Effect = DragDropEffects.All;
            }
        }

        /// <summary>
        /// timer触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timerRenovateDisplay_Tick(object sender, EventArgs e)
        {
            this.initialiseControl();
        }

        /// <summary>
        /// 开始侦听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartListener_Click(object sender, EventArgs e)
        {
            bool hasStartListener = this.listenerManager.startListener();
            if (hasStartListener)
            {
                this.timerRenovateDisplay.Start();
                this.showMessage("开启成功，正在侦听！");
            }
            else
            {
                this.showMessage("正在侦听，请勿重复开启！");
                return;
            }
        }

        /// <summary>
        /// 初始化显示连接连接状态控件
        /// </summary>
        private void initialiseControl()
        {
            if (listenerManager == null)
            {
                this.IP = "";
                this.Port = "";
                this.ClientCount = 0;
                this.ClientDownCount = 0;
            }
            else
            {
                listenerManager.getConnectInfo(out IP, out Port, out ClientCount, out ClientDownCount);
            }
            this.lblIP.Text = this.IP;
            this.lblPort.Text = this.Port;
            this.lblClientCount.Text = this.ClientCount.ToString();
            this.lblClientDownCount.Text = this.ClientDownCount.ToString();
        }

        /// <summary>
        /// 显示提示消息
        /// </summary>
        /// <param name="message">消息</param>
        private void showMessage(string message)
        {
            MessageBox.Show(message,"提示信息");
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
        /// <summary>
        /// 关闭窗口之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileTransferListener_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭所有关联进程
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// 关闭侦听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopListener_Click(object sender, EventArgs e)
        {
            bool hasCloseListener = listenerManager.closeListener();
            if (hasCloseListener)
            {
                this.showMessage("关闭成功！");
            }
            else
            {
                this.showMessage("关闭失败，请确认已开启侦听！");
            }
        }

        /// <summary>
        /// 选择上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            this.openFileDialogLoad.Title = "选择上传的文件";
            this.openFileDialogLoad.Filter = "所有文件(*.*)|*.*";
            this.openFileDialogLoad.RestoreDirectory = true;
            this.openFileDialogLoad.Multiselect = true;      //可以选择多个文件

            DialogResult result = this.openFileDialogLoad.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //获取地址
                string[] FileName = openFileDialogLoad.FileNames;
            }
        }

        #endregion
    }
}
