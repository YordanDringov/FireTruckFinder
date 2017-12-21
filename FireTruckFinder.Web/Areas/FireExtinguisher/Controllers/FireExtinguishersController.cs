namespace FireTruckFinder.Web.Areas.FireExtinguisher.Controllers
{
    using FireTruckFinder.Data.Models;
    using FireTruckFinder.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using static WebConstants;
    using Models;

    [Authorize]
    [Area(FirepumpArea)]
    public class FireExtinguishersController : Controller
    {
        private readonly IFireExtinguisherService fireExtinguishers;
        private readonly UserManager<User> userManager;

        public FireExtinguishersController(IFireExtinguisherService fireExtinguishers, UserManager<User> userManager)
        {
            this.fireExtinguishers = fireExtinguishers;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
            => View(new FireExtinguisherListingViewModel
            {
                FireExtinguishers = await fireExtinguishers.AllAsync(page),
                TotalFireExtinguishers = await this.fireExtinguishers.TotalAsync(),
                CurrentPage = page
            });

        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.fireExtinguishers.ById(id));

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(FireExtinguisherCreateViewModel fireExtinguisher)
        {

            var sellerId = userManager.GetUserId(User);

            await this.fireExtinguishers.CreateAsync(fireExtinguisher.Type, fireExtinguisher.Price,
                fireExtinguisher.ImageUrl, fireExtinguisher.SellerId);

            return RedirectToAction(nameof(Index));
        }
    }
}
 
