using System;
using System.Collections.Generic;

namespace JiraBackSync.Data
{
    public class LoginForm
    {
        public Uri Location { get; set; }

        public IDictionary<string, string> Fields { get; set; }
    }
}