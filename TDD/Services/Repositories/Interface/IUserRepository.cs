using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByName(string username);
        Task<bool> AuthenticateUser(string username, string password);
        Task<bool> Add(UserModel user);
    }
}
