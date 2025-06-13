namespace QuizeManagement.Models
{
    public class DashboardModel
    {
        public int CountOFLevel { get; set; }
        public string Level { get; set; }
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string QuestionLevel { get; set; }
        public int QuestionMarks { get; set; }
        public string CorrectOption { get; set; }

    }
}