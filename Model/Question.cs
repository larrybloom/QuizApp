namespace quiz_app.Model
{
    public class Question
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public QuestionType Type { get; set; }
        public List<Option> Options { get; set; }

        public Quiz Quiz  { get; set; }
        public string QuizId { get; set; }
    }
}
