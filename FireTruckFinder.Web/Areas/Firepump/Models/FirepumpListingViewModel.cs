namespace FireTruckFinder.Web.Areas.Firepump.Models
{
    using FireTruckFinder.Services.Models.Firepump;
    using System;
    using System.Collections.Generic;

    public class FirepumpListingViewModel
    {
        public IEnumerable<FirepumpListingServiceModel> Firepumps { get; set; }

        public int TotalFirepumps { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalFirepumps / 25);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
