using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    [CheckAccess]
    public class UserProfileController : Controller
    {
        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult UserFAQ()
        {
            return View();
        }
    }
}
