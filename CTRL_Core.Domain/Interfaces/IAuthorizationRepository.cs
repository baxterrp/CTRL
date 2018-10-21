using CTRL_Core.Domain.Classes;
using CTRL_Core.Domain.Enumerations;
using System.Collections.Generic;

namespace CTRL_Core.Domain.Interfaces
{
    public interface IAuthorizationRepository
    {
        IEnumerable<Permission> GetAllUserPermissions(UserProfile user);
    }
}
