using Microsoft.EntityFrameworkCore;
using quiz_app.Model;

namespace quiz_app.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Option> Option { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }
        public DbSet<User> user { get; set; }
    }
}
