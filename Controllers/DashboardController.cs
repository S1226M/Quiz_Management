using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    [CheckAccess]
    public class DashboardController : Controller
    {
        public IActionResult DashboardView()
        {
            return View();
        }
    }
}
