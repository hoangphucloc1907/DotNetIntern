namespace Quiz.Model
{
    public class Quiz
    {
        public int Id { get; set; }
        public string QuizName { get; set; }
        public string Description { get; set; }
        public TimeSpan TimeLimit { get; set; }
        public int TotalMarks { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public Level Level { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        

    }
}
