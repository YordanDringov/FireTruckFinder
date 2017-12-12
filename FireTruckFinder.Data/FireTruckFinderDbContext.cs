namespace FireTruckFinder.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class FireTruckFinderDbContext : IdentityDbContext<User>
    {
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<FirePump> FirePumps { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seller> Sellers { get; set; }

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
