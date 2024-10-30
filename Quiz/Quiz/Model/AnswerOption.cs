namespace Quiz.Model
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AnswerType { get; set; }
        public int CorrectPosition { get; set; }
        public int QuestionId { get; set; }
    }
}
