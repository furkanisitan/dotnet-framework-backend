using log4net;

namespace Shop.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class MsSqlLogger : SerializableAbstractLogger
    {
        public MsSqlLogger() : base(LogManager.GetLogger("MsSqlLogger")) { }
    }
}
