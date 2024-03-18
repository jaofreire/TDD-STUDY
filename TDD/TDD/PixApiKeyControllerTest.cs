using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PixApi.Controllers;
using PixApi.Models;
using PixApi.Repositories;
using PixApi.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Helper.Fixture;

namespace TDD
{
    public class PixApiKeyControllerTest : IClassFixture<DataBasePixApiFixture>
    {
        public DataBasePixApiFixture Fixture { get; set; }

        public PixApiKeyControllerTest(DataBasePixApiFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async void GetKeyByExpecifKey_ReturnKey_Sucess()
        {
            var context = Fixture.CreateContext();
            var validator = new KeyValidations();
            var repository = new KeyRepository(context);
            var controller = new KeyController(repository, validator);
            var key = "64304957431";

            var result = await controller.GetExpecifcKey(key);


            Assert.Equal(key, result.Value.FirstOrDefault(x => x.Key == key).Key);
        }

        [Fact]
        public async void RegisterNewKey_InvalidKey_ReturnValidationProblem()
        {
            var context = Fixture.CreateContext();
            var validator = new KeyValidations();
            var repository = new KeyRepository(context);
            var controller = new KeyController(repository, validator);
            var typeKey = "CPF";
            var key = "5467";

            var newModel = new KeyModel()
            {
                TypeKey = typeKey,
                Key = key
            };

            var result = await controller.RegisterNewKey(newModel);

            Assert.IsType<ProblemHttpResult>(result);
        }

        [Fact]
        public async void RegisterNewKey_ValidKey_OkResult()
        {
            var context = Fixture.CreateContext();
            var validator = new KeyValidations();
            var repository = new KeyRepository(context);
            var controller = new KeyController(repository, validator);
            var typeKey = "CPF";
            var key = "12615867431";

            var newModel = new KeyModel()
            {
                TypeKey = typeKey,
                Key = key
            };

            var result = await controller.RegisterNewKey(newModel);

            Assert.IsType<Ok<KeyModel>>(result);
        }
    }
}
