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
using System.Threading;
using System.Threading.Tasks;

namespace SoftSunlightIM.TcpService
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

        /// <summary>
        /// 客户端集合
        /// </summary>
        private static List<TcpClient> clients { get; set; } = new List<TcpClient>();

        /// <summary>
        /// 消息处理事件
        /// </summary>
        public static Action<string> OnMessage;

        /// <summary>
        /// 启动socket服务
        /// </summary>
        /// <returns></returns>
        public static void Start()
        {
            if (tcpListener == null)
            {
                tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7777);
            }
            tcpListener.Start();
            while (true)
            {
                try
                {
                    Task<TcpClient> clientTask = tcpListener.AcceptTcpClientAsync();
                    //数据收发
                    TcpClient tcpClient = clientTask.Result;
                    if (!clients.Contains(tcpClient))
                    {
                        clients.Add(tcpClient);
                        Task.Run(() =>
                        {
                            ReceiveData(tcpClient);
                        });
                    }
                }
                catch (Exception ex)
                {
                    //输出日志，跳出循环
                    break;
                }
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="tcpClient"></param>
        private static void ReceiveData(TcpClient tcpClient)
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

        ~TcpSocketServer()
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }
        }

    }
}
