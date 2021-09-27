using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyQQ.TcpService
{
    /// <summary>
    /// TCP服务端
    /// </summary>
    public class TcpSocketServer
    {
        /// <summary>
        /// 服务端socket监听对象
        /// </summary>
        private static TcpListener tcpListener = null;

        private static List<TcpClient> clients { get; set; } = new List<TcpClient>();

        /// <summary>
        /// 消息处理事件
        /// </summary>

        public static Action<Message> OnMessage;

        /// <summary>
        /// 启动socket服务
        /// </summary>
        /// <returns></returns>
        public static void Start()
        {
            if (tcpListener == null)
            {
                tcpListener = new TcpListener(IPAddress.Parse("0.0.0.0"), 7777);
            }
            tcpListener.Start();
            while (true)
            {
                try
                {
                    Task<TcpClient> clientTask = tcpListener.AcceptTcpClientAsync();
                    while (true)
                    {
                        //数据收发
                        TcpClient tcpClient = clientTask.Result;
                        clients.Add(tcpClient);
                        try
                        {
                            NetworkStream networkStream = tcpClient.GetStream();
                            MemoryStream memoryStream = new MemoryStream();
                            int recvTotals = 0;
                            while (tcpClient.Available > 0)
                            {
                                byte[] buffer = new byte[512];
                                int realLength = networkStream.Read(buffer, 0, buffer.Length);
                                memoryStream.Write(buffer, recvTotals, realLength);
                                recvTotals += realLength;
                            }
                            string content = Encoding.UTF8.GetString(memoryStream.ToArray());
                            if (memoryStream != null)
                            {
                                memoryStream.Close();
                                memoryStream.Dispose();
                                memoryStream = null;
                            }
                            Message message = JsonSerializer.Deserialize<Message>(content);
                            OnMessage?.Invoke(message);
                        }
                        catch (SocketException ex)
                        {
                            clients.Remove(tcpClient);
                            //输出日志，跳出循环
                            break;
                        }
                        catch (Exception ex)
                        {
                            //输出日志，跳出循环
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //输出日志，跳出循环
                    break;
                }
            }
        }

        ~TcpSocketServer()
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }
        }

    }
}
