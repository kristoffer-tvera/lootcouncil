using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Lootcouncil.Logging
{
    public class DiscordLoggerProvider : ILoggerProvider
    {
        private readonly IConfiguration _config;
        private readonly WebhookRequestQueue _queue;
        //private readonly IDisposable _onChangeToken;
        private readonly ConcurrentDictionary<string, DiscordLogger> _loggers = new();

        public DiscordLoggerProvider(IConfiguration config, WebhookRequestQueue queue)
        {
            _config = config;
            _queue = queue;
        }

        public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new DiscordLogger(_config, _queue));

        public void Dispose()
        {
            _loggers.Clear();
            //_onChangeToken.Dispose();
        }
    }
}
