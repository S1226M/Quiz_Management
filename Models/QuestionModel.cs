namespace QuizeManagement.Models
{
    public class QuestionModel
    {
        public string QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionLevel { get; set; }
        public int QuestionMarks {  get; set; }
        public string UserName { get; set; }
    }
}
