using Lootcouncil.Models.Webhook;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lootcouncil.Logging
{
    public class DiscordLogger : ILogger
    {
        private readonly RestClient _client;
        private readonly Uri _uri;
        private readonly WebhookRequestQueue _queue;
        private readonly string _webhookUrl;

        public DiscordLogger(IConfiguration config, WebhookRequestQueue queue)
        {
            //_uri = new Uri(config["WebhookUrl"]);
            //_client = new RestClient(_uri.GetLeftPart(UriPartial.Authority));
            _webhookUrl = config["WebhookUrl"];
            _queue = queue;
        }
        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //Task.Run(() => WebhookSubmit("Hello, World")).ConfigureAwait(false);

            _queue.QueueBackgroundWorkItem(async token => {
                await WebhookSubmit(_webhookUrl, logLevel, eventId, exception, formatter(state, exception));
            });
            //Task.Run(() => WebhookSubmit(_client, logLevel, eventId, exception, formatter(state, exception))).ConfigureAwait(false);

            //Console.WriteLine($"[X]{formatter(state, exception)}");
            //This needs to be converted to async/nonblocking 
            //var request = new RestRequest(_uri.AbsolutePath, Method.POST);
            //request.AddJsonBody(new { 
            //    content = $"{formatter(state, exception)}"
            //});
            //_client.Execute(request);
        }

        private async Task WebhookSubmit(string url, LogLevel logLevel, EventId eventId, Exception exception, string message)
        {
            var uri = new Uri(url);
            var client = new RestClient(uri.GetLeftPart(UriPartial.Authority));
            client.UseSystemTextJson();

            var fields = new List<Field> {
                new Field {
                    Name = "Loglevel",
                    Value = logLevel.ToString()
                }
            };

            if(eventId.Id != 0)
            {
                fields.Add(new Field
                {
                    Name = "EventId",
                    Value = eventId.Id.ToString()
                });
                fields.Add(new Field
                {
                    Name = "EventName",
                    Value = eventId.Name
                });
            }

            if (exception != null)
            {
                fields.Add(new Field
                {
                    Name = "Exception",
                    Value = exception.Message
                });
            }

            var embeds = new List<Embed>
            {
                new Embed
                {
                    Title = System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace,
                    Description = DateTime.UtcNow.ToString("O"),
                    Color = GetColorFromLogLevel(logLevel),
                    Fields = fields
                }
            };

            var request = new Request()
            {
                Content = message,
                Embeds = embeds
            };

            var restRequest = new RestRequest(uri.AbsolutePath, Method.POST);
            restRequest.AddJsonBody(request);

            var response = await client.ExecuteAsync(restRequest);
            if (!response.IsSuccessful)
            {
                throw new Exception("Unsuccessful call to webhook");
            }
        }

        /// <summary>
        /// https://www.spycolor.com/
        /// </summary>
        /// <param name="loglevel"></param>
        /// <returns></returns>
        private int GetColorFromLogLevel(LogLevel loglevel)
        {
            switch (loglevel)
            {
                case LogLevel.Trace:
                    return 16777215;
                case LogLevel.Debug:
                    return 255;
                case LogLevel.Information:
                    return 16777215;
                case LogLevel.Warning:
                    return 16744192;
                case LogLevel.Error:
                    return 16733440;
                case LogLevel.Critical:
                    return 16711680;
                case LogLevel.None:
                    return 16777215;
            }
            return 16777215;
        }
    }
}
