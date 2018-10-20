using CTRL_Core.Backbone.Interfaces;
using CTRL_Core.Domain.Classes;
using CTRL_Core.Domain.Constants;
using CTRL_Core.Domain.Interfaces;
using CTRL_Core.Login.Enumerations;
using Dapper;
using System.Collections.Generic;

namespace CTRL_Core.Domain.Repositories
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
