namespace Quiz.Model
{
    public abstract class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Level Level { get; set; }  
        public Category Category { get; set; }

    }
}
