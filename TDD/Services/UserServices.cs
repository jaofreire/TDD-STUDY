using Domain.Models;
using Services.Repositories.Interface;

namespace Services
{
    public class UserServices
    {
        private readonly IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var user = await _repository.GetUserByName(username);
            if(user == null) return false;

            var sucess = await _repository.AuthenticateUser(username, password);
            return sucess;
        }
    }
}
