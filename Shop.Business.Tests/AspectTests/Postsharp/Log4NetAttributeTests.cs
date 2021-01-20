using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Aspects.Postsharp.LogAspects;
using Shop.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Shop.Business.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class Log4NetAttributeTests
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

        [Log4Net(typeof(MsSqlLogger))]
        private string InstanceMethodWithoutParameter()
        {
            return "Hello World!";
        }

        [Log4Net(typeof(MsSqlLogger))]
        private string InstanceMethodWithParameter(string message)
        {
            return message;
        }
    }
}
