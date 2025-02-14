using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using QuizeManagement.Models;

namespace QuizeManagement.Controllers
{
    public class QuizController : Controller
    {
        public IConfiguration configuration;
        public QuizController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        #region Quiz List
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
        #endregion Quiz List

        #region Quiz Add
        public IActionResult QuizSave(QuizModel model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = configuration.GetConnectionString("ConnectionString");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (model.QuizID == 0)
                {
                    command.CommandText = "PR_MST_Quiz_Insert";
                }
                else
                {
                    command.CommandText = "PR_MST_Quiz_Update";
                    command.Parameters.Add("@QuizID", SqlDbType.Int).Value = model.QuizID;
                }
                command.Parameters.Add("@QuizName", SqlDbType.VarChar).Value = model.QuizName;
                command.Parameters.Add("@TotalQuestions", SqlDbType.Int).Value = model.TotalQuestions;
                command.Parameters.Add("@QuizDate", SqlDbType.DateTime).Value = model.QuizDate;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = model. UserID;
                command.ExecuteNonQuery();
                return RedirectToAction("QuizList");
            }
            return View("QuizAddEdit", model);
        }
        #endregion Quiz Add

        #region Quiz Edit
        public IActionResult QuizAddEdit(int QuizID)
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand command = Connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_Quiz_SelectByID";
            command.Parameters.AddWithValue("@QuizID", QuizID);
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

        #region Quiz Delete
        public IActionResult QuizDelete(int QuizID)
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand Command = connection.CreateCommand();
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = "PR_MST_Quiz_Delete";
            Command.Parameters.Add("@QuizID",SqlDbType.Int).Value = QuizID;
            Command.ExecuteNonQuery();
            return RedirectToAction("QuizList");
        }
        #endregion Quiz Delete

    }
}