namespace FireTruckFinder.Services
{
    using Admin.Models;
    using System.Collections.Generic;

    public interface IAdminUserService
    {
        IEnumerable<AdminUserListingServiceModel> All();
    }
}
