using System;
using System.Security.Claims;
using System.Web;

namespace ExternalAccountWebAuthentication.Authentication
{
    public static class Claims
    {
        public static bool IsLoggedIn => ClaimsIdentity.FindFirst("CredentialId") != null;

        public static ClaimsIdentity ClaimsIdentity
        {
            get
            {
                var httpContext = HttpContext.Current;
                ClaimsIdentity claimsIdentity = null;
                if (httpContext.User.Identity is ClaimsIdentity)
                {
                    claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
                }
                return claimsIdentity;
            }
        }

        public static int CredentialId
        {
            get
            {
                int returnInt = 0;

                if (ClaimsIdentity.FindFirst("CredentialId") != null)
                    returnInt = Convert.ToInt32(ClaimsIdentity.FindFirst("CredentialId").Value);

                return returnInt;
            }
        }

        public static string Username
        {
            get
            {
                string returnString = string.Empty;

                if (ClaimsIdentity.FindFirst("Username") != null)
                    returnString = ClaimsIdentity.FindFirst("Username").Value;

                return returnString;
            }
        }
    }
}
