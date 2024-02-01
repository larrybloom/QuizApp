namespace quiz_app.Model
{
    public class Quiz
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Category { get; set; }
        public List<Question> Questions { get; set; }
    }
}
