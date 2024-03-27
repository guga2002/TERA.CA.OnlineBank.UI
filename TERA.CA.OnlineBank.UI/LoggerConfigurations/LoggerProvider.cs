namespace TERA.CA.OnlineBank.UI.LoggerConfigurations
{
    public class LoggerProvider : ILoggerProvider
    {

        public ILogger CreateLogger(string categoryName)
        {
            return new Loggeri();
        }

        public void Dispose()
        {
            return;
        }
    }
}
