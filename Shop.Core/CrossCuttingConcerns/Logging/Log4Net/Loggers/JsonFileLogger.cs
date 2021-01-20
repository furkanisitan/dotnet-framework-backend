using log4net;

namespace Shop.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class JsonFileLogger : SerializableAbstractLogger
    {
        public JsonFileLogger() : base(LogManager.GetLogger("JsonFileLogger")) { }
    }
}
