using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class QuizController : Controller
    {
        public IConfiguration configuration;
        public QuizController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult QuizList()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_Quiz_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        public IActionResult QuizeAdd()
        {
            return View();
        }
    }
}
