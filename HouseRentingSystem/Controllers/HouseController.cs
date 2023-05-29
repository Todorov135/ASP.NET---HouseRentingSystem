﻿namespace HouseRentingSystem.Controllers
{
    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Core.Models.House;
    using HouseRentingSystem.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class HouseController : Controller
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HouseController(
            IHouseService houseService, 
            IAgentService agent)
        {
            this.houseService = houseService;
            this.agentService = agent;
        }

        [AllowAnonymous]
        public IActionResult AllHouses()
        {
            return View();
        }
        public IActionResult MyHouses()
        {
            return View();
        }

        public async Task<IActionResult> Add() 
        {
            var model = new HouseFormModel();
            model.Categories = await houseService.AlLCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel house)
        {
            if (!agentService.ExistsById(this.User.Id()))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }
            if (!ModelState.IsValid)
            {
                house.Categories = await houseService.AlLCategories();
                return View(house);
            }
            if (!(await houseService.IsValidCategory(house.CategoryId)))
            {
                ModelState.AddModelError(nameof(house.CategoryId), "Category does not exists");
                return BadRequest();
            }

            int agentId = agentService.GetAgentId(this.User.Id());

            int newHouseId = await houseService.Create(house.Title, house.Address, house.Description, house.ImageUrl, house.PricePerMonth, house.CategoryId, agentId);         
            
            

            return RedirectToAction(nameof(Details), newHouseId);
        }
        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Edit(int id) => View(new HouseFormModel());

        [HttpPost]
        public IActionResult Edit(int id, HouseFormModel hosue)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        public IActionResult Delete(int id) => View(new HouseDetailsViewModel());

        public IActionResult Delete(HouseDetailsViewModel house)
        {
            return RedirectToAction(nameof(AllHouses));
        }

        [HttpPost]
        public IActionResult Rent(int id)
        {
            return RedirectToAction(nameof(MyHouses));
        }

        [HttpPost]
        public IActionResult Leave(int id)
        {
            return RedirectToAction(nameof(MyHouses));
        }

    }
}
