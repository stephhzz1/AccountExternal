using ExternalAccountWebAuthentication.Authentication;
using ExternalAccountWebAuthentication.Controller;

namespace AccountExternalWeb.Controllers
{
    [MvcAuthorizationFilterAttribute(false, "Credential", "Login", new string[] { "ExternalAccountAdministrator" })]
    public class BaseController : ExternalAccountBaseController
    {
    }
}