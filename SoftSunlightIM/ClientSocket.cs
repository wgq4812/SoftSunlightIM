using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftSunlightIM
{
    public class ClientSocket
    {
        /// <summary>
        /// Tcp客户端Socket
        /// </summary>
        private static TcpClient tcpClient { get; set; }

        /// <summary>
        /// 消息处理事件
        /// </summary>
        public static Action<string> OnMessage;

        /// <summary>
        /// 客户端启动
        /// </summary>
        public static string Start()
        {
            string errorMsg = string.Empty;
            if (tcpClient == null)
            {
                try
                {
                    tcpClient = new TcpClient();
                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 7777);
                    Task.Run(() =>
                    {
                        Receive();
                    });
                }
                catch (SocketException ex)
                {
                    errorMsg = "请检查网络连接！";
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }
            }
            return errorMsg;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="MessageBody"></param>
        public static bool Send<T>(T MessageBody)
        {
            bool sendReuslt = true;
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(MessageBody));
                tcpClient.GetStream().Write(buffer, 0, buffer.Length);
            }
            catch (SocketException ex)
            {
                sendReuslt = false;
            }
            return sendReuslt;
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        private static void Receive()
        {
            while (true)
            {
                try
                {
                    NetworkStream networkStream = tcpClient.GetStream();
                    MemoryStream memoryStream = new MemoryStream();
                    int recvTotals = 0;
                    while (tcpClient.Available > 0)
                    {
                        byte[] buffer = new byte[512];
                        int realLength = networkStream.Read(buffer, 0, buffer.Length);
                        memoryStream.Write(buffer, 0, realLength);
                        recvTotals += realLength;
                    }
                    if (recvTotals > 0)
                    {
                        string content = Encoding.UTF8.GetString(memoryStream.ToArray());
                        if (memoryStream != null)
                        {
                            memoryStream.Close();
                            memoryStream.Dispose();
                            memoryStream = null;
                        }
                        if (!string.IsNullOrEmpty(content))
                        {
                            OnMessage?.Invoke(content);
                        }
                    }
                    Thread.Sleep(5000);
                }
                catch (SocketException ex)
                {

                }
            }
        }

    }
}
