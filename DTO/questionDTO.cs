using quiz_app.Model;

namespace quiz_app.DTO
{
    public class questionDTO
    {
        public string QuizId { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public QuestionType Type { get; set; }
    }
}
