using Domain.Models;
using Moq;
using Services;
using Services.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Helper.Fixture;
using TDD.Helper.TestsDoubles.Dummy;
using TDD.Helper.TestsDoubles.Fakes;
using TDD.Helper.TestsDoubles.Mock;
using TDD.Helper.TestsDoubles.Spy;
using TDD.Helper.TestsDoubles.Stub;

namespace TDD
{
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task AuthenticateUser_NotExist_ReturnFalse()
        {
            var username = "joao";
            var password = "123";
            var repository = new UserRepositoryDummy();
            var service = new UserServices(repository);

            var response = await service.Authenticate(username, password);

            Assert.False(response);

        }

        [Fact]
        public async Task Authenticate_LoginIsInvalid_ReturnFalse()
        {

            var username = "joao";
            var password = "123";
            var repository = new UserRepositoryStub();
            var service = new UserServices(repository);

            var response = await service.Authenticate(username, password);

            Assert.False(response);

        }

        [Fact]
        public async Task Authenticate_ParamIsCorrectWithMock_ReturnTrue()
        {

            var username = "joao";
            var password = "123";
            
            _userRepositoryMock.Setup(x => x.GetUserByName(username)).ReturnsAsync(new UserModel()
            {
                Id = 1,
                Name = username,
                Password = password,
            });
            _userRepositoryMock.Setup(x => x.AuthenticateUser(username, password)).ReturnsAsync(true);

            var service = new UserServices(_userRepositoryMock.Object);

            var response = await service.Authenticate(username, password);

            Assert.True(response);

        }

        [Fact]
        public async Task Authenticate_CredentialsIsValid_ReturnTrue()
        {
            var username = "joao";
            var password = "123";
            var repository = new UserRepositoryFakes();
            var service = new UserServices(repository);

            var response = await service.Authenticate(username,password);

            Assert.True(response);

        }

        [Fact]
        public async Task Authenticate_CredentialsIsInvalid_ReturnFalse()
        {
            var username = "joao";
            var password = "12345";
            var repository = new UserRepositoryFakes();
            var service = new UserServices(repository);

            var response = await service.Authenticate(username, password);

            Assert.False(response);

        }

        [Fact]
        public async Task Add_UserIsValid_ReturnTrue()
        {
            var username = "joao";
            var password = "123";

            _userRepositoryMock.Setup(x => x.GetUserByName(username)).ReturnsAsync(new UserModel());
            _userRepositoryMock.Setup(x => x.Add(It.IsAny<UserModel>())).ReturnsAsync(true);
            var service = new UserServices(_userRepositoryMock.Object);
            var model = UserModelFixture.GetUserModelValid();

            var response = await service.AddUser(model);

            Assert.True(response);

        }
    }
}
