using Example.Core.Interfaces;
using Example.Core.Services;
using Moq;

namespace Example.Api.UnitTests.Services.UserServiceTests
{
    public class UserServiceTestBase
    {
        protected internal UserService Service;
        protected internal Mock<IEFRepository> Repository;

        public UserServiceTestBase()
        {
            Repository = new Mock<IEFRepository>();

            Service = new UserService(Repository.Object);
        }
    }
}
