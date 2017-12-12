namespace FireTruckFinder.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class FireTruckFinderDbContext : IdentityDbContext<User>
    {
        public FireTruckFinderDbContext(DbContextOptions<FireTruckFinderDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
