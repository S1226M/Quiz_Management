using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using QuizeManagement.Models;

namespace QuizeManagement.Controllers
{
    public class UsersController : Controller
    {
        public IConfiguration configuration;

        public UsersController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        #region User List
        public IActionResult UsersView()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_User_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        #endregion User List

        #region UserAdd
        public IActionResult UserRegister(UserModel model)
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_User_Insert";
            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = model.UserName;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = model.Email;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = model.Password;
            command.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = model.Mobile;
            command.ExecuteNonQuery();
            return RedirectToAction("DashboardView");
        }
        #endregion UserAdd

    }
}
