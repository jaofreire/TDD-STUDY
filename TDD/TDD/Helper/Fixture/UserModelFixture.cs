using Bogus;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Helper.Fixture
{
    public static class UserModelFixture
    {
        public static UserModel GetUserModelValid()
        {
            var faker = new Faker<UserModel>();
            faker.RuleFor(x => x.Name, r => r.Random.String(5));
            faker.RuleFor(x => x.Password, r => r.Random.String(12));
            return faker;
        }
    }
}
