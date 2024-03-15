using Domain.Models;
using Services.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Helper.TestsDoubles.Stub
{
    public class UserRepositoryStub : IUserRepository
    {
        public async Task<bool> AuthenticateUser(string username, string password)
        {
            return false;
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            return new UserModel();
        }
    }
}
