using log4net;
using System;

namespace Shop.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public abstract class SerializableAbstractLogger
    {
        private readonly ILog _log;

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        protected SerializableAbstractLogger(ILog log)
        {
            _log = log;
        }

        public void Info(object message)
        {
            if (IsInfoEnabled) _log.Info(message);
        }

        public void Debug(object message)
        {
            if (IsDebugEnabled) _log.Debug(message);
        }

        public void Warn(object message)
        {
            if (IsWarnEnabled) _log.Warn(message);
        }

        public void Fatal(object message)
        {
            if (IsFatalEnabled) _log.Fatal(message);
        }

        public void Error(object message)
        {
            if (IsErrorEnabled) _log.Error(message);
        }

    }
}
