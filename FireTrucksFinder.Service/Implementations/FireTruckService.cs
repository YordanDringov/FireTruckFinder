namespace FireTruckFinder.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using FireTruckFinder.Services.Models.FireTruck;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FireTruckService : IFireTruckService
    {
        private readonly FireTruckFinderDbContext db;

        public FireTruckService(FireTruckFinderDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<FireTruckListingServiceModel>> AllAsync(int page = 1)
        => await this.db
                .FireTrucks
                .OrderByDescending(f => f.ProduceDate)
                .Skip((page - 1) * 25)
                .Take(25)
                .ProjectTo<FireTruckListingServiceModel>()
                .ToListAsync();



        public  async Task<FireTruckDetailsServiceModel> ById(int id)
        =>  await  this.db
                   .FireTrucks
                   .Where(f => f.Id == id)
                   .ProjectTo<FireTruckDetailsServiceModel>()
                   .FirstOrDefaultAsync();




        public async Task CreateAsync(string make, string model, int watertankCapacity, DateTime produceDate, double price, string sellerId)
        {
            var firetruck = new FireTruck
            {
                Make = make,
                Model = model,
                WatertankCapacity = watertankCapacity,
                ProduceDate = produceDate,
                Price = price,
                SellerId = sellerId
            };
            this.db.Add(firetruck);

            await this.db.SaveChangesAsync();
        }

        public async Task<int> TotalAsync()
            => await this.db.FireTrucks.CountAsync();








        //public void Delete(int id)
        //{
        //    var firetruck = this.db.FireTrucks.Find(id);

        //    this.db.FireTrucks.Remove(firetruck);
        //    this.db.SaveChanges();
        //}
    }
}
