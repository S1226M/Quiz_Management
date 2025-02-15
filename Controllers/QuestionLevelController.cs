using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using QuizeManagement.Models;

namespace QuizeManagement.Controllers
{
    public class QuestionLevelController : Controller
    {
        private IConfiguration configuration;

        public QuestionLevelController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        #region Question Level List
        public IActionResult QuestionLevelList()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_QuestionLevel_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        #endregion Question Level List

        #region Question Level Save
        public IActionResult QuestionLevelSave(QuestionLevelModel model)
        {
            if (ModelState.IsValid) 
            {
                string connectionStriing = configuration.GetConnectionString("ConnectionString");
                SqlConnection sqlConnection = new SqlConnection(connectionStriing);
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (model.QuestionLevelID == 0) 
                {
                    command.CommandText = "PR_MST_QuestionLevel_Insert";
                }
                else
                {
                    command.CommandText = "PR_MST_QuestionLevel_Update";
                    command.Parameters.Add("@QuestionLevelID", SqlDbType.Int).Value = model.QuestionLevelID;
                }
                command.Parameters.Add("@QuestionLevel", SqlDbType.VarChar).Value = model.QuestionLevel;
                command.Parameters.Add("@UserID" , SqlDbType.Int).Value = model.UserID;
                command.ExecuteNonQuery();
                return RedirectToAction("QuestionLevelList");
            }
            return View("QuestionLevelAdd", model);
        }
        #endregion Question Level Save


        #region Question Level AddEdit
        public IActionResult QuestionLevelAddEdit (int QuestionLevelID)
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand command = Connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_QuestionLevel_SelectByID";
            command.Parameters.AddWithValue("@QuestionLevelID", QuestionLevelID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(reader);
            QuizModel model = new QuizModel();
            foreach (DataRow row in datatable.Rows)
            {
                model.QuestionLevel = @row["QuestionLevel"].ToString();
                model.UserID = Convert.ToInt32(@row["UserID"]);
            }
            return View("QuestionLevelAddEdit", model);
        }
        #endregion Question Level AddEdit
    }
}