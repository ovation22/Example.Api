using System.Threading.Tasks;
using Example.Core.DTOs;

namespace Example.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserResult> Get(string emailAddress);
        Task Create(NewUser user);
    }
}
