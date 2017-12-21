namespace FireTruckFinder.Web.Areas.FireExtinguisher.Models
{
    using Services.Models.FireExtinguisher;
    using System;
    using System.Collections.Generic;

    public class FireExtinguisherListingViewModel
    {
        public IEnumerable<FireExtinguisherListingServiceModel> FireExtinguishers { get; set; }

        public int TotalFireExtinguishers { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalFireExtinguishers / 25);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
