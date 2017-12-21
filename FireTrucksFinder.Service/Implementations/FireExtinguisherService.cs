namespace FireTruckFinder.Services.Implementations
{
    using FireTruckFinder.Data;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using FireTruckFinder.Services.Models.FireExtinguisher;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FireTruckFinder.Data.Models;

    public class FireExtinguisherService : IFireExtinguisherService
    {
        private readonly FireTruckFinderDbContext db;

        public FireExtinguisherService(FireTruckFinderDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<FireExtinguisherListingServiceModel>> AllAsync(int page = 1)
            => await this.db
            .FireExtinguishers
            .Skip((page - 1) * 25)
                .Take(25)
                .ProjectTo<FireExtinguisherListingServiceModel>()
                .ToListAsync();


        public async Task<FireExtinguisherDetailsServiceModel> ById(int id)
            => await this.db
                   .FireExtinguishers
                   .Where(f => f.Id == id)
                   .ProjectTo<FireExtinguisherDetailsServiceModel>()
                   .FirstOrDefaultAsync();


        public async Task CreateAsync(FireExtinguisherType type, double price, string imageUrl, string sellerId)
        {
            var fireExtinguisher = new FireExtinguisher
            {
                Type = type,
                Price = price,
                ImageUrl = imageUrl,
                SellerId = sellerId
            };
            this.db.Add(fireExtinguisher);

            await this.db.SaveChangesAsync();
        }

        public async Task<int> TotalAsync()
            => await this.db.FireExtinguishers.CountAsync();
    }
}
