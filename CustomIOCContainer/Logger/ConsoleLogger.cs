using CustomIOCContainer.Interfaces;

namespace CustomIOCContainer.Logger
{
    public class ConsoleLogger : IConsoleLogger
    {
        private readonly ILogger _logger;

        public ConsoleLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void DisplayMessage(string message)
        {
            _logger.Log(message);
        }
    }
}