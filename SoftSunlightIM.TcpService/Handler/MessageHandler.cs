using Microsoft.Extensions.Logging;
using SoftSunlightIM.Model;
using SoftSunlightIM.TcpService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoftSunlightIM.TcpService.Handler
{
    /// <summary>
    /// socket 通信消息处理类
    /// </summary>
    public abstract class MessageHandler
    {
        public abstract void Process(MessageHeader messageHeader, NetworkStream networkStream);
    }
}
