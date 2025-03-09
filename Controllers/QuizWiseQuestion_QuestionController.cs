using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace QuizeManagement.Controllers
{
    public class QuizWiseQuestion_QuestionController : Controller
    {
        public IConfiguration configuration;
        public QuizWiseQuestion_QuestionController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        #region Question List
        public IActionResult QuizWiseQuestionQuestionList(int QuizID)
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_QuizWiseQuestions_SelectByID";
            command.Parameters.AddWithValue("@QuizID", QuizID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        #endregion Question List

        #region Question Add
        public IActionResult QuestionAddInQuiz(int QuizID)
        {
            ViewBag.QuizID = QuizID;
            return RedirectToAction("QuizWiseQuestionEdit", "QuizWiseQuestion", new { QuizWiseQuestionsID = QuizID });
        }

        #endregion Question Add
    }
}
