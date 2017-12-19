namespace FireTruckFinder.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class FireTruckFinderDbContext : IdentityDbContext<User>
    {
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<FirePump> FirePumps { get; set; }
        public DbSet<FireExtinguisher> FireExtinguishers { get; set; }
        public DbSet<User> Sellers { get; set; }

        public FireTruckFinderDbContext(DbContextOptions<FireTruckFinderDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Firetruck -- Seller / one-to-many rel

            builder.Entity<FireTruck>()
                .HasOne<User>(ft => ft.Seller)
                .WithMany(s => s.FireTrucks)
                .HasForeignKey(ft => ft.SellerId);

            //FirePump -- Seller / one-to-many rel

            builder.Entity<FirePump>()
                .HasOne(fp => fp.Seller)
                .WithMany(s => s.FirePumps)
                .HasForeignKey(fp => fp.SellerId);

            // FireExtinguisher -- Seller / one to many rel

            builder.Entity<FireExtinguisher>()
                .HasOne(f => f.Seller)
                .WithMany(s => s.FireExtinguishers)
                .HasForeignKey(f => f.SellerId);

            base.OnModelCreating(builder);
        }
    }
}
