using Microsoft.Extensions.Logging;
using SoftSunlightIM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoftSunlightIM.TcpService
{
    /// <summary>
    /// socket 通信消息处理类
    /// </summary>
    public class MessageHandler
    {
        public void Process(string jsonMessage)
        {
            JsonSerializer.Deserialize<Message>(jsonMessage);
            Console.WriteLine(jsonMessage);
        }
    }
}
