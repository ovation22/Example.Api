using System.Threading.Tasks;
using Example.Core.DTOs;
using Example.Core.Entities;
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
            var community = await _repository.Get<User>(x => x.EmailAddress == emailAddress);

            return new UserResult
            {
                Id = community.Id
            };
        }

        public Task Create(NewUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}
