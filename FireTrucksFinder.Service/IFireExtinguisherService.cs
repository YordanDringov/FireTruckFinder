using FireTruckFinder.Data.Models;
using FireTruckFinder.Services.Models.FireExtinguisher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireTruckFinder.Services
{
   public interface IFireExtinguisherService
    {
        Task<IEnumerable<FireExtinguisherListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<FireExtinguisherDetailsServiceModel> ById(int id);

        Task CreateAsync(FireExtinguisherType type, double price, string imageUrl, string sellerId);
    }
}
