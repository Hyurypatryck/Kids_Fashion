using KidsFashion.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidsFashion.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var vm = new LoginViewModel();

            return View("Login", vm);
        }
    }
}
