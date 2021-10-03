using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace Lootcouncil.Logging
{
    public class DiscordLoggerProvider : ILoggerProvider
    {
        private readonly IConfiguration _config;
        private readonly IDisposable _onChangeToken;
        private readonly ConcurrentDictionary<string, DiscordLogger> _loggers = new();

        public DiscordLoggerProvider(IConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new DiscordLogger(_config));

        public void Dispose()
        {
            _loggers.Clear();
            _onChangeToken.Dispose();
        }
    }
}
