using CTRL.Core.Interfaces;
using CTRL.Domain.Classes;
using CTRL.Domain.Constants;
using CTRL.Domain.Interfaces;
using CTRL.Login.Enumerations;
using Dapper;
using System.Collections.Generic;

namespace CTRL.Domain.Repositories
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        IRepository repository;

        public AuthorizationRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Permission> GetAllUserPermissions(UserProfile user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userid", user.UserIdentifier);

            var permissions = repository.ExecuteStoredProcedureQuery<int>(DomainStoredProcedures.GetAllUserPermissions, parameters);
            var userPermissions = new List<Permission>();

            foreach(var permission in permissions)
            {
                userPermissions.Add((Permission)permission);
            }

            return userPermissions;
        }
    }
}
