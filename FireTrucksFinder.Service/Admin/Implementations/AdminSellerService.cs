namespace FireTruckFinder.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminUserService : IAdminUserService
    {
        private readonly FireTruckFinderDbContext db;

        public AdminUserService(FireTruckFinderDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminUserListingServiceModel> All() => this.db
                .Sellers
                .ProjectTo<AdminUserListingServiceModel>()
                .ToList();
    }
}
