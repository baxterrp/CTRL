using CTRL_Core.Domain.Classes;
using CTRL_Core.Domain.Enumerations;
using System.Collections.Generic;

namespace CTRL_Core.UserServices.Interfaces
{
    public interface IAuthorizationService
    {
        IEnumerable<Permission> GetUserPermissions(UserProfile user);
    }
}
