using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Linq;
using System.Security;
using System.Threading;

namespace Shop.Core.Aspects.Postsharp.SecurityAspects
{
    /// <summary>
    /// Checks the authorization to run the method body.
    /// </summary>
    [PSerializable]
    public class AuthorizeAspect : OnMethodBoundaryAspect
    {
        private string[] _roles;

        public AuthorizeAspect(params string[] roles)
        {
            _roles = roles;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (_roles.All(x => !Thread.CurrentPrincipal.IsInRole(x)))
                throw new SecurityException("You are not authorized!");
        }
    }
}
