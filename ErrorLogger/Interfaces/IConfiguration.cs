using ErrorLogger.Models;

namespace ErrorLogger.Interfaces
{
    public interface IConfiguration
    {
        LoggerConfig Read();
        bool Write(LoggerConfig config);
    }
}
