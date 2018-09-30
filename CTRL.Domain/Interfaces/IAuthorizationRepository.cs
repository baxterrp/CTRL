using CTRL.Domain.Classes;
using CTRL.Login.Enumerations;
using System.Collections.Generic;

namespace CTRL.Domain.Interfaces
{
    public interface IAuthorizationRepository
    {
        IEnumerable<Permission> GetAllUserPermissions(UserProfile user);
    }
}
