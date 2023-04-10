using Microsoft.EntityFrameworkCore;
using MyCookBook.Domain.Entities;

namespace MyCookBook.Infrastructure.Context
{
	public class MyCookBookContext : DbContext
	{
        public MyCookBookContext(DbContextOptions<MyCookBookContext> options): base(options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyCookBookContext).Assembly);
        }
    }
}
