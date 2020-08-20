using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Example.Core.DTOs;
using Example.Core.Entities;
using Moq;
using Xunit;

namespace Example.Api.UnitTests.Services.UserServiceTests
{
    public class Create : UserServiceTestBase
    {
        private readonly Guid _id;
        private readonly User _user;
        private readonly NewUser _newUser;
        private readonly string _emailAddress;

        public Create()
        {
            _id = new Guid("B703FC6F-B72D-4048-9FEA-5264A50F8363");
            _emailAddress = "bill@gates.com";
            _user = new User
            {
                Id = _id
            };
            _newUser = new NewUser
            {
                EmailAddress = _emailAddress
            };

            Repository.Setup(x => x.Add(It.IsAny<User>())).ReturnsAsync(_user);
        }

        [Fact]
        public async Task ItReturnsUser()
        {
            // Arrange
            // Act
            var user = await Service.Create(_newUser);

            // Assert
            Assert.NotNull(user);
            Assert.IsAssignableFrom<UserResult>(user);
        }
    }
}
