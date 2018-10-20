using CTRL_Core.Backbone.Interfaces;
using CTRL_Core.Domain.Classes;
using CTRL_Core.Domain.Classes.Contracts;
using CTRL_Core.Domain.Constants;
using CTRL_Core.Domain.Enumerations;
using CTRL_Core.Domain.Interfaces;
using Dapper;
using System.Linq;

namespace CTRL_Core.Domain.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        IRepository _repository;

        public LoginRepository(IRepository repository)
        {
            _repository = repository;
        }

        public UserProfile GetUser(LoginContract contract)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@username", contract.UserName);
            parameters.Add("@password", contract.Password);

            var user = _repository.ExecuteStoredProcedureQuery<UserProfile>(DomainStoredProcedures.GetUserByLoginContract, parameters)
                .FirstOrDefault() ?? new UserProfile() { LoginStatus = LoginStatus.UserNotFound };

            if (!string.IsNullOrEmpty(user.LoginName))
            {
                user.LoginStatus = LoginStatus.Success;
            }

            return user;
        }
    }
}
