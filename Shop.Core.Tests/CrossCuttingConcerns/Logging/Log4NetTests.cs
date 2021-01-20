using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Shop.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.IO;
using System.Linq;

namespace Shop.Core.Tests.CrossCuttingConcerns.Logging
{
    [TestClass]
    public class Log4NetTests
    {
        [TestMethod]
        public void Test_JsonFileLogger()
        {
            // log4net.config -> JsonFileAppender
            var path = "log-file.json";
            // Shop.Core.CrossCuttingConcerns.Logging.Log4Net.SerializableLoggingEvent
            var messageKey = "MessageObject";
            var logMessage = "This is a info log";

            File.Delete(path);

            var logger = new JsonFileLogger();
            logger.Info(logMessage);

            var line = File.ReadLines(path).First();
            var message = JObject.Parse(line)[messageKey];

            Assert.AreEqual(logMessage, message);
        }

        [TestMethod]
        public void Test_MsSqlLogger()
        {
            var logMessage = "This is a info log";
            var logger = new MsSqlLogger();
            logger.Info(logMessage);

            // check ShopLogTest database
        }
    }
}
