using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class QuestionLevelController : Controller
    {
        public IActionResult QuestionLevelList()
        {
            return View();
        }
        public IActionResult QuestionLevelAdd()
        {
            return View();
        }
    }
}
