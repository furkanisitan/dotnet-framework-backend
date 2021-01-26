using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core.Aspects.Postsharp.SecurityAspects;
using Shop.Core.CrossCuttingConcerns.Security.Principals;
using System.Security;
using System.Threading;

namespace Shop.Core.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class AuthorizeAspectTests
    {
        [TestInitialize]
        public void Init()
        {
            var serializedModel = new CustomPrincipalSerializedModel
            {
                Id = 1,
                FirstName = "Furkan",
                LastName = "Işıtan",
                Roles = new[] { "User" }
            };

            var principal = new CustomPrincipal("furkanisitan", serializedModel);
            Thread.CurrentPrincipal = principal;
        }

        [TestMethod]
        [ExpectedException(typeof(SecurityException))]
        [AuthorizeAspect("Admin")]
        public void Should_ThrowSecurityException_When_UserRolesNotContainsAdmin()
        {
            // ...
        }

    }
}
