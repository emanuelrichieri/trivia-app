using System;
using System.Collections.Generic;
namespace TdP2019TPFinalRichieri.Entities
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Question> Questions { get; set; }
        public QuestionsSet QuestionsSet { get; set; }
    }
}
