using System.Linq;
using NUnit.Framework;
using TdP2019TPFinalRichieri.DAL;
using TdP2019TPFinalRichieri.Services;
using TdP2019TPFinalRichieri.Mapper;
using System.Collections.Generic;
using TdP2019TPFinalRichieri.Entities;
using TdP2019TPFinalRichieri.DTO;
using Moq;
using System;
using TdP2019TPFinalRichieri.Services.QuestionsSetImporter.Factory;
using TdP2019TPFinalRichieri.Services.QuestionsSetImporter;
using TdP2019TPFinalRichieri.Exceptions;

namespace TdP2019TPFinalRichieriTests.Services
{
    [TestFixture]
    public class QuestionsSetServiceTest
    {
        private Mock<IQuestionsSetRepository> _repositoryMock = new Mock<IQuestionsSetRepository>();
        private Mock<IQuestionsSetImporterFactory> _qsImporterFactoryMock = new Mock<IQuestionsSetImporterFactory>();

        private IQuestionsSetService _service;

        [SetUp]
        public void SetUp()
        {
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(bUoW => bUoW.QuestionsSetRepository)
                            .Returns(_repositoryMock.Object);


            Mock<IUnitOfWorkFactory> unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory>();
            unitOfWorkFactoryMock.Setup(factory => factory.GetUnitOfWork())
                                    .Returns(unitOfWorkMock.Object);

            var unitOfWorkFactory = unitOfWorkFactoryMock.Object;
            IMapperFactory mapperFactory = new TriviaMapperFactory();

            this._service = new QuestionsSetService(unitOfWorkFactory, mapperFactory, _qsImporterFactoryMock.Object);
        }


        /// <summary>
        /// Test correct operation when there are no question sets in the repository.
        /// </summary>
        [Test]
        public void GetQuestionsSetsShouldThrowNoContentException()
        {
            _repositoryMock.Setup(repo => repo.GetAll()).Returns(new List<QuestionsSet>());
            Assert.Throws<NoContentException>(() => _service.GetQuestionsSets());
        }


        /// <summary>
        /// Get the questions sets should be ok.
        /// </summary>
        [Test]
        public void GetQuestionsSetsShouldBeOk()
        {
            List<QuestionsSet> questionsSets = new List<QuestionsSet>
            {
                new QuestionsSet
                {
                    Id = 1,
                    Name = "Test Questions Set 1"
                },
                new QuestionsSet
                {
                    Id = 2,
                    Name = "Test Questions Set 2"
                }
            };
            _repositoryMock.Setup(repo => repo.GetAll()).Returns(questionsSets);
            ResponseDTO<IEnumerable<QuestionsSetDTO>> response = _service.GetQuestionsSets();

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Data.Any());
            Assert.AreEqual(1, response.Data.First().Id);
            Assert.AreEqual("Test Questions Set 1", response.Data.First().Name);
            Assert.AreEqual(2, response.Data.ElementAt(1).Id);
            Assert.AreEqual("Test Questions Set 2", response.Data.ElementAt(1).Name);
        }


        /// <summary>
        /// Test if NotImplementedException is thrown when there is no 
        /// importer defined for the given question set name.
        /// </summary>
        [Test]
        public void UpdateDataShouldThrowNotImplementedException()
        {
            _qsImporterFactoryMock.Setup(mock => mock.GetImporter(It.IsAny<string>())).Throws(new NotImplementedException());
            Assert.Throws<NotImplementedException>(() => _service.UpdateQuestionsSetData("ABCD1234"));
        }


        [Test]
        public void UpdateDataShouldBeOk()
        {
            var importerMock = new Mock<IQuestionsSetImporter>();
            _qsImporterFactoryMock.Setup(mock => mock.GetImporter(It.IsAny<string>())).Returns(importerMock.Object);
            ResponseDTO<object> response = _service.UpdateQuestionsSetData("ABCD1234");

            Assert.IsTrue(response.Success);
        }

        [Test]
        public void SaveShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => _service.Save(null));
        }

        [Test]
        public void SaveShouldThrowNotFoundException()
        {
            _repositoryMock.Setup(repository => repository.Get(It.IsAny<int>())).Returns((QuestionsSet) null);
            QuestionsSet questionsSet = new QuestionsSet { Id = 1 };
            Assert.Throws<NotFoundException>(() => _service.Save(questionsSet));
        }

        [Test]
        public void SaveShouldBeOk()
        {
            QuestionsSet questionsSet = new QuestionsSet { Id = 1 };
            _repositoryMock.Setup(repository => repository.Get(It.IsAny<int>())).Returns(new QuestionsSet());
            var response = _service.Save(questionsSet);
            Assert.IsTrue(response.Success);
        }

    }
}
