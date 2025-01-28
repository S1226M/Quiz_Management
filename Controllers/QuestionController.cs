using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult QuestionAdd()
        {
            return View();
        }
        public IActionResult QuestionList()
        {
            return View();
        }
    }
}
