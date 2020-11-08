using System;
namespace TdP2019TPFinalRichieri.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public QuestionDTO Question { get; set; }
    }
}
