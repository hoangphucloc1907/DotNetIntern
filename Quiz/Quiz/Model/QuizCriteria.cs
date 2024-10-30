namespace Quiz.Model
{
    public class QuizCriteria
    {
        public int EasyQuestions { get; set; }
        public int MediumQuestions { get; set; }
        public int DifficultQuestions { get; set; }
        public TimeSpan TimeLimit { get; set; }
    }
}
