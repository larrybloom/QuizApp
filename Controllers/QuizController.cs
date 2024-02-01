using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_app.Data;
using quiz_app.DTO;
using quiz_app.Model;

namespace quiz_app.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        private readonly QuizContext _context;

        public QuizController(QuizContext context)
        {

            _context = context;
        }
        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser(UserDto user)
        {
            if (await _context.user.FirstOrDefaultAsync(u => u.Name == user.UserName) != null)
            {

                return BadRequest("Username already exist");
            }
            var adduser = await _context.user.AddAsync(new User() { Name = user.UserName });
            await _context.SaveChangesAsync();
            return Ok(adduser.Entity);
        }
        [HttpPost("add-quiz")]
        public async Task<IActionResult> AddQuiz(QuizDto quiz)
        {
            if (await _context.Quiz.FirstOrDefaultAsync(u => u.Category == quiz.Category) != null)
            {

                return BadRequest("Quiz category already exist");
            }
            var addQuiz = await _context.Quiz.AddAsync(new Quiz() { Category = quiz.Category });
            await _context.SaveChangesAsync();
            return Ok(addQuiz.Entity);
        }
        [HttpPost("add-question")]
        public async Task<IActionResult> AddQuestion(questionDTO question)
        {

            var addQuestion = await _context.Question.AddAsync(new Question()
            {
                CorrectAnswer = question.CorrectAnswer,
                QuizId = question.QuizId,
                Text = question.Text,
                Type = question.Type
            });
            await _context.SaveChangesAsync();
            return Ok(addQuestion.Entity);
        }
        [HttpPost("add-option")]
        public async Task<IActionResult> AddQuestionOption(OptionDto option)
        {

            var addOption = await _context.Option.AddAsync(new Option()
            {

                Text = option.Text,
                QuestionId = option.QuestionId,
            });
            await _context.SaveChangesAsync();
            return Ok(addOption.Entity);
        }

        [HttpGet("retrieve-all-quiz-question")]
        public async Task<IActionResult> GetAllQuizQuestion(string category)
        {
            var cat = await _context.Quiz.FirstOrDefaultAsync(x => x.Category == category);
            if (cat == null) { return BadRequest("Invalid quiz category"); }
            var allQuestion = await _context.Question.Where(q => q.QuizId == cat.Id).Include(u => u.Options).Select(q => new QuestionResponseDto
            {
                Id = q.Id,
                Options = q.Options,
                Text = q.Text,
                Type = q.Type
            }).ToListAsync();
            return Ok(allQuestion);
        }
        [HttpPost("answer-question")]
        public async Task<IActionResult> AnswerQuestion(UserAnswerDto answer)
        {

            var user = await _context.user.FirstOrDefaultAsync(u => u.Name == answer.UserName);
            if (user == null)
            {
                return BadRequest("Invalid UserName");
            }
            var addUserAnswer = await _context.UserAnswer.AddAsync(new UserAnswer()
            {
                Answer = answer.Answer,
                QuestionId = answer.QuestionId,
                UserId = user.Id
            });
            await _context.SaveChangesAsync();
            return Ok("Question Answer successfully");
        }
        [HttpGet("markscore")]
        public async Task<IActionResult> MarkUser(string category, string username)
        {
            var userscore = 0;
            var cat = await _context.Quiz.FirstOrDefaultAsync(x => x.Category == category);
            if (cat == null) { return BadRequest("Invalid quiz category"); }
            var checkuser = await _context.user.FirstOrDefaultAsync(x => x.Name == username);
            if (checkuser == null) { return BadRequest("Invalid username"); }
            var allquestion = await _context.Question.Where(q => q.QuizId == cat.Id).ToListAsync();
            foreach (var question in allquestion)
            {
                var quiztaken = await _context.UserAnswer.FirstOrDefaultAsync(q => q.UserId == checkuser.Id && q.QuestionId == question.Id);
                if (quiztaken != null)
                {
                    if (quiztaken.Answer == quiztaken.Answer)
                    {
                        userscore += 1;
                    }

                }
            }
            var scorePer = (userscore / allquestion.Count) * 100;
            return Ok(new
            {
                CorrectScore = userscore,
                ScorePercent = scorePer.ToString() + "%",
                TotalQuizQuestions = allquestion.Count
            });


        }

    }
}
