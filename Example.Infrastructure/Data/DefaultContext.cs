using Example.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; } = null!;
    }
}
