using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TdP2019TPFinalRichieri.Entities
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual IList<Question> Questions { get; set; } = new List<Question>();
        public QuestionsSet QuestionsSet { get; set; }
    }
}
