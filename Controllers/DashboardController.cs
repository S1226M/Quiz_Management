using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using QuizeManagement.Models;

namespace QuizeManagement.Controllers
{
    //[CheckAccess]
    public class DashboardController : Controller
    {
        public IConfiguration configuration;
        public DashboardController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        #region QuestionCount List
        public IActionResult DashboardView()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_Question_SelectByLevel";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        #endregion Quiz List

        public IActionResult DashboardQuestionByTheirLevel(int ID)
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Display_Question_Of_That_Level";
            command.Parameters.AddWithValue("@QuestionLevelID", ID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(reader);
            DashboardModel model = new DashboardModel();
            foreach (DataRow row in datatable.Rows)
            {
                model.ID = Convert.ToInt32(@row["QuestionID"]);
                model.QuestionText = @row["QuestionText"].ToString();
                model.OptionA = @row["OptionA"].ToString();
                model.OptionB = @row["OptionB"].ToString();
                model.OptionC = @row["OptionC"].ToString();
                model.OptionD = @row["OptionD"].ToString();
                model.QuestionLevel = @row["QuestionLevel"].ToString();
                model.QuestionMarks = Convert.ToInt32(@row["QuestionMarks"]);
                model.CorrectOption = @row["CorrectOption"].ToString();
            }
            return View(model);
        }
    }
}
