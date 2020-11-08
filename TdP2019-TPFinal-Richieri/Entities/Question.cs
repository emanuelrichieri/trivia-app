using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace TdP2019TPFinalRichieri.Entities
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Description { get; set; }
        public Category Category { get; set; }
        public Level Level { get; set; }
        public bool Multiple { get; set; }
        public virtual IList<Answer> Answers { get; set; } = new List<Answer>();

        /// <summary>
        /// Get only correct Answers associated to this Question.
        /// </summary>
        /// <returns>The correct answers.</returns>
        public IEnumerable<Answer> GetCorrectAnswers()
        {
            return this.Answers.ToList().FindAll(answer => answer.IsCorrect).ToList();
        }

        /// <summary>
        /// Get only incorrect Answers associated to this Question.
        /// </summary>
        /// <returns>The correct answers.</returns>
        public IEnumerable<Answer> GetIncorrectAnswers()
        {
            return this.Answers.ToList().FindAll(answer => !answer.IsCorrect).ToList();
        }


        /// <summary>
        /// Hash function for question identity based on its description.
        /// </summary>
        public override int GetHashCode()
        {
            return this.Description.GetHashCode();
        }

    }
}