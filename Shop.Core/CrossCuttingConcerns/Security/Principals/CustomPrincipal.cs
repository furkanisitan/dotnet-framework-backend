using System;
using System.Linq;
using System.Security.Principal;

namespace Shop.Core.CrossCuttingConcerns.Security.Principals
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        public CustomPrincipal(string username, CustomPrincipalSerializedModel serializedModel)
        {
            Identity = new GenericIdentity(username);
            Id = serializedModel.Id;
            FirstName = serializedModel.FirstName;
            LastName = serializedModel.LastName;
            Roles = serializedModel.Roles;
        }

        public bool IsInRole(string role) =>
             Identity != null &&
             Identity.IsAuthenticated &&
             !string.IsNullOrWhiteSpace(role) &&
             Roles.Contains(role, StringComparer.OrdinalIgnoreCase);

        public IIdentity Identity { get; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
    }
}
