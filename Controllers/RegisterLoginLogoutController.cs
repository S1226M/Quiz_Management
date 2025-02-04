using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class RegisterLoginLogoutController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
