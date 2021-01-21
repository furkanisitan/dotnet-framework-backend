using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Aspects.Postsharp.SecurityAspects;
using Shop.Core.CrossCuttingConcerns.Security.Principal;
using System.Security;
using System.Threading;

namespace Shop.Business.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class AuthorizationAspectTests
    {
        [TestInitialize]
        public void Init()
        {
            var identity = new Identity
            {
                AuthenticationType = "Test",
                IsAuthenticated = true,
                FullName = "Furkan Işıtan",
                Id = 1,
                Name = "furkanisitan",
                Roles = new[] { "User" }
            };
            var principal = new CustomPrincipal(identity);
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        [ExpectedException(typeof(SecurityException))]
        [AuthorizationAspect("Admin")]
        public void Should_ThrowSecurityException_When_UserRolesNotContainsAdmin()
        {
            // ...
        }

    }
}
