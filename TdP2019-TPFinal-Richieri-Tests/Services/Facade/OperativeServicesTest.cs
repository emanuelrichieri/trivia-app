using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TdP2019TPFinalRichieri.DTO;
using TdP2019TPFinalRichieri.Mapper;
using TdP2019TPFinalRichieri.Services;
using TdP2019TPFinalRichieri.Services.Facade;

namespace TdP2019TPFinalRichieriTests.Services.Facade
{
    [TestFixture]
    public class OperativeServicesTest
    {

        protected Mock<ISessionService> _sessionServiceMock = new Mock<ISessionService>();
        protected Mock<IQuestionsSetService> _questionSetServiceMock = new Mock<IQuestionsSetService>();
        protected Mock<IUserService> _userServiceMock = new Mock<IUserService>();

        protected IOperativeServices _operativeServices;

        [SetUp]
        public void SetUp()
        {
            this._operativeServices = new OperativeServices(new TriviaMapperFactory(), 
                                                _sessionServiceMock.Object, 
                                                _questionSetServiceMock.Object, 
                                                _userServiceMock.Object);
        }



        [Test]
        public void GetQuestionsSetsShouldReturnInternalError()
        {
            this._questionSetServiceMock.Setup(service => service.GetQuestionsSets()).Throws(new Exception());

            var response = this._operativeServices.GetQuestionsSets();

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.InternalError, response.Code);
        }

        [Test]
        public void GetQuestionsSetsShouldReturnOk()
        {
            var mockResponse = ResponseDTO<IEnumerable<QuestionsSetDTO>>.Ok(new List<QuestionsSetDTO>());
            this._questionSetServiceMock.Setup(service => service.GetQuestionsSets()).Returns(mockResponse);

            var response = _operativeServices.GetQuestionsSets();
            Assert.IsTrue(response.Success);
            Assert.AreEqual(ResponseCode.Ok, response.Code);
            Assert.NotNull(response.Data);
        }
    }
}
