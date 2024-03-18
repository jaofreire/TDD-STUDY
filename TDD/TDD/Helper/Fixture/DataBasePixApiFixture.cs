using Microsoft.EntityFrameworkCore;
using PixApi.Data;
using PixApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Helper.Fixture
{
    public class DataBasePixApiFixture
    {
        private const string _connectionStrings = "Server=./;Database=Db_PixApi;User Id=sa;Password=sa123456;TrustServerCertificate=True";

        private static object _lock = new object();
        private static bool _dataBaseInitialize;

        public DataBasePixApiFixture()
        {
            lock (_lock)
            {
                if (!_dataBaseInitialize)
                {
                    using var context = CreateContext();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    context.AddRange
                        (
                        new KeyModel()
                        {
                            TypeKey = "CPF",
                            Key = "64304957431"
                        }
                        );
                    context.SaveChanges();
                }
            }
        }

        public ApiDbContext CreateContext()
        {
            return new ApiDbContext(new DbContextOptionsBuilder<ApiDbContext>().UseSqlServer(_connectionStrings).Options);
        }

    }
}
