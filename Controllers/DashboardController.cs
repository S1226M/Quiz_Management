using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using QuizeManagement.Models;

namespace QuizeManagement.Controllers
{
    [CheckAccess]
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

            List<DashboardModel> modelList = new List<DashboardModel>();

            foreach (DataRow row in datatable.Rows)
            {
                DashboardModel model = new DashboardModel
                {
                    ID = Convert.ToInt32(row["QuestionID"]),
                    QuestionText = row["QuestionText"].ToString(),
                    OptionA = row["OptionA"].ToString(),
                    OptionB = row["OptionB"].ToString(),
                    OptionC = row["OptionC"].ToString(),
                    OptionD = row["OptionD"].ToString(),
                    QuestionLevel = row["QuestionLevel"].ToString(),
                    QuestionMarks = Convert.ToInt32(row["QuestionMarks"]),
                    CorrectOption = row["CorrectOption"].ToString()
                };
                modelList.Add(model);
            }
            return View(modelList);
        }
    }
}