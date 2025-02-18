using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QuizeManagement.Models
{
    public class QuizModel
    {
        [Required(ErrorMessage = "User ID Required")]
        public int UserID { get; set; }

        public int QuizID { get; set; }

        [Required(ErrorMessage = "Quiz Name Required")]
        public string QuizName { get; set; }

        [Required(ErrorMessage = "Total Question Name Required")]
        [Range(1,100 ,ErrorMessage = "Total Questions must greater then 0.")]
        public int TotalQuestions { get; set; }

        [Required(ErrorMessage = "Quiz Date Required")]
        public DateTime QuizDate { get; set; }
        public int UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified {  get; set; }
        public int QuestionID { get; internal set; }
        public string? QuestionLevel { get; internal set; }
    }
}
