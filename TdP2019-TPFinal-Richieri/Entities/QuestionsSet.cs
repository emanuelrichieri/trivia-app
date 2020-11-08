using System;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri.Entities
{
    public class QuestionsSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Level> Levels { get; set; } = new List<Level>();
        public virtual IList<Category> Categories { get; set; } = new List<Category>();

        /// <summary>
        /// Expected answer time for individual question.
        /// </summary>
        public int ExpectedAnswerTime { get; set; }

    }
}
