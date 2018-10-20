using CTRL_Core.Domain.Classes;
using CTRL_Core.Login.Enumerations;
using System.Collections.Generic;

namespace CTRL_Core.Login.Interfaces
{
    public interface IAuthorizationService
    {
        IEnumerable<Permission> GetUserPermissions(UserProfile user);
    }
}
