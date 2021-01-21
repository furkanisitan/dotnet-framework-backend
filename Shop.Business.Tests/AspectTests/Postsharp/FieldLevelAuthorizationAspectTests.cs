using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Aspects.Postsharp.SecurityAspects;
using Shop.Business.FieldLevelAuthorizationRules.FluentValidation;
using Shop.Business.Tests.Db.EntityFramework.Configuration;
using Shop.Core.CrossCuttingConcerns.Security.Principal;
using Shop.Entities.Concrete;
using System.Linq;
using System.Security;
using System.Threading;

namespace Shop.Business.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class FieldLevelAuthorizationAspectTests
    {
        private ShopBusinessTestContext _context;

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

            _context = new ShopBusinessTestContext();
        }

        [TestMethod]
        [ExpectedException(typeof(SecurityException))]
        public void Should_ThrowSecurityException_When_UserRolesNotContainsAdmin()
        {
            var category = _context.Categories.SingleOrDefault(x => x.Name == "category1") ??
                           _context.Categories.Add(new Category { Name = "category1" });
            _context.SaveChanges();
            UpdateCategory(category);
        }

        [FieldLevelAuthorizationAspect(typeof(CategoryFlaValidator), "update")]
        public void UpdateCategory(Category category)
        {
            // ...
        }
    }
}