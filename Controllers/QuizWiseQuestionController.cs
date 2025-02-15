using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace QuizeManagement.Controllers
{
    public class QuizWiseQuestionController : Controller
    {
        public IConfiguration configuration;
        public QuizWiseQuestionController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        //public IActionResult QuizWiseQuestionList()
        //{
        //    return View();
        //}

        #region Quiz Wise Question List
        public IActionResult QuizWiseQuestionList()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_QuizWiseQuestions_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        #endregion Quiz List


        public IActionResult QuizWiseQuestionAdd()
        {
            return View();
        }
    }
}
