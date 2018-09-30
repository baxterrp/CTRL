using CTRL.Login.Enumerations;
using System.Collections.Generic;

namespace CTRL.Domain.Classes
{
    public class UserProfile
    {
        public int UserIdentifier { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public IEnumerable<Permission> Permissions { get; set; }

        public bool IsActive {
            get
            {
                return UserIdentifier > 0;
            }
        }
    }
}
