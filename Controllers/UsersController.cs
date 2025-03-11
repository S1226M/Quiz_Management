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

        #region Register View
        public IActionResult Register()
        {
            return View();
        }
        #endregion Register View


        #region Register User View----------
        public IActionResult RegisterUser(UserModel model)
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
        #endregion Register User View----------

        //#region User Register
        //public IActionResult Register(UserModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string connectionString = configuration.GetConnectionString("ConnectionString");
        //        SqlConnection sqlConnection = new SqlConnection(connectionString);
        //        sqlConnection.Open();
        //        SqlCommand command = sqlConnection.CreateCommand();
        //        command.CommandType = CommandType.StoredProcedure;

        //        if (model.UserID == 0)
        //        {
        //            command.CommandText = "PR_MST_User_Insert";
        //        }
        //        else
        //        {
        //            command.CommandText = "PR_MST_User_Update";
        //            command.Parameters.Add("@UserID", SqlDbType.Int).Value = model.UserID;
        //        }

                
        //        command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = model.UserName;
        //        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = model.Email;
        //        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = model.Password;
        //        command.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = model.Mobile;
        //        command.ExecuteNonQuery();

        //        return RedirectToAction("DashboardView", "Dashboard");
        //    }
        //    return View("Register");
        //}

        //#endregion User Register

        #region User Edit
        public IActionResult UserAddEdit(int UserID)
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
            UserModel model = new UserModel();
            foreach (DataRow row in datatable.Rows)
            {
                model.UserName = @row["UserName"].ToString();
                model.Email = @row["Email"].ToString();
                model.Password = @row["Password"].ToString();
                model.Mobile = @row["Mobile"].ToString();
            }
            return View("RegisterUser", model);
        }
        #endregion User Edit

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

        #region User Login Page
        public IActionResult Login()
        {
            return View();
        }
        #endregion User Login Page

        #region UserLogin
        public IActionResult UserLogin(UserLoginModel userLoginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string connectionString = this.configuration.GetConnectionString("ConnectionString");
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "PR_MST_User_Login";
                    sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userLoginModel.UserName;
                    sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = userLoginModel.Password;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(sqlDataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        if (dataTable.Columns.Contains("ErrorMessage"))  // If an error message is returned
                        {
                            TempData["ErrorMessage"] = dataTable.Rows[0]["ErrorMessage"].ToString();
                            return RedirectToAction("Login", "Users");
                        }

                        // Successful login - store session
                        HttpContext.Session.SetString("UserID", dataTable.Rows[0]["UserID"].ToString());
                        HttpContext.Session.SetString("UserName", dataTable.Rows[0]["UserName"].ToString());

                        return RedirectToAction("DashboardView", "Dashboard");
                    }
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = e.Message;
            }

            return RedirectToAction("Login");
        }
        #endregion UserLogin

        #region User Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Users");
        }
        #endregion User Logout

    }
}
