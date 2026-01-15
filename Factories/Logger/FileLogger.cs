using Serilog;

namespace learn.Factories.Logger;
public class FileLogger : ILogger
{

  private readonly Serilog.ILogger _logger;

  public FileLogger()
  {
    _logger=new LoggerConfiguration()
      .MinimumLevel.Debug() // log all levels >= Debug
      .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) // new file per day
      .CreateLogger();
  }
  
  public void LogWarning(string message)
  {
    _logger.Warning(message);
  }

  public void LogError(string message)
  {
    _logger.Error(message);
  }

  public void LogInfo(string message)
  {
    _logger.Information(message);
  }
}
