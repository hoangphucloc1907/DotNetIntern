using Quiz.Model;

namespace Quiz.Service
{
    public class QuizGeneratorService
    {
        private readonly List<Question> _questionLibrary;

        public QuizGeneratorService(List<Question> questionLibrary)
        {
            _questionLibrary = questionLibrary;
        }

        public Quiz.Model.Quiz GenerateQuiz(QuizCriteria criteria)
        {
            var selectedQuestions = new List<Question>();

            // Select questions based on criteria
            selectedQuestions.AddRange(SelectQuestions(Level.Easy, criteria.EasyQuestions));
            selectedQuestions.AddRange(SelectQuestions(Level.Medium, criteria.MediumQuestions));
            selectedQuestions.AddRange(SelectQuestions(Level.Hard, criteria.HardQuestions));

            // Shuffle questions
            var random = new Random();
            selectedQuestions = selectedQuestions.OrderBy(q => random.Next()).ToList();

            return new Quiz.Model.Quiz
            {
                Questions = selectedQuestions,
                TimeLimit = criteria.TimeLimit
            };
        }

        private IEnumerable<Question> SelectQuestions(Level level, int count)
        {
            return _questionLibrary
                .Where(q => q.Level == level)
                .OrderBy(q => Guid.NewGuid())
                .Take(count);
        }
    }
}
