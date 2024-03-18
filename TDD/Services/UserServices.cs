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

        public async Task<bool> AddUser(UserModel model)
        {
            var userExist = await _repository.GetUserByName(model.Name);
            if(userExist != null) return false;

            var newUser = new UserModel()
            {
                Id = 1,
                Name = model.Name,
                Password = model.Password
            };

            var sucess = await _repository.Add(newUser);
            return sucess;

        }
    }
}
