using CTRL.Domain.Classes;
using CTRL.Domain.Classes.Contracts;
using CTRL.Domain.Interfaces;
using CTRL.Login.Enumerations;
using CTRL.Login.Interfaces;
using System.Collections.Generic;

namespace CTRL.Login
{
    public class LoginService : ILoginService
    {
        ILoginRepository loginRepository;
        IAuthorizationService authorizationService;
        IPasswordEncryption passwordEncryption;

        public LoginService(ILoginRepository loginRepository, IAuthorizationService authorizationService, IPasswordEncryption passwordEncryption)
        {
            this.loginRepository = loginRepository;
            this.authorizationService = authorizationService;
            this.passwordEncryption = passwordEncryption;
        }

        public UserProfile GetUser(LoginContract contract)
        {
            var user = loginRepository.GetUser(contract);
            if(passwordEncryption.CheckPassword(contract.Password, user.Password))
            {
                if (user.IsActive)
                {
                    user.Permissions = authorizationService.GetUserPermissions(user);
                }
            }
            else
            {
                return ResetUser();
            }

            return user;
        }

        private UserProfile ResetUser()
        {
            return new UserProfile()
            {
                LoginName = "Login Failed",
                Password = string.Empty,
                UserIdentifier = (int)decimal.Zero,
                Permissions = new List<Permission>()
            };
        }
    }
}
