using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TdP2019TPFinalRichieri.DTO;
using TdP2019TPFinalRichieri.Exceptions;
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
        public void GetQuestionsSetsShouldReturnNoContent()
        {
            this._questionSetServiceMock.Setup(service => service.GetQuestionsSets()).Throws(new NoContentException());
            var response = this._operativeServices.GetQuestionsSets();

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.NoContent, response.Code);
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

        [Test]
        public void NewSessionShouldReturnOk()
        {
            _sessionServiceMock.Setup(service => service.NewSession(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                                .Returns(ResponseDTO<SessionDTO>.Ok(new SessionDTO()));

            var response = _operativeServices.NewSession(1, 1, 1, 1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(ResponseCode.Ok, response.Code);
            Assert.NotNull(response.Data);
        }

        [Test]
        public void NewSessionShouldReturnInternalError()
        {
            _sessionServiceMock.Setup(service => service.NewSession(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                               .Throws(new Exception("mock exception"));

            var response = _operativeServices.NewSession(1, 1, 1, 1);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.InternalError, response.Code);
        }


        [Test]
        public void NewSessionShouldReturnNotFound()
        {
            _sessionServiceMock.Setup(service => service.NewSession(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                               .Throws(new NotFoundException("mock exception"));

            var response = _operativeServices.NewSession(1, 1, 1, 1);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.NotFound, response.Code);
        }


        [Test]
        public void NewSessionShouldReturnBadRequest()
        {
            _sessionServiceMock.Setup(service => service.NewSession(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                               .Throws(new BadRequestException("mock exception"));

            var response = _operativeServices.NewSession(1, 1, 1, 1);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.BadRequest, response.Code);
        }


        [Test]
        public void LoginShouldBeOk()
        {
            _userServiceMock.Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(ResponseDTO<UserDTO>.Ok(new UserDTO()));

            var response = _operativeServices.Login("test", "test");

            Assert.IsTrue(response.Success);
            Assert.AreEqual(ResponseCode.Ok, response.Code);
        }

        [Test]
        public void LoginShouldReturnInternalError()
        {
            _userServiceMock.Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception("mock Exception"));

            var response = _operativeServices.Login("test", "test");

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.InternalError, response.Code);
        }

        [Test]
        public void SignUpShouldBeOk()
        {
            _userServiceMock.Setup(service => service.SignUp(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(ResponseDTO.Ok(""));

            var response = _operativeServices.SignUp("test", "test", "test");

            Assert.IsTrue(response.Success);
            Assert.AreEqual(ResponseCode.Ok, response.Code);
        }


        [Test]
        public void SignUpShouldReturnInternalError()
        {
            _userServiceMock.Setup(service => service.SignUp(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception("mock Exception"));

            var response = _operativeServices.SignUp("test", "test", "test");

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.InternalError, response.Code);
        }

    }
}
