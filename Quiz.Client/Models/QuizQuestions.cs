using System.ComponentModel.DataAnnotations;

namespace Quiz.Client.Models
{
    public class QuizQuestions
    {
        [Key]
        public int Id { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public string AnswerOne { get; set; }

        public string AnswerTwo { get; set; }

        public string AnswerThree { get; set; }
    }
}
