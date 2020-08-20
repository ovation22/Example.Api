using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Example.Core.DTOs;
using Xunit;

namespace Example.Api.IntegrationTests
{
    public class UserTests :
        IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup>
            _factory;

        public UserTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_NewUser_ReturnsAccepted()
        {
            // Arrange
            var newUser = new NewUser
            {
                EmailAddress = "senior@gates.com",
                Phone = "555-1212",
                FirstName = "bill",
                MiddleName = 'F',
                LastName = "Gates"
            };
            HttpContent content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("api/Users", content);

            // Assert
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Fact]
        public async Task GivenNewUserIsNotValid_BadResult()
        {
            // Arrange
            var newUser = new NewUser
            {
                EmailAddress = "steve@jobs.com",
                Phone = "555-1212",
                FirstName = "bill",
                MiddleName = 'F',
                LastName = "Gates"
            };
            HttpContent content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("api/Users", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GivenUserEmailAlreadyExists_BadResult()
        {
            // Arrange
            var newUser = new NewUser
            {
                EmailAddress = "billy"
            };
            HttpContent content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("api/Users", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_NewUser_ReturnsOk()
        {
            // Arrange
            const string emailAddress = "steve@jobs.com";

            //Act
            var response = await _client.GetAsync($"api/Users?emailAddress={emailAddress}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GivenUserDoesNotExist_ThenBadResult()
        {
            // Arrange
            const string emailAddress = "steve@woz.com";

            //Act
            var response = await _client.GetAsync($"api/Users?emailAddress={emailAddress}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}