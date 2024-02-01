namespace quiz_app.Model
{
    public class UserAnswer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Question Questions { get; set; }
        public string QuestionId { get; set; }
        public string Answer { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        
    }
}
