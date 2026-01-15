namespace learn.Factories.Logger;

public class LocalLoggerFactory
{
  
  public static ILogger CreateLogger(LoggerTypes loggerType)
  {

    return loggerType switch
    {
      LoggerTypes.File => new FileLogger(),
      _ => throw new ArgumentException("Invalid logger type")
    };
    
  }
}
