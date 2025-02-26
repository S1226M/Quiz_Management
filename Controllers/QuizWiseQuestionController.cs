using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using static QuizeManagement.Models.QuizWiseQuestionModel;
using Microsoft.Extensions.Configuration;
using System.Reflection;

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


        #region Quiz Wise Question Add
        public IActionResult QuizWiseQuestionAdd()
        {
            return View();
        }
        #endregion Quiz Wise Question Add

        #region Temporary Quiz Wise Question Add
        public IActionResult QuizWiseQuestionAddTemp()
        {
            if (ModelState.IsValid)
            {
                //QuizUserDropDown();
                string connectionString = configuration.GetConnectionString("ConnectionString");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (model.QuizWiseQuestionID == 0)
                {
                    command.CommandText = "PR_MST_QuizWiseQuestions_Insert";
                }
                else
                {
                    command.CommandText = "PR_MST_QuizWiseQuestions_Update";
                    command.Parameters.Add("@QuizWiseQuestionID", SqlDbType.Int).Value = model.QuizWiseQuestionID;
                }
                command.Parameters.Add("@QuizID", SqlDbType.Int).Value = model.QuizID;
                command.Parameters.Add("@QuestionID", SqlDbType.Int).Value = model.QuestionID;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = model.UserID;
                command.ExecuteNonQuery();
                return RedirectToAction("QuizWiseQuestionList");
            }
            //QuizUserDropDown();
            return View("QuizWiseQuestionAddTemp", model);
        }
        #endregion Temporary Quiz Wise Question Add
    }
}
