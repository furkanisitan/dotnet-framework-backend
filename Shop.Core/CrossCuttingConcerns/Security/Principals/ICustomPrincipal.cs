using System.Security.Principal;

namespace Shop.Core.CrossCuttingConcerns.Security.Principals
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string[] Roles { get; set; }
    }
}
