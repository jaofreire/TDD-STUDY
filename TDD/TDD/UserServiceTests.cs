using Domain.Models;
using Moq;
using Services;
using Services.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Helper.TestsDoubles.Dummy;
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
            var service = new UserServices(_userRepositoryMock.Object);

            
            _userRepositoryMock.Setup(x => x.GetUserByName(username)).ReturnsAsync(new UserModel());
            _userRepositoryMock.Setup(x => x.AuthenticateUser(username, password)).ReturnsAsync(true);

        }
    }
}
