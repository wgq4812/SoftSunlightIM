using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ
{
    /// <summary>
    /// 通讯消息格式
    /// </summary>
    [Serializable]
    public class Message
    {
        /// <summary>
        /// 发送账号
        /// </summary>
        public string SendAccount { get; set; }
        /// <summary>
        /// 接受账号
        /// </summary>
        public string ToAccount { get; set; }
        /// <summary>
        /// 消息发送类型(1:点对点消息，2:群消息)
        /// </summary>
        public int SendType { get; set; }
        /// <summary>
        /// 消息类型(1、文本消息，2、文件)
        /// </summary>
        public int MessageType { get; set; }
        /// <summary>
        /// 要发送的文字消息
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 发送的文件
        /// </summary>
        public FileItem File { get; set; }
    }

    /// <summary>
    /// 文件
    /// </summary>
    [Serializable]
    public class FileItem
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件内容
        /// </summary>
        public byte[] FileContent { get; set; }
    }

    public enum SendTypeEnum
    {
        /// <summary>
        /// 点对点消息
        /// </summary>
        PointToPoint = 1,
        /// <summary>
        /// 群组消息
        /// </summary>
        PointToGroup = 2
    }

    public enum MessageTypeEnum
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        Text = 1,
        /// <summary>
        /// 文件
        /// </summary>
        File = 2
    }

}
