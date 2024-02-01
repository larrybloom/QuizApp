using quiz_app.Model;

namespace quiz_app.DTO
{
    public class QuestionResponseDto
    {
        public string Id { get; set; } 
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public List<Option> Options { get; set; }
    }
}
