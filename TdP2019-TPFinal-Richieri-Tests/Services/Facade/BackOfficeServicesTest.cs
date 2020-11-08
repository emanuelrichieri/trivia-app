using System;
using Moq;
using NUnit.Framework;
using TdP2019TPFinalRichieri.DTO;
using TdP2019TPFinalRichieri.Entities;
using TdP2019TPFinalRichieri.Mapper;
using TdP2019TPFinalRichieri.Services;
using TdP2019TPFinalRichieri.Services.Facade;

namespace TdP2019TPFinalRichieriTests.Services.Facade
{
    [TestFixture]
    public class BackOfficeServicesTest
    {
        protected Mock<IQuestionsSetService> _questionSetServiceMock = new Mock<IQuestionsSetService>();

        protected IBackOfficeServices _backOfficeServices;

        [SetUp]
        public void SetUp()
        {
            this._backOfficeServices = new BackOfficeServices(new TriviaMapperFactory(), _questionSetServiceMock.Object);
        }

        [Test]
        public void SaveQuestionsSetShouldReturnOk()
        {
            _questionSetServiceMock.Setup(service => service.Save(It.IsAny<QuestionsSet>())).Returns(ResponseDTO.Ok(""));

            QuestionsSetDTO questionsSetDTO = new QuestionsSetDTO
            {
                Id = 1,
                Name = "abcdefg_1234"
            };

            var response = _backOfficeServices.SaveQuestionsSet(questionsSetDTO);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(ResponseCode.Ok, response.Code);
        }

        [Test]
        public void SaveQuestionsSetShouldReturnInternalError()
        {
            _questionSetServiceMock.Setup(service => service.Save(It.IsAny<QuestionsSet>())).Throws(new Exception());
            var response = _backOfficeServices.SaveQuestionsSet(new QuestionsSetDTO());

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.InternalError, response.Code);
        }


        [Test]
        public void UpdateQuestionsSetDataShouldReturnOk()
        {
            _questionSetServiceMock.Setup(service => service.UpdateQuestionsSetData(It.IsAny<string>())).Returns(ResponseDTO.Ok(""));
            var response = _backOfficeServices.UpdateQuestionsSetData("abcd1234__efg");

            Assert.IsTrue(response.Success);
            Assert.AreEqual(ResponseCode.Ok, response.Code);
        }

        [Test]
        public void UpdateQuestionsSetDataShouldReturnInternalError()
        {
            _questionSetServiceMock.Setup(service => service.UpdateQuestionsSetData(It.IsAny<string>())).Throws(new Exception());
            var response = _backOfficeServices.UpdateQuestionsSetData("abcd1234__efg");

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.InternalError, response.Code);
        }
    }
}
