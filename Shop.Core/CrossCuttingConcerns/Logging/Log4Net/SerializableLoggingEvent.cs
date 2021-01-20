using log4net.Core;
using Newtonsoft.Json;
using System;

namespace Shop.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    class SerializableLoggingEvent
    {
        private readonly LoggingEvent _loggingEvent;

        public object TimeStamp => _loggingEvent.TimeStamp;
        public object MessageObject => _loggingEvent.MessageObject;
        public object Level => _loggingEvent.Level.Name;
        public object Identity => _loggingEvent.Identity;
        public object LoggerName => _loggingEvent.LoggerName;
        public string UserName => _loggingEvent.UserName;

        public SerializableLoggingEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
    }
}
