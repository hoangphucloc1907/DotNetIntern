namespace Quiz.Model
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AnswerOptionId { get; set; }
        public int UserId { get; set; }
        public string UserAnswerContent { get; set; }

    }
}
