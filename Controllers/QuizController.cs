using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult QuizeAdd()
        {
            return View();
        }
        public IActionResult QuizList()
        {
            return View();
        }
    }
}
