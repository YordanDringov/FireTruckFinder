namespace FireTruckFinder.Services.Admin.Models
{
    using Common.Mapping;
    using Data.Models;
    using System;
    using System.Collections.Generic;

    public class AdminUserDetailsServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public DateTime BirtDate { get; set; }
    }
}
