using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Example.Api.UnitTests.Controllers.UsersControllerTests
{
    public class Get : UsersControllerTestBase
    {
        private readonly Guid _id;

        public Get()
        {
            _id = new Guid("2A1F63DE-E76C-4CBD-9B21-B40ABF729490");
        }

        [Fact]
        public async Task ItReturnsOkObjectResult()
        {
            // Arrange
            // Act
            var result = await Controller.Get(_id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task ItGetsUser()
        {
            // Arrange
            // Act
            await Controller.Get(_id);

            // Assert
            UserService.Verify(x => x.Get(_id), Times.Once());
        }
    }
}
