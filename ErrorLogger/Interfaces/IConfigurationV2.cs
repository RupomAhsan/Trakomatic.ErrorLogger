using ErrorLogger.Models;

namespace ErrorLogger.Interfaces
{
    public interface IConfigurationV2
    {
        bool Write(LoggerConfig config);
    }
}
