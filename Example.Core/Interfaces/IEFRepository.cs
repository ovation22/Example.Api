using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Example.Core.Interfaces
{
    public interface IEFRepository
    {
        Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<T> Add<T>(T entity) where T : class;
    }
}
