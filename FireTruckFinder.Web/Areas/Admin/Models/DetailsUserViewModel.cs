namespace FireTruckFinder.Web.Areas.Admin.Models
{
    using FireTruckFinder.Services.Admin.Models;
    using System.Collections.Generic;

    public class DetailsUserViewModel
    {
        public IEnumerable<AdminUserDetailsServiceModel> Users { get; set; }
    }
}
