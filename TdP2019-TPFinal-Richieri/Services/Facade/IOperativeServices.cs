using System;
using System.Collections.Generic;
using TdP2019TPFinalRichieri.DTO;

namespace TdP2019TPFinalRichieri.Services.Facade
{
    public interface IOperativeServices
    {
        ResponseDTO<SessionDTO> NewSession(int pUserId, int pCategoryId, int pLevelId, int pQuestionsQuantity);

        ResponseDTO<AnswerResultDTO> AddAnswer(SessionAnswerDTO pSessionAnswer);

        ResponseDTO<IEnumerable<SessionResultDTO>> ShowRanking(int pQuestionsSetId);

        ResponseDTO<SessionResultDTO> FinishSession(int pSessionId);

        ResponseDTO<IEnumerable<QuestionsSetDTO>> GetQuestionsSets();

        ResponseDTO<UserDTO> Login(string pUsername, string pPassword);

        ResponseDTO<object> SignUp(string pUsername, string pPassword, string pConfirmPassword);
    }
}
