using CTRL.Domain.Classes;
using CTRL.Domain.Interfaces;
using CTRL.Login.Enumerations;
using CTRL.Login.Interfaces;
using System.Collections.Generic;

namespace CTRL.Login
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
