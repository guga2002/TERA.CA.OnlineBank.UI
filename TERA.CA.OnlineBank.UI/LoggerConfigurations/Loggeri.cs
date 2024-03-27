
using MongoDB.Bson;
using TERA.CA.OnlineBank.Core.Data;

namespace TERA.CA.OnlineBank.UI.LoggerConfigurations
{
    public class Loggeri : ILogger
    {
        private readonly MongoLoggerDb logs;

        public Loggeri()
        {
            logs = new MongoLoggerDb();
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (logLevel == LogLevel.Error || logLevel == LogLevel.Critical || logLevel == LogLevel.Information)
            {
                if (logLevel == LogLevel.Information || logLevel == LogLevel.Error || logLevel == LogLevel.Critical)
                {
                    var doc = new BsonDocument
                   {
                   { "LogLevel", logLevel.ToString() },
                   { "Message", formatter(state, exception) }
                     };
                    logs.Logs.InsertOne(doc);
                }
            }
        }
    }
}
