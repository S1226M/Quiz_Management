namespace QuizeManagement.Models
{
    public class QuestionLevelModel
    {
        public int QuestionLevelID { get; set; }

        public string QuestionLevel { get; set; }
        public string QuestionText { get; set; }

        public int UserID { get; set; }
        public string UserName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
