using Example.Api.Controllers;
using Example.Core.Interfaces;
using Moq;

namespace Example.Api.UnitTests.Controllers.UsersControllerTests
{
    public class UsersControllerTestBase
    {
        protected internal UsersController Controller;
        protected internal Mock<IUserService> UserService;

        public UsersControllerTestBase()
        {
            UserService = new Mock<IUserService>();

            Controller = new UsersController(UserService.Object);
        }
    }
}
