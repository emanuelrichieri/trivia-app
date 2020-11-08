using System;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri.DTO
{
    public class QuestionsSetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExpectedAnswerTime { get; set; }
        public IList<LevelDTO> Levels { get; set; }
        public IList<CategoryDTO> Categories { get; set; }
    }
}
