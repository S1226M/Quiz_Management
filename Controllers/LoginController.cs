using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginUser()
        {
            return View();
        }
    }
}
