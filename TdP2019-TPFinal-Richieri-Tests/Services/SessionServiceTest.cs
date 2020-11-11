using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Moq;
using NUnit.Framework;
using TdP2019TPFinalRichieri.DAL;
using TdP2019TPFinalRichieri.DTO;
using TdP2019TPFinalRichieri.Entities;
using TdP2019TPFinalRichieri.Exceptions;
using TdP2019TPFinalRichieri.Mapper;
using TdP2019TPFinalRichieri.Services;

namespace TdP2019TPFinalRichieriTests.Services
{
    [TestFixture]
    public class SessionServiceTest
    {

        private Mock<ISessionRepository> _sessionRepositoryMock = new Mock<ISessionRepository>();
        private Mock<IQuestionRepository> _questionRepositoryMock = new Mock<IQuestionRepository>();
        private Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private Mock<ICategoryRepository> _categoryRepositoryMock = new Mock<ICategoryRepository>();
        private Mock<ILevelRepository> _levelRepositoryMock = new Mock<ILevelRepository>();


        private ISessionService _service;

        private readonly int MIN_SESSION_QUESTIONS_QUANTITY = int.Parse(ConfigurationManager.AppSettings["MinSessionQuestionsQuantity"] ?? "10");

        private Random rand = new Random();
        
        [SetUp]
        public void SetUp()
        {
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(bUoW => bUoW.SessionRepository).Returns(_sessionRepositoryMock.Object);
            unitOfWorkMock.Setup(bUoW => bUoW.QuestionRepository).Returns(_questionRepositoryMock.Object);
            unitOfWorkMock.Setup(bUoW => bUoW.UserRepository).Returns(_userRepositoryMock.Object);
            unitOfWorkMock.Setup(bUoW => bUoW.CategoryRepository).Returns(_categoryRepositoryMock.Object);
            unitOfWorkMock.Setup(bUoW => bUoW.LevelRepository).Returns(_levelRepositoryMock.Object);


            Mock<IUnitOfWorkFactory> unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory>();
            unitOfWorkFactoryMock.Setup(factory => factory.GetUnitOfWork())
                                    .Returns(unitOfWorkMock.Object);

            var unitOfWorkFactory = unitOfWorkFactoryMock.Object;

            this._service = new SessionService(unitOfWorkFactory, new TriviaMapperFactory());
        }

        [Test]
        [TestCase(0)] // Should be at least MIN_SESSION_QUESTIONS_QUANTITY, so it should return bad request
        [TestCase(-1)] // negative questions quantity should throw bad request exception
        public void NewSessionShouldReturnBadRequest(int questionsQuantity)
        {
            _userRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new User());
            _categoryRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new Category());
            _levelRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new Level());

            var response = _service.NewSession(rand.Next(), rand.Next(), rand.Next(), questionsQuantity);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.BadRequest, response.Code);
        }

        [Test]
        public void NewSessionShouldReturnInternalError()
        {
            _userRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new User());
            _categoryRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new Category());
            _levelRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new Level());


            _questionRepositoryMock.Setup(repo => repo.GetQuestions(It.IsAny<Category>(), It.IsAny<Level>(), It.IsAny<int>()))
                                        .Throws(new NotEnoughQuestionsException("mock error"));
            var response = _service.NewSession(rand.Next(), rand.Next(), rand.Next(), MIN_SESSION_QUESTIONS_QUANTITY + rand.Next());
            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.InternalError, response.Code);
        }


        [Test]
        [TestCase("user")] // user not found case
        [TestCase("level")] // level not found case
        [TestCase("category")] // category not found case
        public void NewSessionShouldReturnNotFound(string nullCase)
        {
            // check if nullCase then return null
            User user = nullCase == "user" ? null : new User();
            Category category = nullCase == "category" ? null : new Category();
            Level level = nullCase == "level" ? null : new Level();

            _userRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(user);
            _levelRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(level);
            _categoryRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(category);

            var response = _service.NewSession(rand.Next(), rand.Next(), rand.Next(), MIN_SESSION_QUESTIONS_QUANTITY + rand.Next());
            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.NotFound, response.Code);
        }

        [Test]
        public void NewSessionShouldReturnOk()
        {   
            // When UserRepository.Get(anyId) then return new User with name TEST-USER
            _userRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new User { Username = "TEST-USER" });

            // When CategoryRepository.Get(anyId) then return new Category with name TEST-CATEGORY and questions set with name TEST-QUESTIONS-SET
            _categoryRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>()))
                                .Returns(new Category 
                                        { 
                                            Name = "TEST-CATEGORY",
                                            QuestionsSet = new QuestionsSet
                                            {
                                                Name = "TEST-QUESTIONS-SET"
                                            }
                                        });

            // When LevelRepository.Get(anyId) then return new Level with name TEST-LEVEL
            _levelRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new Level { Name = "TEST-LEVEL" });

            // When QuestionRepository.GetQuestions(anyCategory, anyLevel, anyQuantity) then return a list with one question 
            // with description TEST-QUESTION
            _questionRepositoryMock.Setup(repo => repo.GetQuestions(It.IsAny<Category>(), It.IsAny<Level>(), It.IsAny<int>()))
                                    .Returns(new List<Question> { 
                                                new Question { 
                                                    Description = "TEST-QUESTION" 
                                                } 
                                            });
                                            
            var response = _service.NewSession(rand.Next(), rand.Next(), rand.Next(), MIN_SESSION_QUESTIONS_QUANTITY + rand.Next());
            Assert.IsTrue(response.Success);
            Assert.AreEqual(ResponseCode.Ok, response.Code);
            Assert.NotNull(response.Data);
            Assert.IsNotEmpty(response.Data.Questions);
            Assert.AreEqual("TEST-CATEGORY", response.Data.Category);
            Assert.AreEqual("TEST-USER", response.Data.Username);
            Assert.AreEqual("TEST-LEVEL", response.Data.Level);
            Assert.AreEqual("TEST-QUESTION", response.Data.Questions.First().Question);
            Assert.AreEqual("TEST-QUESTIONS-SET", response.Data.QuestionsSet);
        }
    }
}
