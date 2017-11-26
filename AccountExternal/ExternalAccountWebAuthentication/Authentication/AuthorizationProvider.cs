using AccountExternalData;
using AccountExternalFunction;
using AccountExternalModel;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExternalAccountWebAuthentication.Authentication
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private IDCredential _iDCredential;
        private IDCredentialRole _iDCredentialRole;
        private IFCredentialRole _iFCredentialRole;
        private IFCredential _iFCredential;

        public AuthorizationProvider()
        {
            _iDCredential = new DCredential();
            _iFCredential = new FCredential(_iDCredential);
            _iDCredentialRole = new DCredentialRole();
            _iFCredentialRole = new FCredentialRole(_iDCredentialRole);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            Credential credential = new Credential();
            credential.Username = context.UserName;
            credential.Password = context.Password;

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            credential = _iFCredential.Login(credential);
            bool isLoggedIn = credential.CredentialId != 0;
            if (isLoggedIn)
            {
                identity.AddClaim(new Claim("Username", context.UserName));
                identity.AddClaim(new Claim("CredentialId", credential.CredentialId.ToString()));
                context.Validated(identity);
            }
        }

    }
}
