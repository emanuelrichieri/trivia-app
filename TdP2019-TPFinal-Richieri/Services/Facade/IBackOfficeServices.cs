using System;
using TdP2019TPFinalRichieri.DTO;

namespace TdP2019TPFinalRichieri.Services.Facade
{
    public interface IBackOfficeServices
    {
        ResponseDTO<object> UpdateQuestionsSetData(string pQuestionsSetName);

        ResponseDTO<object> SaveQuestionsSet(QuestionsSetDTO pQuestionsSet);
    }
}
