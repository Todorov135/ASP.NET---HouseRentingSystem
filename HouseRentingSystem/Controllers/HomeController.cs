namespace HouseRentingSystem.Controllers
{
    using HouseRentingSystem.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IHouseService houseService;
        public HomeController(IHouseService _houseService)
        {
            this.houseService = _houseService;
        }
        public IActionResult Index()
        {
            var houses = houseService.LastThreeHouses();
            return View(houses);
        }
    }
}
