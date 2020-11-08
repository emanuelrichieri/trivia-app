using System;
namespace TdP2019TPFinalRichieri.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
    }
}
