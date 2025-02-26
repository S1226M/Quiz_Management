namespace QuizeManagement.Models
{
    public class QuizWiseQuestionModel
    {
        public int QuizWiseQuestionID { get; set; }
        public int QuizID { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }

        public string QuizName { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}