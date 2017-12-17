namespace FireTruckFinder.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddUserToRoleFormModel
    {
        [Required]
        public string Role { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
