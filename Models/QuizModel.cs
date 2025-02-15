using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QuizeManagement.Models
{
    public class QuizModel
    {
        [Required(ErrorMessage = "User ID Require")]
        public int UserID { get; set; }

        public int QuizID { get; set; }

        [Required(ErrorMessage = "Quiz Name Require")]
        public string QuizName { get; set; }

        [Required(ErrorMessage = "Total Question Name Require")]
        public int TotalQuestions { get; set; }

        [Required(ErrorMessage = "Quiz Date Require")]
        public DateTime QuizDate { get; set; }
        public int UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified {  get; set; }
        public int QuestionID { get; internal set; }
        public string? QuestionLevel { get; internal set; }
    }
}
