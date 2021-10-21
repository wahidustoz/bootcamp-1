using Microsoft.Extensions.Logging;

namespace lesson12
{
    public class LoggerWriter : IMessageWriter
    {
        private readonly ILogger<LoggerWriter> _logger;

        public LoggerWriter(ILogger<LoggerWriter> logger)
        {
            _logger = logger;
        }

        public void Write(string message)
        {
            _logger.LogError(message);
        }
    }
}