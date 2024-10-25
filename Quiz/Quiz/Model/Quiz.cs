namespace Quiz.Model
{
    public class Quiz
    {
        public int Id { get; set; }
        public string QuizName { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int LevelId { get; set; }
    }
}
