using System.Net;

namespace JiraBackSync.Data
{
    public class LoginPrerequisites
    {
        public CookieCollection Cookies { get; set; }

        public string SrvKey { get; set; }

        public string SignIn { get; set; }
    }
}