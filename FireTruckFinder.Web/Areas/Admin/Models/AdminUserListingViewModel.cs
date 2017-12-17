namespace FireTruckFinder.Web.Areas.Admin.Models
{
    using System.Collections.Generic;
    using FireTruckFinder.Services.Admin.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AdminUserListingViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
