using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Linq;
using System.Security;
using System.Threading;

namespace Shop.Business.Aspects.Postsharp.SecurityAspects
{
    /// <summary>
    /// Checks the authorization to run the method body.
    /// </summary>
    [PSerializable]
    public class AuthorizationAspect : OnMethodBoundaryAspect
    {
        private string[] _roles;

        public AuthorizationAspect(params string[] roles)
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
