using CTRL_Core.Domain.Classes;
using CTRL_Core.Domain.Enumerations;
using CTRL_Core.Domain.Interfaces;
using CTRL_Core.UserServices.Interfaces;
using System.Collections.Generic;

namespace CTRL_Core.UserServices
{
    public class AuthorizationService : IAuthorizationService
    {
        IAuthorizationRepository repository;

        public AuthorizationService(IAuthorizationRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Permission> GetUserPermissions(UserProfile user)
        {
            var permissions = repository.GetAllUserPermissions(user);

            return permissions;
        }
    }
}
