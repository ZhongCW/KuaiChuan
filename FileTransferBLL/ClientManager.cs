using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace FileTransfer.BLL
{
    /// <summary>
    /// 客户端管理
    /// </summary>
    public class ClientManager
    {
        #region 属性

        /// <summary>
        /// 客户端对象
        /// </summary>
        public TcpClient client { get; set; }

        /// <summary>
        /// 是否与listener连接
        /// </summary>
        public bool hasConnectListener { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口</param>
        /// <returns>true：连接成功</returns>
        public bool connectListener(string ip,string port)
        {
            int portAddress;
            if (!int.TryParse(port, out portAddress) && hasConnectListener)//判断是否已连接
            {
                return false;
            }

            this.client = new TcpClient();
            try
            {
                this.client.Connect(ip, portAddress);
                hasConnectListener = true;

                return true;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }

        /// <summary>
        /// 断开与listener的连接
        /// </summary>
        /// <returns>false:当前未连接服务器</returns>
        public bool blackConnectListener()
        {
            if (this.client == null)
            {
                return false;
            }
            client.Close();
            hasConnectListener = false;
            this.client = null;
            return true ;
        }

        #endregion
    }
}
