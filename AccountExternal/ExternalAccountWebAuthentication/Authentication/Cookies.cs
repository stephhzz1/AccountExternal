using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace ExternalAccountWebAuthentication.Authentication
{
    public static class Cookies
    {
        public static bool IsLoggedIn => CredentialCookies != null;

        public static int CredentialId
        {
            get
            {
                int returnInt = 0;

                if (CredentialCookies != null)
                {
                    string encryptedId = CredentialCookies["CredentialId"];
                    string id = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(encryptedId)));
                    returnInt = Convert.ToInt32(id);
                }
                return returnInt;
            }
        }

        public static HttpCookie CredentialCookies
        {
            get
            {
                HttpCookie credentialCookies = HttpContext.Current.Request.Cookies["Credential"];
                return credentialCookies;
            }
        }

        public static string Username
        {
            get
            {
                string returnString = string.Empty;

                if (CredentialCookies != null)
                {
                    string encryptedUsername = CredentialCookies["Username"];
                    string username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(encryptedUsername)));
                    returnString = username;
                }

                return returnString;
            }
        }
    }
}
