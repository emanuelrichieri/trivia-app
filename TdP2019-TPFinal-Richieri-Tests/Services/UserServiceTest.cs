using Moq;
using NUnit.Framework;
using TdP2019TPFinalRichieri.DAL;
using TdP2019TPFinalRichieri.DTO;
using TdP2019TPFinalRichieri.Entities;
using TdP2019TPFinalRichieri.Mapper;
using TdP2019TPFinalRichieri.Services;

namespace TdP2019TPFinalRichieriTests.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        private Mock<IUserRepository> _repositoryMock = new Mock<IUserRepository>();
        private IUserService _service;

        [SetUp]
        public void SetUp()
        {
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(bUoW => bUoW.UserRepository)
                                .Returns(_repositoryMock.Object);


            Mock<IUnitOfWorkFactory> unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory>();
            unitOfWorkFactoryMock.Setup(factory => factory.GetUnitOfWork())
                                    .Returns(unitOfWorkMock.Object);

            var unitOfWorkFactory = unitOfWorkFactoryMock.Object;
            IMapperFactory mapperFactory = new TriviaMapperFactory();

            _service = new UserService(unitOfWorkFactory, mapperFactory);
        }


        [Test]
        public void LoginShouldBeOk()
        {
            var mockUser = new User
            {
                Id = 1,
                Username = "test",
                Password = "test"
            };
            this._repositoryMock.Setup(repo => repo.Get(It.IsAny<string>())).Returns(mockUser);

            var response = this._service.Login("test", "test");

            Assert.IsTrue(response.Success);
            Assert.AreEqual("test", response.Data.Username);
        }

        [Test]
        public void LoginShouldReturnUnauthorized()
        {

            var mockUser = new User
            {
                Id = 1,
                Username = "test",
                Password = "test"
            };
            this._repositoryMock.Setup(repo => repo.Get(It.IsAny<string>())).Returns(mockUser);

            var response = this._service.Login("test", "otherPass");

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.Unauthorized, response.Code);
        }

        [Test]
        public void LoginShouldReturnNotFound()
        {
            this._repositoryMock.Setup(repo => repo.Get(It.IsAny<string>())).Returns((User) null);
            var response = this._service.Login("", "");

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.NotFound, response.Code);
        }


        [Test]
        public void SignUpShouldBeOk()
        {
            this._repositoryMock.Setup(repo => repo.Get(It.IsAny<string>())).Returns((User)null);
            var response = this._service.SignUp("newUsername", "password", "password");

            Assert.IsTrue(response.Success);
        }

        [Test]
        [TestCase(null, "123456", "123456")] // null username case
        [TestCase("ema", "12345678", "12345678")] // too short username case
        [TestCase("emanuel", "123456", "123444")] // passwords don't match case
        [TestCase("//!!emanuel", "123456", "123456")] // invalid username case
        [TestCase("emanuel", "1234", "1234")] // too short password case
        public void SignUpShouldReturnBadRequest(string pUsername, string pPassword, string pConfirmedPassword)
        {
            var response = this._service.SignUp(pUsername, pPassword, pConfirmedPassword);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseCode.BadRequest, response.Code);
        }
    }
}
