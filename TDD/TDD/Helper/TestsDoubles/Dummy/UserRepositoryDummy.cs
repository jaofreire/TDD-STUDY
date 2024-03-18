using Domain.Models;
using Services.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Helper.TestsDoubles.Dummy
{
    public class UserRepositoryDummy : IUserRepository
    {
        public Task<bool> Add(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            return null;
        }
    }
}
