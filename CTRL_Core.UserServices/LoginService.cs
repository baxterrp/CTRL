using CTRL_Core.Domain.Classes;
using CTRL_Core.Domain.Classes.Contracts;
using CTRL_Core.Domain.Enumerations;
using CTRL_Core.Domain.Interfaces;
using CTRL_Core.UserServices.Interfaces;

namespace CTRL_Core.UserServices
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
            if (!LoginStatus.UserNotFound.Equals(user.LoginStatus))
            {
                if (!string.IsNullOrEmpty(user.Password) && passwordEncryption.CheckPassword(contract.Password, user.Password))
                {
                    if (user.IsActive)
                    {
                        user.Permissions = authorizationService.GetUserPermissions(user);
                    }
                }
                else
                {
                    user.LoginStatus = LoginStatus.InvalidPassword;
                }
            }

            return user;
        }
    }
}
