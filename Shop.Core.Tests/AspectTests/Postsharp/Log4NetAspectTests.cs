using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core.Aspects.Postsharp.LogAspects;
using Shop.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Shop.Core.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class Log4NetAspectTests
    {
        [TestMethod]
        public void TestInstanceMethodWithoutParameter()
        {
            InstanceMethodWithoutParameter();
            // check ShopLogTest database
        }

        [TestMethod]
        public void TestInstanceMethodWithParameter()
        {
            InstanceMethodWithParameter("Hello World!");
            // check ShopLogTest database
        }

        [Log4NetAspect(typeof(MsSqlLogger))]
        private string InstanceMethodWithoutParameter()
        {
            return "Hello World!";
        }

        [Log4NetAspect(typeof(MsSqlLogger))]
        private string InstanceMethodWithParameter(string message)
        {
            return message;
        }
    }
}
