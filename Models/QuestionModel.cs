using System.ComponentModel.DataAnnotations;

namespace QuizeManagement.Models
{
    public class QuestionModel
    {
        [Required(ErrorMessage = "QuestionText Requied")]
        public string QuestionText { get; set; }
        [Required(ErrorMessage = "Option A Requied")]
        public string OptionA  { get; set; }
        [Required(ErrorMessage = "Option B Requied")]
        public string OptionB { get; set; }
        [Required(ErrorMessage = "Option C Requied")]
        public string OptionC { get; set; }
        [Required(ErrorMessage = "Option D Requied")]
        public string OptionD { get; set; }
        [Required(ErrorMessage = "Option Level Requied")]
        public string QuestionLevel { get; set; }
        [Required(ErrorMessage = "Option Mark Requied")]
        public int QuestionMarks {  get; set; }
        [Required(ErrorMessage = "Correct Option Requied")]
        public string CorrectOption { get; set; }
        public string QuestionID { get; set; }
        public string UserName { get; set; }
    }
}
