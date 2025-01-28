using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class QuizWiseQuestionController : Controller
    {
        public IActionResult QuizWiseQuestionList()
        {
            return View();
        }
    }
}
