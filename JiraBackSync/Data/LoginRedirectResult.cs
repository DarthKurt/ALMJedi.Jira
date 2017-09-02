using System;
using System.Net;

namespace JiraBackSync.Data
{
    public class LoginRedirectResult
    {
        public Uri Location { get; set; }

        public CookieCollection Cookies { get; set; }
    }
}