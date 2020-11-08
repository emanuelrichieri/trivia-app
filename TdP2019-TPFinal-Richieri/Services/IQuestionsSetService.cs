using System;
using System.Collections.Generic;
using TdP2019TPFinalRichieri.DTO;
using TdP2019TPFinalRichieri.Entities;

namespace TdP2019TPFinalRichieri.Services
{
    public interface IQuestionsSetService
    {
        ResponseDTO<IEnumerable<QuestionsSetDTO>> GetQuestionsSets();

        ResponseDTO<object> Save(QuestionsSet pQuestionsSet);

        ResponseDTO<object> UpdateQuestionsSetData(string pQuestionsSetName);
    }
}
