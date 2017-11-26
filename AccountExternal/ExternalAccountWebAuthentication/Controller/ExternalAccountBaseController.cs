using ExternalAccountWebAuthentication.Authentication;
using System.Web;

namespace ExternalAccountWebAuthentication.Controller
{
    public class ExternalAccountBaseController : System.Web.Mvc.Controller
    {
        private HttpCookie HttpCookie
        {
            get
            {
                return Cookies.CredentialCookies;
            }
        }

        protected int CredentialId
        {
            get
            {
                return Cookies.CredentialId;
            }
        }
    }
}
