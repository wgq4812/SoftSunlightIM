using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyQQ.TcpService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    MessageHandler messageHandler = new MessageHandler();
                    TcpSocketServer.OnMessage += messageHandler.Process;
                    TcpSocketServer.Start();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TcpSocketServer服务运行失败");
                    await Task.Delay(3000);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
