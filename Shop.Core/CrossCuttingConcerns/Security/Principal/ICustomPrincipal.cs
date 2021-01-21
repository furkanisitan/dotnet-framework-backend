using System.Security.Principal;

namespace Shop.Core.CrossCuttingConcerns.Security.Principal
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; }
        string FullName { get; }
        string[] Roles { get; }
    }
}
