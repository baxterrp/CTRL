using CTRL.Domain.Classes.Contracts;
using CTRL.Login.Interfaces;
using System.Web.Mvc;

namespace CTRL.Web.Controllers
{
    public class HomeController : Controller
    {
        ILoginService loginService;

        public HomeController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string TestLogin(LoginContract contract)
        {
            var user = loginService.GetUser(contract);
            return user.IsActive ? "Logged In" : "Login Failed";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}