using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSunlightIM
{
    /// <summary>
    /// socket 通信消息处理类
    /// </summary>
    public class MessageHandler
    {
        public void Process(string jsonMessage)
        {
            Console.WriteLine(jsonMessage);
        }
    }
}
