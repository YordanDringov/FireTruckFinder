namespace FireTruckFinder.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class FireTruckFinderDbContext : IdentityDbContext<User>
    {
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<FirePump> FirePumps { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Sellers { get; set; }

        public FireTruckFinderDbContext(DbContextOptions<FireTruckFinderDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Firetruck -- Firepump / one-to-many rel

            builder.Entity<FireTruck>()
                .HasOne<FirePump>(ft => ft.Pump)
                .WithMany(fp => fp.Firetrucks)
                .HasForeignKey(ft => ft.PumpId);

            //Sale -- FireTruck / one-to-one rel

            builder.Entity<Sale>()
                .HasOne(s => s.FireTruck)
                .WithOne(ft => ft.Sale)
                .HasForeignKey<FireTruck>(ft => ft.SaleId);

            // Sale -- Seller / one to many rel

            builder.Entity<Sale>()
                .HasOne(s => s.Seller)
                .WithMany(sl => sl.Sales)
                .HasForeignKey(s => s.SellerId);

            base.OnModelCreating(builder);
        }
    }
}
