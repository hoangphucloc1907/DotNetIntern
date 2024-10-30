namespace Quiz.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Quiz> Quizzes = new List<Quiz>();

        public void AddQuiz(Quiz quiz)
        {
            Quizzes.Add(quiz);
        }
    }
}
