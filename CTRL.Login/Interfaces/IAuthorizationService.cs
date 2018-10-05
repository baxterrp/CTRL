using CTRL.Domain.Classes;
using CTRL.Login.Enumerations;
using System.Collections.Generic;

namespace CTRL.Login.Interfaces
{
    public interface IAuthorizationService
    {
        IEnumerable<Permission> GetUserPermissions(UserProfile user);
    }
}
