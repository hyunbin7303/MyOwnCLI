using System;
using System.Collections.Generic;
using System.Text;

namespace HP_CLI
{
    public class UserProfile
    {
        public string Username { get; set; }
        public bool Staging { get; set; }
        public string Password { get; set; }
        public string OutputFormat  { get; set; }
    }
}
