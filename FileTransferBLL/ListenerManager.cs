using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using FileTransfer.Model;
using FileTransfer.DAL;

namespace FileTransfer.BLL
{
    /// <summary>
    /// 服务器端管理
    /// </summary>
    public class ListenerManager
    {
        #region 属性

        private IPAddress _ipLocal;
        /// <summary>
        /// 本机IP地址
        /// </summary>
        public IPAddress IPLocal
        {
            get 
            {
                // 获取本地的IP地址
                string AddressIP = string.Empty;    //本机IP地址
                foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                    {
                        AddressIP = _IPAddress.ToString();
                    }
                }
                return IPAddress.Parse(AddressIP);
            }
        }

        private int _port;
        /// <summary>
        /// 连接端口
        /// </summary>
        public int Port
        {
            get { return 6666; }
        }
        
        /// <summary>
        /// 服务器对象
        /// </summary>
        public TcpListener Listener { get; set; }

        /// <summary>
        /// 记录是否正在侦听
        /// </summary>
        public bool hasStartListener { get; set; }


        /// <summary>
        /// 客户端集合
        /// </summary>
        public Dictionary<string, TcpClient> clients { get; set; }

        /// <summary>
        /// 获取套接字(客户端)线程
        /// </summary>
        public Thread AcceptClient { get; set; }

        /// <summary>
        /// 侦听套接字(客户端)线程
        /// </summary>
        public Thread AcceptClientInfo { get; set; }

        /// <summary>
        /// 判断最新获得的client对象是否已经处理（是否正在侦听上传信息）
        /// </summary>
        public bool hasClientManaged { get; set; }

        /// <summary>
        /// 上传文件集合
        /// </summary>
        public Dictionary<string, List<byte[]>> FileBuff { get; set; }

        /// <summary>
        /// 数据操作对象
        /// </summary>
        public FileManager fileManager { get; set; }

        #endregion

        #region 行为

        public ListenerManager()
        {
            //这是不存在上一个Client，所以算是处理了
            hasClientManaged = true;
            clients = new Dictionary<string, TcpClient>();
        }

        /// <summary>
        /// 开始侦听
        /// </summary>
        /// <returns>true：开启成功，正在侦听</returns>
        public bool startListener()
        {
            if (hasStartListener)
            {
                return false;
            }
            //打开侦听
            this.Listener = new TcpListener(this.IPLocal, this.Port);
            this.Listener.Start();
            this.hasStartListener = true;

            AcceptClient = new Thread(new ThreadStart(this.getClient));
            AcceptClient.Start();
            return true;
        }

        /// <summary>
        /// 关闭侦听
        /// </summary>
        /// <returns></returns>
        public bool closeListener()
        {
            if (this.hasStartListener && (this.AcceptClient.ThreadState == System.Threading.ThreadState.Running))
            {
                //关闭listener
                this.Listener.Stop();
                //关闭线程
                this.AcceptClient.Abort();
                this.hasStartListener = false;
                //清空client集合
                this.clients.Clear();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取连接的套接字（客户端）
        /// </summary>
        private void getClient()
        {
            while (true)
            {
                while (!this.hasClientManaged) { }  //如果上一个client还未侦听，就不开始获取下一个新的client

                TcpClient client = this.Listener.AcceptTcpClient();
                string clientIP = client.Client.RemoteEndPoint.ToString();
                this.clients.Add(clientIP, client);
                this.hasClientManaged = false;

                AcceptClientInfo = new Thread(new ThreadStart(getClientInfo));
                AcceptClientInfo.Start();
            }
        }

        /// <summary>
        /// 侦听客户端上传的信息
        /// </summary>
        private void getClientInfo()
        {
            
            TcpClient client = this.clients.Values.Last();  //返回集合中的最后一个元素
            this.hasClientManaged = true;   // 侦听客户端上传的信息
            while (true)    //循环读取client返回数据
            {
                
            }
        }

        /// <summary>
        /// 获取当前listener连接信息
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Port"></param>
        /// <param name="ClientCount"></param>
        /// <param name="ClientDownCount"></param>
        public void getConnectInfo(out string IP, out string Port, out int ClientCount, out int ClientDownCount)
        {
            IP = this.IPLocal.ToString();
            Port = this.Port.ToString();
            ClientCount = clients.Count;
            ClientDownCount = 0;    //获取当前正在下载的client
        }

        /// <summary>
        /// 获取要加载到dgv的文件信息
        /// </summary>
        /// <param name="names">文件名称数组</param>
        /// <returns>文件信息集合</returns>
        public List<TransferFileInfo> fileInfoLoadDgv(string[] names)
        {
            fileManager = new FileManager();
            return fileManager.getFileInfo(names);
        }

        #endregion



    }
}
