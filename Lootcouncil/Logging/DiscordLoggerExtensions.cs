using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Lootcouncil.Logging
{
    public static class DiscordLoggerExtensions
    {
        public static ILoggingBuilder AddDiscordLogger(this ILoggingBuilder builder)
        {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, DiscordLoggerProvider>());

            return builder;
        }
    }
}
