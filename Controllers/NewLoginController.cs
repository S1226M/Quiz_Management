using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class NewLoginController : Controller
    {
        public IActionResult NewUserLogin()
        {
            return View();
        }
    }
}
