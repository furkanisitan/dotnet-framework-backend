using System;
using System.Linq;
using System.Security.Principal;

namespace Shop.Core.CrossCuttingConcerns.Security.Principal
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; }

        public int Id { get; }
        public string FullName { get; }
        public string[] Roles { get; }

        public CustomPrincipal(Identity identity)
        {
            Identity = identity;

            Id = identity.Id;
            FullName = identity.FullName;
            Roles = identity.Roles;
        }
        public bool IsInRole(string role) => Roles.Contains(role, StringComparer.OrdinalIgnoreCase);
    }
}
