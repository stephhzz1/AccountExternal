using AccountExternalData;
using AccountExternalFunction;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ExternalAccountWebAuthentication.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ApiAuthorizationFilterAttribute : AuthorizeAttribute
    {
        private bool AllowAnonymous;
        private string[] AllowedRoles;

        private IDCredential _iDCredential;
        private IDRole _iDRole;
        private IFRole _iFRole;
        private IFCredential _iFCredential;

        public ApiAuthorizationFilterAttribute(bool allowAnonymous)
        {
            Initialise();
            AllowAnonymous = allowAnonymous;
            AllowedRoles = new string[0];
        }

        public ApiAuthorizationFilterAttribute(bool allowAnonymous, string[] allowedRoles)
        {
            Initialise();
            AllowAnonymous = allowAnonymous;
            AllowedRoles = allowedRoles;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            bool authorized = false;
            if (AllowAnonymous || (Claims.IsLoggedIn && AllowedRoles.Length == 0))
            {
                authorized = true;
            }
            else if (Claims.IsLoggedIn)
            {
                authorized = _iFRole.HasRole(Claims.CredentialId, AllowedRoles);
            }
            return authorized;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }

        private void Initialise()
        {
            _iDCredential = new DCredential();
            _iFCredential = new FCredential(_iDCredential);
            _iDRole = new DRole();
            _iFRole = new FRole(_iDRole);
        }
    }
}
