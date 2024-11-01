using Quiz.Model;
using Quiz.Service;
namespace QuizTest
{
    [TestClass]
    public class TestQuiz
    {
        private List<Question> _questionLibrary;
        private QuizGeneratorService _quizGeneratorService;

        [TestInitialize]
        public void Setup()
        {
            _questionLibrary = new List<Question>
            {
                new MultipleChoiceQuestion { Content = "Easy Question 1", Level = Level.Easy, Category = Category.Math, CorrectAnswer = "A", Options = new List<string> { "A", "B", "C", "D" } },
                new MultipleChoiceQuestion { Content = "Medium Question 1", Level = Level.Medium, Category = Category.Physics, CorrectAnswer = "B", Options = new List<string> { "A", "B", "C", "D" } },
                new MultipleChoiceQuestion { Content = "Hard Question 1", Level = Level.Hard, Category = Category.Chemistry, CorrectAnswer = "C", Options = new List<string> { "A", "B", "C", "D" } },
                new TrueFalseQuestion { Content = "Easy Question 2", Level = Level.Easy, Category = Category.Math, CorrectAnswer = true },
                new TrueFalseQuestion { Content = "Medium Question 2", Level = Level.Medium, Category = Category.Physics, CorrectAnswer = false },
                new TrueFalseQuestion { Content = "Hard Question 2", Level = Level.Hard, Category = Category.Chemistry, CorrectAnswer = true },
                new FillInTheBlankQuestion { Content = "Easy Question 3", Level = Level.Easy, Category = Category.Math, CorrectAnswer = "Answer" },
                new FillInTheBlankQuestion { Content = "Medium Question 3", Level = Level.Medium, Category = Category.Physics, CorrectAnswer = "Answer" },
                new FillInTheBlankQuestion { Content = "Hard Question 3", Level = Level.Hard, Category = Category.Chemistry, CorrectAnswer = "Answer" }
            };

            _quizGeneratorService = new QuizGeneratorService(_questionLibrary);
        }

        [TestMethod]
        public void TestGenerateQuizShouldReturnCorrectNumberOfQuestions()
        {
            // Arrange
            var criteria = new QuizCriteria
            {
                EasyQuestions = 1,
                MediumQuestions = 1,
                HardQuestions = 1,
                TimeLimit = TimeSpan.FromMinutes(30)
            };

            // Act
            var quiz = _quizGeneratorService.GenerateQuiz(criteria);

            // Assert
            Assert.AreEqual(3, quiz.Questions.Count);
        }

        [TestMethod]
        public void TestGenerateQuizShouldReturnQuestionsWithCorrectLevels()
        {
            // Arrange
            var criteria = new QuizCriteria
            {
                EasyQuestions = 1,
                MediumQuestions = 1,
                HardQuestions = 1,
                TimeLimit = TimeSpan.FromMinutes(30)
            };

            // Act
            var quiz = _quizGeneratorService.GenerateQuiz(criteria);

            // Assert
            Assert.AreEqual(1, quiz.Questions.Count(q => q.Level == Level.Easy));
            Assert.AreEqual(1, quiz.Questions.Count(q => q.Level == Level.Medium));
            Assert.AreEqual(1, quiz.Questions.Count(q => q.Level == Level.Hard));
        }

        [TestMethod]
        public void TestGenerateQuizShouldShuffleQuestions()
        {
            // Arrange
            var criteria = new QuizCriteria
            {
                EasyQuestions = 1,
                MediumQuestions = 1,
                HardQuestions = 1,
                TimeLimit = TimeSpan.FromMinutes(30)
            };

            // Act
            var quiz1 = _quizGeneratorService.GenerateQuiz(criteria);
            var quiz2 = _quizGeneratorService.GenerateQuiz(criteria);

            // Assert
            CollectionAssert.AreNotEqual(quiz1.Questions, quiz2.Questions);
        }

        [TestMethod]
        public void TestGenerateQuizShouldReturnQuestionsWithCorrectTimeLimit()
        {
            // Arrange
            var criteria = new QuizCriteria
            {
                EasyQuestions = 1,
                MediumQuestions = 1,
                HardQuestions = 1,
                TimeLimit = TimeSpan.FromMinutes(30)
            };

            // Act
            var quiz = _quizGeneratorService.GenerateQuiz(criteria);

            // Assert
            Assert.AreEqual(TimeSpan.FromMinutes(30), quiz.TimeLimit);
        }
    }

    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void MultipleChoiceQuestion_CheckAnswer_ShouldReturnTrueForCorrectAnswer()
        {
            // Arrange
            var question = new MultipleChoiceQuestion
            {
                Id = 1,
                Content = "What is 2 + 2?",
                Level = Level.Easy,
                Category = Category.Math,
                Options = new List<string> { "1", "2", "3", "4" },
                CorrectAnswer = "4"
            };

            // Act
            var result = question.CheckAnswer("4");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MultipleChoiceQuestion_CheckAnswer_ShouldReturnFalseForIncorrectAnswer()
        {
            // Arrange
            var question = new MultipleChoiceQuestion
            {
                Id = 1,
                Content = "What is 2 + 2?",
                Level = Level.Easy,
                Category = Category.Math,
                Options = new List<string> { "1", "2", "3", "4" },
                CorrectAnswer = "4"
            };

            // Act
            var result = question.CheckAnswer("3");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TrueFalseQuestion_CheckAnswer_ShouldReturnTrueForCorrectAnswer()
        {
            // Arrange
            var question = new TrueFalseQuestion
            {
                Id = 2,
                Content = "The earth is flat.",
                Level = Level.Easy,
                Category = Category.Physics,
                CorrectAnswer = false
            };

            // Act
            var result = question.CheckAnswer("false");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TrueFalseQuestion_CheckAnswer_ShouldReturnFalseForIncorrectAnswer()
        {
            // Arrange
            var question = new TrueFalseQuestion
            {
                Id = 2,
                Content = "The earth is flat.",
                Level = Level.Easy,
                Category = Category.Physics,
                CorrectAnswer = false
            };

            // Act
            var result = question.CheckAnswer("true");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FillInTheBlankQuestion_CheckAnswer_ShouldReturnTrueForCorrectAnswer()
        {
            // Arrange
            var question = new FillInTheBlankQuestion
            {
                Id = 3,
                Content = "The chemical symbol for water is __.",
                Level = Level.Medium,
                Category = Category.Chemistry,
                CorrectAnswer = "H2O"
            };

            // Act
            var result = question.CheckAnswer("H2O");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FillInTheBlankQuestion_CheckAnswer_ShouldReturnFalseForIncorrectAnswer()
        {
            // Arrange
            var question = new FillInTheBlankQuestion
            {
                Id = 3,
                Content = "The chemical symbol for water is __.",
                Level = Level.Medium,
                Category = Category.Chemistry,
                CorrectAnswer = "H2O"
            };

            // Act
            var result = question.CheckAnswer("H2");

            // Assert
            Assert.IsFalse(result);
        }
    }
}