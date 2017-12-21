namespace FireTruckFinder.Services.Implementations
{
    using FireTruckFinder.Data;
    using FireTruckFinder.Services.Models.Firepump;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using FireTruckFinder.Data.Models;

    public class FirepumpService : IFirepumpService
    {
        private readonly FireTruckFinderDbContext db;

        public FirepumpService(FireTruckFinderDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<FirepumpListingServiceModel>> AllAsync(int page = 1)
        => await this.db
            .FirePumps
            .Skip((page - 1) * 25)
                .Take(25)
                .ProjectTo<FirepumpListingServiceModel>()
                .ToListAsync();



        public async Task<FirepumpDetailsServiceModel> ById(int id)
        => await this.db
                   .FireTrucks
                   .Where(f => f.Id == id)
                   .ProjectTo<FirepumpDetailsServiceModel>()
                   .FirstOrDefaultAsync();


        public async Task CreateAsync(string model, double efficiency, int power, double price, string imageUrl, string sellerId)
        {
            var firepump = new FirePump
            {
                Model = model,
                Efficiency = efficiency,
                Power = power,
                Price = price,
                ImageUrl = imageUrl,
                SellerId = sellerId
            };
            this.db.Add(firepump);

            await this.db.SaveChangesAsync();
        }

        public async Task<int> TotalAsync()
            => await this.db.FirePumps.CountAsync();


    }
}
