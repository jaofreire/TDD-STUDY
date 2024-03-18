using Domain.Models;
using Services.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> Add(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
