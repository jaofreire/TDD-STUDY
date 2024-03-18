using Domain.Models;
using Services;
using Services.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Helper.TestsDoubles.Fakes
{
    public class UserRepositoryFakes : IUserRepository
    {
        public async Task<bool> AuthenticateUser(string username, string password)
        {
            return (username.Equals("joao") && password.Equals("123"));
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            return new UserModel()
            {
                Id = 1,
                Name = username
               
            };
        }

        public async Task<bool> Add(UserModel newUser)
        {
            return true;
        }
    }
}
