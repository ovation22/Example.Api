using Example.Api.Controllers;
using Example.Core.Interfaces;
using Moq;

namespace Example.Api.UnitTests.Controllers.UsersControllerTests
{
    public class UsersControllerTestBase
    {
        protected internal UsersController Controller;
        protected internal Mock<IUserService> UserService;
        protected internal Mock<ILoggerAdapter<UsersController>> Logger;

        public UsersControllerTestBase()
        {
            UserService = new Mock<IUserService>();
            Logger = new Mock<ILoggerAdapter<UsersController>>();

            Controller = new UsersController(UserService.Object, Logger.Object);
        }
    }
}
