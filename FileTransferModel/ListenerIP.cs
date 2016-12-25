using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer.Model
{
    public class ListenerIP
    {
        /// <summary>
        /// 本机IP
        /// </summary>
        public ListenerIP ip { get; set; }
        /// <summary>
        /// 连接端口
        /// </summary>
        public int port { get; set; }
    }
}
