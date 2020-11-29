using System;
using System.Collections.Generic;
using System.Linq;

namespace TdP2019TPFinalRichieri.Services
{
    using AutoMapper;
    using Mapper;
    using DTO;
    using Entities;
    using DAL;
    using Exceptions;
    using ScoreCalculator;
    using ScoreCalculator.Calculators;
    using System.Configuration;

    public class SessionService : ISessionService
    {
        private IMapper _mapper;
        private IUnitOfWorkFactory _unitOfWorkFactory;
        
        private readonly int MIN_SESSION_QUESTIONS_QUANTITY; // Default value 10


        /// <summary>
        /// Dictionary that stores pairs of {QuestionsSetName, QuestionsSetCalculator}
        /// </summary>
        private readonly IDictionary<string, IScoreCalculator> _scoreCalculators = new Dictionary<string, IScoreCalculator>();


        public SessionService(IUnitOfWorkFactory pUnitOfWorkFactory,
                            IMapperFactory pMapperFactory)
        {
            this.MIN_SESSION_QUESTIONS_QUANTITY = int.Parse(ConfigurationManager.AppSettings["MinSessionQuestionsQuantity"] ?? "10");

            this._unitOfWorkFactory = pUnitOfWorkFactory;
            this._mapper = pMapperFactory.GetMapper();

            // Initialize Score Calculators
            this._scoreCalculators.Add(QuestionsSetsName.OpenTriviaDB.ToUpper(), new OpenTriviaDBScoreCalculator());
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
            if (pQuestionsQuantity < MIN_SESSION_QUESTIONS_QUANTITY)
            {
                throw new BadRequestException($"Questions quantity must be greather than {MIN_SESSION_QUESTIONS_QUANTITY}");
            }
            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                var user = bUoW.UserRepository.Get(pUserId) ?? throw new NotFoundException($"User id {pUserId} not found.");
                var level = bUoW.LevelRepository.Get(pLevelId) ?? throw new NotFoundException($"Level id {pLevelId} not found.");
                var category = bUoW.CategoryRepository.Get(pCategoryId) ?? throw new NotFoundException($"Category id {pCategoryId} not found.");
                var questions = bUoW.QuestionRepository.GetQuestions(category, level, pQuestionsQuantity).ToList();
                var session = new Session
                {
                    User = user,
                    Level = level,
                    Category = category,
                    Questions = questions,
                    Date = DateTime.Now,
                    Score = 0d
                };
                bUoW.SessionRepository.Add(session);

                bUoW.Complete();
                var sessionDTO = _mapper.Map<SessionDTO>(session);
                return ResponseDTO<SessionDTO>.Ok("Session successfully created.", sessionDTO);
            }
        }


        /// <summary>
        /// Record an answer for a question from an ongoing session.
        /// </summary>
        /// <returns>Answer result.</returns>
        /// <param name="pSessionAnswer">Session answer parameters.</param>
        public ResponseDTO<AnswerResultDTO> AddAnswer(SessionAnswerDTO pSessionAnswer)
        {
            if (pSessionAnswer.Session == null)
            {
                return ResponseDTO<AnswerResultDTO>.BadRequest("Failed to add answer. Invalid session.");
            }
            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                var question = bUoW.QuestionRepository.Get(pSessionAnswer.Question.Id);
                var answers = question.Answers.Where(answer => pSessionAnswer.Answers.Select(a => a.Id).Contains(answer.Id)).ToList();
                SessionAnswer sessionAnswer = new SessionAnswer
                {
                    Answers = answers,
                    Question = bUoW.QuestionRepository.Get(pSessionAnswer.Question.Id),
                    AnswerTime = pSessionAnswer.AnswerTime
                };

                // Get session entity from the given SessionId
                Session session = bUoW.SessionRepository.Get(pSessionAnswer.Session.Id) ?? throw new Exception($"Session id {pSessionAnswer.Session.Id} not found.");
                session.Answers.Add(sessionAnswer);

                AnswerResultDTO answerResult = _mapper.Map<AnswerResultDTO>(sessionAnswer);
                bUoW.Complete();

                return ResponseDTO<AnswerResultDTO>.Ok(answerResult.IsCorrect ? "Right!" : "Wrong answer.", answerResult);
            }
        }


        /// <summary>
        /// Get all session results for a given Questions Set.
        /// </summary>
        /// <param name="pQuestionsSetId">Questions set identifier.</param>
        public ResponseDTO<IEnumerable<SessionResultDTO>> GetSessionResults(int pQuestionsSetId)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                List<Session> sessions = bUoW.SessionRepository.GetByQuestionsSet(pQuestionsSetId).ToList();
                sessions.Sort();
                IEnumerable<SessionResultDTO> sessionResults = _mapper.Map<IEnumerable<SessionResultDTO>>(sessions);
                return ResponseDTO<IEnumerable<SessionResultDTO>>.Ok(sessionResults);
            }
        }


        /// <summary>
        /// Finish the given session and calculate its score.
        /// </summary>
        /// <param name="pSessionId">Session identifier</param>
        /// <returns>The session result <see cref="SessionResultDTO"/>.</returns>
        public ResponseDTO<SessionResultDTO> FinishSession(int pSessionId)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                Session session = bUoW.SessionRepository.Get(pSessionId);
                session.Score = this.CalculateScore(session);
                bUoW.Complete();

                return ResponseDTO<SessionResultDTO>.Ok($"Session ended! Your score is {session.Score}");
            }
        }


        /// <summary>
        /// Calculate the score for the given session. 
        /// </summary>
        /// <returns>The score.</returns>
        /// <param name="pSession">Session.</param>
        public double CalculateScore(Session pSession)
        {
            using(var bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                var category = bUoW.CategoryRepository.Get(pSession.Category.Id);

                QuestionsSet questionsSet = pSession.GetQuestionsSet() ?? throw new Exception("Invalid Questions Set.");
                if (this._scoreCalculators.TryGetValue(questionsSet.Name.ToUpper(), out IScoreCalculator calculator))
                {
                    return calculator.CalculateScore(pSession);
                }
                throw new Exception("There is no calculator defined for the Session's QuestionsSet.");
            }
        }
    }
}
