using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class RegisterLoginLogoutController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}
