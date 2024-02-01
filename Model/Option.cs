namespace quiz_app.Model
{
    public class Option
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public Question Questions { get; set; }
        public string QuestionId { get; set; }
    }
}
