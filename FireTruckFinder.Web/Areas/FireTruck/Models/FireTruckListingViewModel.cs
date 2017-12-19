using FireTruckFinder.Services.Models.FireTruck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireTruckFinder.Web.Areas.FireTruck.Models
{
    public class FireTruckListingViewModel
    {
        public IEnumerable<FireTruckListingServiceModel> FireTrucks { get; set; }

        public int TotalFireTrucks { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalFireTrucks / 25);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
