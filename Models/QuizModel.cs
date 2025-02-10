using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QuizeManagement.Models
{
    public class QuizModel
    {
        public int QuizID { get; set; }

        [Required(ErrorMessage = "Quiz Name Require")]
        public string QuizName { get; set; }

        [Required(ErrorMessage = "Total Question Name Require")]

        public string TotalQuestions { get; set; }
        [Required(ErrorMessage = "Quiz Date Require")]

        public DateTime QuizDate { get; set; }
        public int UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified {  get; set; }
    }
}
