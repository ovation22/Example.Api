using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Example.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.Data
{
    public class EFRepository : IEFRepository
    {
        private readonly DefaultContext _context;

        public EFRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : class
        {
            var dbSet = _context.Set<T>();

            return await dbSet.SingleOrDefaultAsync(expression);
        }
        
        public async Task<T> Add<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
