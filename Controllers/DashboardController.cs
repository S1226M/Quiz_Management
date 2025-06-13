using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        #endregion Quiz List

    }
}
