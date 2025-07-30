using Microsoft.Extensions.Logging;

public class MyLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new MyLogger();
    }

    public void Dispose() { }

    private class MyLogger : ILogger
    {
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (eventId.Id == 20100)
            {
                Console.WriteLine(formatter(state, exception));
            }
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}