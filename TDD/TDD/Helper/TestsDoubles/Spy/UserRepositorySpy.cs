using Domain.Models;
using Services.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Helper.TestsDoubles.Spy
{
    public class UserRepositorySpy : IUserRepository
    {
        public string? lastName;
        public string? lastPassword;
        public int countCall;
        public bool result;

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            lastName = username;
            lastPassword = password;
            countCall++;
            SetResult(true);
            return result;
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            return new UserModel()
            {
                Id = 1,
                Name = "joao",
                Password = "123"
            };
        }

        public void SetResult(bool re)
        {
            result = re;
        }

        public string GetName() => lastName;
        public string GetPassword() => lastPassword;
        public int GetCount() => countCall;
    }
}
