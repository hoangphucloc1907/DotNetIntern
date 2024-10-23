namespace Quiz.Model
{
    public class Quiz
    {
        public int Id { get; set; }
        public string QuizName { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
    }
}
