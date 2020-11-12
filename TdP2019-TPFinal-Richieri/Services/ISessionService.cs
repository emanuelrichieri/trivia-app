using System;
using System.Collections.Generic;
using TdP2019TPFinalRichieri.DTO;

namespace TdP2019TPFinalRichieri.Services
{

    public interface ISessionService
    {
        ResponseDTO<SessionDTO> NewSession(int pUserId, int pCategoryId, int pLevelId, int pQuestionsQuantity);

        ResponseDTO<AnswerResultDTO> AddAnswer(SessionAnswerDTO pSessionAnswer);

        ResponseDTO<IEnumerable<SessionResultDTO>> GetSessionResults(int pQuestionsSetId);

        ResponseDTO<SessionResultDTO> FinishSession(int pSessionId);
    }
}
