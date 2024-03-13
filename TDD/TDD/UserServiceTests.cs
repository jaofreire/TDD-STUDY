using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Helper.TestsDoubles.Dummy;

namespace TDD
{
    public class UserServiceTests
    {
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
    }
}
