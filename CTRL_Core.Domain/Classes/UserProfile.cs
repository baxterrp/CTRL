using CTRL_Core.Domain.Enumerations;
using System.Collections.Generic;

namespace CTRL_Core.Domain.Classes
{
    public class UserProfile
    {
        public LoginStatus LoginStatus { get; set; }

        public int UserIdentifier { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public IEnumerable<Permission> Permissions { get; set; }

        public bool IsActive { get; set; }
    }
}
