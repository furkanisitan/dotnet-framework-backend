using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Aspects.Postsharp.PerformanceAspects;
using System.Threading;

namespace Shop.Business.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class PerformanceCounterAspectTests
    {

        [TestMethod]
        [PerformanceCounterAspect]
        public void Should_WarningOnDebugTrace_When_RunningTimeMoreThan5Seconds()
        {
            Thread.Sleep(5000);
            // check DebugTrace
        }
    }
}
