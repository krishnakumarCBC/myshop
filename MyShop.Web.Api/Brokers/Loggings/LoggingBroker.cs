using System;

namespace MyShop.Web.Api.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;

        public LoggingBroker(ILogger<LoggingBroker> loggre)
        {
            this.logger = loggre;
        }
        public void LogCritical(Exception exception)
        {
            this.logger.LogCritical(exception,exception.Message);
        }

        public void LogDebug(string message)
        {
            this.logger.LogDebug(message);
        }

        public void LogError(Exception exception)
        {
            this.logger.LogError(exception, exception.Message);
        }

        public void LogInformation(string message)
        {
            this.logger.LogInformation(message);
        }

        public void LogTrace(string message)
        {
            this.logger.LogTrace(message);
        }

        public void LogWarning(Exception exception)
        {
            this.logger.LogWarning(exception, exception.Message);
        }
    }
}
