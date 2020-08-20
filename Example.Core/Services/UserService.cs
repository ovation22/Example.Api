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
                throw new UserNotFoundException($"User not found with email address: {emailAddress}");
            }

            return MapUserResult(user);
        }

        public async Task<UserResult> Create(NewUser newUser)
        {
            var existingUser = await _repository.Get<User>(x => x.EmailAddress == newUser.EmailAddress);

            if (existingUser != null)
            {
                throw new UserEmailAlreadyCreatedException($"User already exists with email address: {newUser.EmailAddress}");
            }

            var user = new User
            {
                FirstName = newUser.FirstName,
                MiddleName = newUser.MiddleName,
                LastName = newUser.LastName,
                Phone = newUser.Phone,
                EmailAddress = newUser.EmailAddress
            };

            return MapUserResult(await _repository.Add(user));
        }

        private static UserResult MapUserResult(User user)
        {
            return new UserResult
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                Name = $"{user.FirstName} {user.MiddleName} {user.LastName}",
                Phone = user.Phone
            };
        }
    }
}
