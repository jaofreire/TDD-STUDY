using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Helper.TestsDoubles.Spy;

namespace TDD.Helper.TestsDoubles.Mock
{
    public class UserRepositoryMock : UserRepositorySpy
    {
        public string expectedName;
        public string expectedPassword;
        public int expectedCount;

        public UserRepositoryMock(string expectedName, string expectedPassword, int expectedCount)
        {
            this.expectedName = expectedName;
            this.expectedPassword = expectedPassword;
            this.expectedCount = expectedCount;
        }

        public bool Validate()
        {
            return expectedName == GetName() &&
                expectedPassword == GetPassword() &&
                expectedCount == GetCount();
        }
    }
}
