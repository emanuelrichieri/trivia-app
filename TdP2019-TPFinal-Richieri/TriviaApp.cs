using System;
using System.Linq;
using System.Collections.Generic;
namespace TdP2019TPFinalRichieri
{
    using DTO;
    using Services.Facade;

    public class TriviaApp
    {
        private IOperativeServices _operativeService;
        private IBackOfficeServices _backOffice;

        public UserDTO LoggedUser { get; set; }

        public SessionDTO CurrentSession { get; set; }

        public QuestionsSetDTO SelectedQuestionsSet { get; set; }

        public TriviaApp(IOperativeServices pOperativeServices,
                        IBackOfficeServices pBackOfficeServices)
        {
            this._operativeService = pOperativeServices;
            this._backOffice = pBackOfficeServices;
        }

        /// <summary>
        /// Starts new session.
        /// </summary>
        /// <returns>The first question of the created session.</returns>
        /// <param name="pCategory">Category.</param>
        /// <param name="pLevel">Level.</param>
        /// <param name="pQuestionsQuantity">Questions quantity.</param>
        public ResponseDTO<SessionDTO> StartNewSession(CategoryDTO pCategory, LevelDTO pLevel, int pQuestionsQuantity)
        {
            if (LoggedUser == null)
            {
                return ResponseDTO<SessionDTO>.Unauthorized("You must log in before starting a new session.");
            }
            if (pCategory == null)
            {
                return ResponseDTO<SessionDTO>.BadRequest("Select a category.");
            }
            if (pLevel == null)
            {
                return ResponseDTO<SessionDTO>.BadRequest("Select a level.");
            }
            var response = _operativeService.NewSession(LoggedUser.Id, pCategory.Id, pLevel.Id, pQuestionsQuantity);
            if (response.Success)
            {
                CurrentSession = response.Data;
                CurrentSession.RemainingQuestions = CurrentSession.Questions.ToList();
            }
            return response;
        }

        /// <summary>
        /// Gets next question for current session.
        /// </summary>
        /// <returns>The question.</returns>
        public ResponseDTO<QuestionDTO> NextQuestion()
        {
            if (CurrentSession == null)
            {
                return ResponseDTO<QuestionDTO>.BadRequest("No active session.");
            }
            if (CurrentSession.RemainingQuestions.Count > 0)
            {
                QuestionDTO nextQuestion = CurrentSession.RemainingQuestions.First();
                CurrentSession.RemainingQuestions.RemoveAt(0);
                nextQuestion.ShowedMoment = DateTime.Now;

                return ResponseDTO<QuestionDTO>.Ok(nextQuestion);
            }
            return ResponseDTO<QuestionDTO>.NoContent("There are no more questions for the given session");
        }


        /// <summary>
        /// Add an answer for the given question to the current session
        /// </summary>
        /// <returns>Answer result.</returns>
        /// <param name="pQuestion">Question.</param>
        /// <param name="pAnswers">Answers.</param>
        public ResponseDTO<AnswerResultDTO> AddAnswer(QuestionDTO pQuestion, IEnumerable<AnswerDTO> pAnswers)
        {
            SessionAnswerDTO sessionAnswer = new SessionAnswerDTO
            {
                Session = CurrentSession,
                Question = pQuestion,
                Answers = pAnswers.ToList(),
                AnswerTime = (DateTime.Now - pQuestion.ShowedMoment).Seconds
            };
            return _operativeService.AddAnswer(sessionAnswer);
        }

        /// <summary>
        /// Finish current Session
        /// </summary>
        public ResponseDTO<SessionResultDTO> FinishSession()
        {
            return _operativeService.FinishSession(CurrentSession.Id);
        }


        /// <summary>
        /// Get questions set ranking
        /// </summary>
        public ResponseDTO<IEnumerable<SessionResultDTO>> ShowRanking()
        {
            return _operativeService.ShowRanking(this.SelectedQuestionsSet.Id);
        }


        /// <summary>
        /// Gets all Questions Sets available.
        /// </summary>
        /// <returns>Questions set list.</returns>
        public ResponseDTO<IEnumerable<QuestionsSetDTO>> GetQuestionsSets()
        {
            return _operativeService.GetQuestionsSets();
        }


        /// <summary>
        /// Login for the given username and password. 
        /// </summary>
        /// <returns>The authorized user if login is successful.</returns>
        /// <param name="pUsername">Username.</param>
        /// <param name="pPassword">Password.</param>
        public ResponseDTO<UserDTO> Login(string pUsername, string pPassword)
        {
            ResponseDTO<UserDTO> response = _operativeService.Login(pUsername, pPassword);
            if (response.Success)
            {
                LoggedUser = response.Data;
            }
            return response;
        }


        /// <summary>
        /// Register a new User. 
        /// </summary>
        /// <param name="pUsername">Username.</param>
        /// <param name="pPassword">Password.</param>
        /// <param name="pConfirmPassword">Confirmed password.</param>
        public ResponseDTO<object> SignUp(string pUsername, string pPassword, string pConfirmPassword)
        {
            return _operativeService.SignUp(pUsername, pPassword, pConfirmPassword);
        }

        /// <summary>
        /// Logout.
        /// </summary>
        public ResponseDTO<object> Logout()
        {
            this.LoggedUser = null;
            this.CurrentSession = null;
            this.SelectedQuestionsSet = null;
            return ResponseDTO.Ok("Successfully logged out.");
        }


        /// <summary>
        /// Update data for selected questions set. 
        /// </summary>
        public ResponseDTO<object> UpdateQuestionsSetData()
        {
            if (SelectedQuestionsSet == null)
            {
                return ResponseDTO.BadRequest("Select a Questions Set.");
            }
            return this._backOffice.UpdateQuestionsSetData(SelectedQuestionsSet.Name);
        }

        public ResponseDTO<object> SaveQuestionsSet()
        {
            if (SelectedQuestionsSet == null)
            {
                return ResponseDTO.BadRequest("Select a Questions Set.");
            }
            return this._backOffice.SaveQuestionsSet(SelectedQuestionsSet);
        }
    }
}
