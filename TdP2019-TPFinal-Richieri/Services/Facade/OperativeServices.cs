using System;

namespace TdP2019TPFinalRichieri.Services.Facade
{
    using System.Collections.Generic;
    using AutoMapper;
    using DTO;
    using Mapper;
    using Services;
    using Util;

    public class OperativeServices : IOperativeServices
    {
        private readonly IMapper _mapper;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private ISessionService _sessionService;
        private IQuestionsSetService _questionsSetService;
        private IUserService _userService;

        public OperativeServices(IMapperFactory pMapperFactory,
                                ISessionService pSessionService,
                                IQuestionsSetService pQuestionsSetService,
                                IUserService pUserService)
        {
            this._mapper = pMapperFactory.GetMapper();
            this._sessionService = pSessionService;
            this._questionsSetService = pQuestionsSetService;
            this._userService = pUserService;
        }

        /// <summary>
        /// Creates a new session for the given user, 
        /// with <paramref name="pQuestionsQuantity"/> questions from the
        /// given category and level.
        /// </summary>
        /// <returns>The session.</returns>
        /// <param name="pUserId">User identifier</param>
        /// <param name="pCategoryId">Category identifier.</param>
        /// <param name="pLevelId">Level identifier.</param>
        /// <param name="pQuestionsQuantity">Questions quantity.</param>
        public ResponseDTO<SessionDTO> NewSession(int pUserId, int pCategoryId, int pLevelId, int pQuestionsQuantity)
        {
            try
            {
                return _sessionService.NewSession(pUserId, pCategoryId, pLevelId, pQuestionsQuantity);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to create new Session.");
                return ResponseDTO<SessionDTO>.InternalError(
                         ErrorMessageHelper.FailedOperation("creating a new session"));
            }
        }

        /// <summary>
        /// Record an answer for a question from an ongoing session.
        /// </summary>
        /// <returns>Answer result.</returns>
        /// <param name="pSessionAnswer">Session answer parameters.</param>
        public ResponseDTO<AnswerResultDTO> AddAnswer(SessionAnswerDTO pSessionAnswer)
        {
            try
            {
                return _sessionService.AddAnswer(pSessionAnswer);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to add answer to the given session.");
                return ResponseDTO<AnswerResultDTO>.InternalError(
                        ErrorMessageHelper.FailedOperation("recording your answer"));
            }
        }

        /// <summary>
        /// Show ranking of session results for a given Questions Set.
        /// </summary>
        /// <param name="pQuestionsSetId">Questions set identifier.</param>
        public ResponseDTO<IEnumerable<SessionResultDTO>> ShowRanking(int pQuestionsSetId)
        {
            try
            {
                return _sessionService.GetSessionResults(pQuestionsSetId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to fetch Session results.");
                return ResponseDTO<IEnumerable<SessionResultDTO>>.InternalError(
                        ErrorMessageHelper.FailedOperation("fetching ranking"));
            }
        }

        /// <summary>
        /// Finish the given session and calculate its score.
        /// </summary>
        /// <param name="pSessionId">Session identifier</param>
        /// <returns>The session result <see cref="SessionResultDTO"/>.</returns>
        public ResponseDTO<SessionResultDTO> FinishSession(int pSessionId)
        {
            try
            {
                return _sessionService.FinishSession(pSessionId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to finish Session.");
                return ResponseDTO<SessionResultDTO>.InternalError(
                        ErrorMessageHelper.FailedOperation("attempting to finish the current session"));
            }
        }

        /// <summary>
        /// Gets all Questions Sets available.
        /// </summary>
        /// <returns>Questions set list.</returns>
        public ResponseDTO<IEnumerable<QuestionsSetDTO>> GetQuestionsSets()
        {
            try
            {
                return _questionsSetService.GetQuestionsSets();
            } 
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to fetch QuestionsSet list.");
                return ResponseDTO<IEnumerable<QuestionsSetDTO>>.InternalError(
                        ErrorMessageHelper.FailedOperation("fetching Questions Sets available"));
            }
        }


        /// <summary>
        /// Login for the given username and password. 
        /// </summary>
        /// <returns>The authorized user if login is successful.</returns>
        /// <param name="pUsername">Username.</param>
        /// <param name="pPassword">Password.</param>
        public ResponseDTO<UserDTO> Login(string pUsername, string pPassword)
        {
            try
            {
                return _userService.Login(pUsername, pPassword);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to Login.");
                return ResponseDTO<UserDTO>.InternalError(
                        ErrorMessageHelper.FailedOperation("logging in"));
            }
        }

        /// <summary>
        /// Register a new User. 
        /// </summary>
        /// <param name="pUsername">Username.</param>
        /// <param name="pPassword">Password.</param>
        /// <param name="pConfirmPassword">Confirmed password.</param>
        public ResponseDTO<object> SignUp(string pUsername, string pPassword, string pConfirmPassword)
        {
            try
            {
                return _userService.SignUp(pUsername, pPassword, pConfirmPassword);
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Failed to sign up.");
                return ResponseDTO.InternalError(ErrorMessageHelper.FailedOperation("signing up"));
            }
        }
    }
}
