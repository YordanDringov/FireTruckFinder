namespace FireTruckFinder.Web.Areas.Firepump.Controllers
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
    [Area(FirepumpArea)]
    public class FirepumpsController : Controller
    {
        private readonly IFirepumpService firepumps;
        private readonly UserManager<User> userManager;

        public FirepumpsController(IFirepumpService firepumps, UserManager<User> userManager)
        {
            this.firepumps = firepumps;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
            => View(new FirepumpListingViewModel
            {
                Firepumps = await firepumps.AllAsync(page),
                TotalFirepumps = await this.firepumps.TotalAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await firepumps.ById(id));

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(FirepumpCreateViewModel firepumpModel)
        {

            var sellerId = userManager.GetUserId(User);

            await this.firepumps.CreateAsync(firepumpModel.Model, firepumpModel.Efficiency, firepumpModel.Power, firepumpModel.Price,
                firepumpModel.ImageUrl, sellerId);

            return RedirectToAction(nameof(Index));
        }
    }
}
