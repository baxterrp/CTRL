using CTRL.Domain.Classes.Contracts;
using CTRL.Domain.Enumerations;
using CTRL.Login.Interfaces;
using System.Web.Mvc;

namespace CTRL.Web.Controllers
{
    public class HomeController : Controller
    {
        ILoginService loginService;
        IRegistrationService registrationService;

        public HomeController(ILoginService loginService, IRegistrationService registrationService)
        {
            this.loginService = loginService;
            this.registrationService = registrationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string TestLogin(LoginContract contract)
        {
            var user = loginService.GetUser(contract);

            switch (user.LoginStatus)
            {
                case LoginStatus.InvalidPassword:
                    return "Invalid password";
                case LoginStatus.UserNotFound:
                    return "No user found with that name";
                case LoginStatus.Success:
                    return user.IsActive ? "Logged In" : "Your account has been deactivated";
                default:
                    return "Something went wrong";
            }
        }

        public ActionResult Registration()
        {
            return View();
        }

        public string TestRegistration(BusinessEntityRegistrationContract contract)
        {
            registrationService.RegisterBusinessEntity(contract);
            return "got here";
        }
    }
}