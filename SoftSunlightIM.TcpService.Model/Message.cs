using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSunlightIM.TcpService.Model
{

    /// <summary>
    /// 消息头
    /// </summary>
    public class MessageHeader
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
        /// 命令类型
        /// </summary>
        public CommandTypeEnum CmdType { get; set; }
    }

    /// <summary>
    /// 聊天消息类型
    /// </summary>
    public enum ChatMessageTypeEnum
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        Text = 101,
        /// <summary>
        /// 文件
        /// </summary>
        File = 102
    }

    /// <summary>
    /// 命令类型
    /// </summary>
    public enum CommandTypeEnum
    {
        /// <summary>
        /// 聊天
        /// </summary>
        Chat = 1,
        /// <summary>
        /// 发送给服务器
        /// </summary>
        ToServer = 2,
    }

    /// <summary>
    /// 发送给服务器消息类型
    /// </summary>
    public enum ToServerMessageTypeEnum
    {
        /// <summary>
        /// 登录
        /// </summary>
        Login = 201,
    }

}
