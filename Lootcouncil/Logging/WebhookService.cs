using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lootcouncil.Logging
{
    public class WebhookService : BackgroundService
    {
        private readonly WebhookRequestQueue _queue;

        public WebhookService(WebhookRequestQueue queue)
        {
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await _queue.DequeueAsync(stoppingToken);

                try
                {
                    await workItem(stoppingToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception when executing webhook request, retrying");
                    await Task.Delay(2000, stoppingToken);
                    await workItem(stoppingToken);
                }
            }
        }
    }
}
