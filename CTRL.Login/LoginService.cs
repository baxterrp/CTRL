using CTRL.Domain.Classes;
using CTRL.Domain.Classes.Contracts;
using CTRL.Domain.Interfaces;
using CTRL.Login.Interfaces;

namespace CTRL.Login
{
    public class LoginService : ILoginService
    {
        ILoginRepository loginRepository;
        IAuthorizationService authorizationService;

        public LoginService(ILoginRepository loginRepository, IAuthorizationService authorizationService)
        {
            this.loginRepository = loginRepository;
            this.authorizationService = authorizationService;
        }

        public UserProfile GetUser(LoginContract contract)
        {
            var user = loginRepository.GetUser(contract);
            if (user.IsActive)
            {
                user.Permissions = authorizationService.GetUserPermissions(user);
            }

            return user;
        }
    }
}
