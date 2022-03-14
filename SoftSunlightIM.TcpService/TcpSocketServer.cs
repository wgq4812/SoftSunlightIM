using SoftSunlight.Tool;
using SoftSunlightIM.TcpService.Handler;
using SoftSunlightIM.TcpService.Model;
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
                    Log.Write("接收客户端连接失败", ex);
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
                    /*
                     * 消息格式
                     * 4字节消息头部长度 + 消息头内容
                     */
                    byte[] headerLengthByte = new byte[4];
                    networkStream.Read(headerLengthByte, 0, headerLengthByte.Length);
                    int headerLength = BitConverter.ToInt32(headerLengthByte);
                    byte[] buffer = new byte[256];
                    int totalReaded = 0;
                    int readed = 0;
                    do
                    {
                        readed = networkStream.Read(buffer, 0, buffer.Length);
                        memoryStream.Write(buffer);
                        totalReaded += readed;
                    } while (totalReaded < headerLength);
                    if (memoryStream != null)
                    {
                        memoryStream.Close();
                        memoryStream.Dispose();
                        memoryStream = null;
                    }
                    string headerJson = Encoding.UTF8.GetString(memoryStream.ToArray());
                    MessageHeader messageHeader = null;
                    try
                    {
                        messageHeader = System.Text.Json.JsonSerializer.Deserialize<MessageHeader>(headerJson);
                    }
                    catch (Exception ex)
                    {

                    }
                    if (messageHeader != null)
                    {
                        switch (messageHeader.CmdType)
                        {
                            case CommandTypeEnum.Chat:

                                break;
                            case CommandTypeEnum.ToServer:
                                new ToServerMessageHandler().Process(messageHeader, networkStream);
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clients.Remove(tcpClient);
                    //输出日志，跳出循环
                    Log.Write("接收数据异常", ex);
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
