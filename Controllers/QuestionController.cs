using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace QuizeManagement.Controllers
{
    public class QuestionController : Controller
    {
        public IConfiguration configuration;

        public QuestionController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult QuestionAdd()
        {
            return View();
        }
        public IActionResult QuestionList()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_Question_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
    }
}
