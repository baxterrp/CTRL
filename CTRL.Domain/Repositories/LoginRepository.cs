using CTRL.Core.Interfaces;
using CTRL.Domain.Classes;
using CTRL.Domain.Classes.Contracts;
using CTRL.Domain.Constants;
using CTRL.Domain.Enumerations;
using CTRL.Domain.Interfaces;
using Dapper;
using System.Linq;

namespace CTRL.Domain.Repositories
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
