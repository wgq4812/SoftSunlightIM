using SoftSunlight.Tool;
using SoftSunlightIM.TcpService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SoftSunlightIM.TcpService.Handler
{
    /// <summary>
    /// 处理客户端和服务端通信的消息
    /// </summary>
    public class ToServerMessageHandler : MessageHandler
    {
        public override void Process(MessageHeader messageHeader, NetworkStream networkStream)
        {
            if (messageHeader.CmdType != CommandTypeEnum.ToServer)
            {
                Log.Write("错误的消息处理 From ToServerMessageHandler.Process");
                return;
            }
            byte[] cmdLengthByte = new byte[2];
            networkStream.Read(cmdLengthByte, 0, cmdLengthByte.Length);
            int headerLength = BitConverter.ToUInt16(cmdLengthByte);
            byte[] buffer = new byte[256];
            int totalReaded = 0;
            int readed = 0;
            MemoryStream memoryStream = new MemoryStream();
            do
            {
                readed = networkStream.Read(buffer, 0, buffer.Length);
                memoryStream.Write(buffer);
                totalReaded += readed;
            } while (totalReaded < headerLength);
        }
    }
}
