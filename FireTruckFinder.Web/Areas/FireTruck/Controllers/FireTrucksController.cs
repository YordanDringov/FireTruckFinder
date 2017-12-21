namespace FireTruckFinder.Web.Areas.FireTruck.Controllers
{
    using FireTruckFinder.Data.Models;
    using FireTruckFinder.Services;
    using Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;

    using static WebConstants;

    [Authorize]
    [Area(FireTruckArea)]
    public class FireTrucksController : Controller
    {
        private readonly IFireTruckService firetrucks;
        private readonly UserManager<User> userManager;

        public FireTrucksController(IFireTruckService firetrucks, UserManager<User> userManager)
        {
            this.firetrucks = firetrucks;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
            => View(new FireTruckListingViewModel
            {
                FireTrucks = await firetrucks.AllAsync(page),
                TotalFireTrucks = await this.firetrucks.TotalAsync(),
                CurrentPage = page
            });
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.firetrucks.ById(id));


        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(FireTruckCreateViewModel firetruckModel)
        {

            var sellerId = userManager.GetUserId(User);

            await this.firetrucks.CreateAsync(firetruckModel.Make, firetruckModel.Model, firetruckModel.WatertankCapacity, firetruckModel.ProduceDate, firetruckModel.Price, firetruckModel.ImageUrl, sellerId);

            return RedirectToAction(nameof(Index));
        }
    }
}
