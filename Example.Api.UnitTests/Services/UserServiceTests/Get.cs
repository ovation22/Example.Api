using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Example.Core.DTOs;
using Example.Core.Entities;
using Moq;
using Xunit;

namespace Example.Api.UnitTests.Services.UserServiceTests
{
    public class Get : UserServiceTestBase
    {
        private readonly Guid _id;
        private readonly User _user;
        private readonly string _emailAddress;

        public Get()
        {
            _id = new Guid("B703FC6F-B72D-4048-9FEA-5264A50F8363");
            _emailAddress = "bill@gates.com";
            _user = new User
            {
                Id = _id
            };

            Repository.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(_user);
        }

        [Fact]
        public async Task ItReturnsUser()
        {
            // Arrange
            // Act
            var user = await Service.Get(_emailAddress);

            // Assert
            Assert.NotNull(user);
            Assert.IsAssignableFrom<UserResult>(user);
        }
    }
}
