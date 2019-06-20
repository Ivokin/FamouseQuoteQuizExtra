using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quiz.Client.Models
{
    public class QuizClientContext : DbContext
    {
        public QuizClientContext (DbContextOptions<QuizClientContext> options)
            : base(options)
        {}

        public DbSet<QuizQuestions> QuizQuestions { get; set; }
    }
}
