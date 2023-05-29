namespace HouseRentingSystem.Controllers
{
    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Core.Models.Agent;
    using HouseRentingSystem.Infrastructure;
 
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            this.agentService = _agentService;
        }

        public IActionResult Become()
        {
            if(agentService.ExistsById(this.User.Id()))
            {
                return BadRequest();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Become(BecomeAgentFormModel agent)
        {
            var userId = this.User.Id();

            if (!this.agentService.ExistsById(userId))
            {
                return BadRequest();
            }
            if (this.agentService.UserWithPhoneNumberExists(agent.PhoneNumber))
            {
                ModelState.AddModelError(nameof(agent.PhoneNumber), "Phone number already exists. Enter another one.");
            }
            if (this.agentService.UserHasRents(userId))
            {
                ModelState.AddModelError("Error", "You should have no rents to become agent");
            }
            if (!ModelState.IsValid)
            {
                return View(agent);
            }
            this.agentService.Create(userId, agent.PhoneNumber);

            return RedirectToAction(nameof(HouseController.AllHouses), "House");
        }
    }
}
