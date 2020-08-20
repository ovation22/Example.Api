using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Example.Api.UnitTests.Controllers.UsersControllerTests
{
    public class Get : UsersControllerTestBase
    {
        private readonly string _emailAddress;

        public Get()
        {
            _emailAddress = "bill@gates.com";
        }

        [Fact]
        public async Task ItReturnsOkObjectResult()
        {
            // Arrange
            // Act
            var result = await Controller.Get(_emailAddress);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task ItGetsUser()
        {
            // Arrange
            // Act
            await Controller.Get(_emailAddress);

            // Assert
            UserService.Verify(x => x.Get(_emailAddress), Times.Once());
        }
    }
}
