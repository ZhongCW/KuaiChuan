using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using FileTransfer.Model;

namespace FileTransfer.DAL
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileManager
    {
        #region 属性

        /// <summary>
        /// 文件信息集合
        /// </summary>
        public Dictionary<string,TransferFileInfo> transferFileInfo { get; set; }

        #endregion

        public FileManager()
        {
            transferFileInfo = new Dictionary<string, TransferFileInfo>();
        }
        /// <summary>
        /// 获取数组当中的文件的信息
        /// </summary>
        /// <param name="names">文件地址数组</param>
        /// <returns>储存文件信息的集合</returns>
        public List<TransferFileInfo> getFileInfo(string[] names)
        {
            //循环判断地址是文件还是文件夹
            for (int i = 0; i < names.Length; i++)
            {
                if (Directory.Exists(names[i])) //文件夹
                {
                    DirectoryInfo directory = new DirectoryInfo(names[i]);
                    TransferFileInfo fileInfo = new TransferFileInfo();
                    fileInfo.FileName = directory.Name;     //获取文件名称
                    fileInfo.FilePath = directory.FullName; //获取文件路径
                    fileInfo.FileSize = GetDirectoryLength(names[i]);   //获取文件大小(kb)
                    fileInfo.FileType = "文件夹";
                    transferFileInfo.Add(fileInfo.FilePath,fileInfo);
                }
                else if (File.Exists(names[i])) //文件
                {
                    FileInfo file = new FileInfo(names[i]);
                    TransferFileInfo fileInfo = new TransferFileInfo();
                    fileInfo.FileName = file.Name;     //获取文件名称
                    fileInfo.FilePath = file.FullName; //获取文件路径
                    fileInfo.FileSize = file.Length;   //获取文件大小
                    fileInfo.FileType = file.Extension; //获取文件类型
                    transferFileInfo.Add(fileInfo.FilePath, fileInfo);
                }
                else
                {
                    //无效路径"
                } 
            }
            return new List<TransferFileInfo>(transferFileInfo.Values);
        }

        /// <summary>
        /// 根据文件夹地址获取文件夹大小
        /// </summary>
        /// <param name="dirPath">文件夹地址</param>
        /// <returns>文件夹大小</returns>
        public static double GetDirectoryLength(string dirPath)
        {
            //判断给定的路径是否存在,如果不存在则退出
            if (!Directory.Exists(dirPath))
                return 0;
            double len = 0;
            //定义一个DirectoryInfo对象
            DirectoryInfo di = new DirectoryInfo(dirPath);
            //通过GetFiles方法,获取di目录中的所有文件的大小
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }
            //获取di中所有的文件夹,并存到一个新的对象数组中,以进行递归
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }

        #region 文件与byte数组之间转换
        
        /// <summary>
        /// 将byte数组转换为文件并保存到指定地址
        /// </summary>
        /// <param name="buff">byte数组</param>
        /// <param name="savepath">保存地址</param>
        public static void Bytes2File(byte[] buff, string savepath)
        {
            if (File.Exists(savepath))
            {
                File.Delete(savepath);
            }

            FileStream fs = new FileStream(savepath, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(buff, 0, buff.Length);
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// 将文件转换为byte数组
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] File2Bytes(string path)
        {
            if (!File.Exists(path))
            {
                return new byte[0];
            }

            FileInfo fi = new FileInfo(path);
            byte[] buff = new byte[fi.Length];

            FileStream fs = fi.OpenRead();
            fs.Read(buff, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            return buff;
        }

        #endregion
    }
}
