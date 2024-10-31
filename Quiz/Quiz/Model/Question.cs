namespace Quiz.Model
{
    public abstract class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Level Level { get; set; }  
        public Category Category { get; set; }
        public abstract bool CheckAnswer(string answer);


    }

    public class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }

        public override bool CheckAnswer(string answer)
        {
            return answer == CorrectAnswer;
        }
    }

    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public override bool CheckAnswer(string answer)
        {
            return bool.TryParse(answer, out bool result) && result == CorrectAnswer;
        }
    }

    public class FillInTheBlankQuestion : Question
    {
        public string CorrectAnswer { get; set; }

        public override bool CheckAnswer(string answer)
        {
            return answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
