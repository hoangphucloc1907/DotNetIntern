namespace Quiz.Model
{
    public class Question
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Title { get; set; }  
        public string Content { get; set; }
        public int QuestionTypeId { get; set; }
    }
}
