using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;

namespace Lootcouncil.Logging
{
    public class DiscordLogger : ILogger
    {
        private readonly RestClient _client;
        private readonly Uri _uri;
        public DiscordLogger(IConfiguration config)
        {
            _uri = new Uri(config["WebhookUrl"]);
            _client = new RestClient(_uri.GetLeftPart(UriPartial.Authority));
        }
        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

            //This needs to be converted to async/nonblocking 
            var request = new RestRequest(_uri.AbsolutePath, Method.POST);
            request.AddJsonBody(new { 
                content = $"{formatter(state, exception)}"
            });
            _client.Execute(request);
        }
    }
}
