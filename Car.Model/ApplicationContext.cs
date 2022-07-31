using Microsoft.EntityFrameworkCore;

namespace Car.Model
{
    internal class ApplicationContext:DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<CarC> Cars { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext): base(dbContext)
            => Database.EnsureCreated();


    }
}
