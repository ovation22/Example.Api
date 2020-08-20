using System;
using System.Threading.Tasks;
using Example.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Example.Api.UnitTests.Controllers.UsersControllerTests
{
    public class Create : UsersControllerTestBase
    {
        private readonly NewUser _newUser;

        public Create()
        {
            _newUser = new NewUser();
        }

        [Fact]
        public async Task ItReturnsAcceptedResult()
        {
            // Arrange
            // Act
            var result = await Controller.Create(_newUser);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GivenException_ThenBadRequestResult()
        {
            // Arrange
            UserService.Setup(x => x.Create(_newUser)).Throws(new Exception());

            // Act
            var result = await Controller.Create(_newUser);

            // Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GivenException_ThenItLogsError()
        {
            // Arrange
            var ex = new Exception();
            UserService.Setup(x => x.Create(_newUser)).Throws(ex);

            // Act
            await Controller.Create(_newUser);

            // Assert
            Logger.Verify(x => x.LogError(ex, ex.Message), Times.Once());
        }
    }
}
