using System.Threading.Tasks;
using Example.Core.DTOs;
using Example.Core.Entities;
using Example.Core.Exceptions;
using Example.Core.Interfaces;

namespace Example.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IEFRepository _repository;

        public UserService(
            IEFRepository repository
        )
        {
            _repository = repository;
        }

        public async Task<UserResult> Get(string emailAddress)
        {
            var user = await _repository.Get<User>(x => x.EmailAddress == emailAddress);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            return new UserResult
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                Name = user.Name,
                Phone = user.Phone
            };
        }

        public async Task<UserResult> Create(NewUser newUser)
        {
            var user = new User
            {
                Name = newUser.Name,
                Phone = newUser.Phone,
                EmailAddress = newUser.EmailAddress
            };

            var userResult = await _repository.Add(user);

            return new UserResult
            {
                Id = userResult.Id,
                EmailAddress = userResult.EmailAddress,
                Name = userResult.Name,
                Phone = userResult.Phone
            };
        }
    }
}
