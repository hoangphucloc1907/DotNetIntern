namespace Quiz.Model
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public int Position { get; set; }
        public int QuestionId { get; set; }
    }
}
