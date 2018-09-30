using CTRL.Domain.Classes;
using CTRL.Domain.Interfaces;
using System.Web.Mvc;

namespace CTRL.Web.Controllers
{
    public class HomeController : Controller
    {
        ILoginRepository repository;

        public HomeController(ILoginRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string TestLogin(LoginContract contract)
        {
            var user = repository.GetUser(contract);
            return user.IsActive ? "Success" : "Login Failed. Try Again.";
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