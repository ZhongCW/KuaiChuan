using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace FileTransfer.Model
{
    /// <summary>
    /// 文件信息类
    /// </summary>
    public class TransferFileInfo
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        private string _filePath;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                //判断地址是文件还是文件夹
                if (Directory.Exists(value) || File.Exists(value)) //文件夹
                {
                    _filePath = value;

                }
            }
        }
        
        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }

        private double _fileSize;
        /// <summary>
        /// 文件大小（KB）
        /// </summary>
        public double FileSize
        {
            get { return _fileSize; }
            set 
            {
                //将字节大小转换为KB为单位
                _fileSize = Math.Round(value / 1024, 2);
            }
        }

        public Dictionary<string, List<byte[]>> FileBuff { get; private set; }

    }
}
