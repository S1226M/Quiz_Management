using System.Data;
using System.Data.SqlClient;
using System.Reflection;
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

        #region User Register
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
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

                return RedirectToAction("DashboardView", "Dashboard");
            }
            return View("Register");
        }

        #endregion User Register

        #region User Edit
        public IActionResult QuizAddEdit(int UserID)
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand command = Connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_User_SelectByID";
            command.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(reader);
            QuizModel model = new QuizModel();
            foreach (DataRow row in datatable.Rows)
            {
                model.QuizName = @row["QuizName"].ToString();
                model.TotalQuestions = Convert.ToInt32(@row["TotalQuestions"]);
                model.QuizDate = Convert.ToDateTime(@row["QuizDate"]);
                model.UserID = Convert.ToInt32(@row["UserID"]);
            }
            return View("QuizAddEdit", model);
        }
        #endregion Quiz Edit

        #region User Delete
        public IActionResult UserDelete(int UserID)
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand Command = connection.CreateCommand();
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = "PR_MST_User_Delete";
            Command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            Command.ExecuteNonQuery();
            return RedirectToAction("UsersView");
        }
        #endregion User Delete

        //#region User Login
        //public IActionResult Login(UserModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            string connectionString = configuration.GetConnectionString("ConnectionString");
        //            SqlConnection sqlConnection = new SqlConnection(connectionString);
        //            sqlConnection.Open();
        //            SqlCommand command = sqlConnection.CreateCommand();
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "PR_MST_User_Login";
        //            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = model.UserName;
        //            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = model.Password;
        //            SqlDataReader sqlDataReader = command.ExecuteReader();
        //            DataTable dataTable = new DataTable();
        //            dataTable.Load(sqlDataReader);
        //            if (dataTable.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dataTable.Rows)
        //                {
        //                    HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
        //                    HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
        //                }
        //                return RedirectToAction("DashboardView", "Dashboard");
        //            }
        //            else
        //            {
        //                return RedirectToAction("Login", "Users");
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    return View("Login");
        //}
        //#endregion User Login


    }
}
