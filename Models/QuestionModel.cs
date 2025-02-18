using System.ComponentModel.DataAnnotations;

namespace QuizeManagement.Models
{
    public class QuestionModel
    {
        [Required(ErrorMessage = "QuestionText is Required")]
        public string QuestionText { get; set; }
        [Required(ErrorMessage = "Option A is Required")]
        public string OptionA  { get; set; }
        [Required(ErrorMessage = "Option B is Required")]
        public string OptionB { get; set; }
        [Required(ErrorMessage = "Option C is Required")]
        public string OptionC { get; set; }
        [Required(ErrorMessage = "Option D is Required")]
        public string OptionD { get; set; }
        
        [Required(ErrorMessage = "Option Level Required")]
        public string? QuestionLevel { get; set; }

        [Required(ErrorMessage = "Option Mark is Required")]
        [Range(0,100 , ErrorMessage ="Question Mark is must be greater then 0.")]
        public int QuestionMarks {  get; set; }
        
        [Required(ErrorMessage = "Correct Option is Required")]
        public string CorrectOption { get; set; }
        public int QuestionID { get; set; }
        public string? UserName { get; set; }
        public int UserID { get; set; }
        public int QuestionLevelID { get; set; }
    }
}
