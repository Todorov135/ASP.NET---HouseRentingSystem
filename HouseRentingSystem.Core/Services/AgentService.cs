namespace HouseRentingSystem.Core.Services
{
    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Data;
    using HouseRentingSystem.Data.Models;
    using System.Threading.Tasks;

    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext data;
        public AgentService(HouseRentingDbContext _data)
        {
            this.data = _data;
        }


        public bool ExistsById(string userId) => this.data.Agents.Any(u => u.UserId == userId);

        public bool UserWithPhoneNumberExists(string phoneNumebr) => this.data.Agents.Any(a => a.PhoneNumber == phoneNumebr);

        public bool UserHasRents(string userId) => this.data.Houses.Any(h => h.RenterId == userId);       

        public void Create(string userId, string phoneNumber)
        {

            Agent agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };
            this.data.Agents.Add(agent);
            this.data.SaveChanges();
        }

        public int GetAgentId(string userId)
        {
            Agent agent = this.data.Agents.FirstOrDefault(a=>a.UserId == userId);
            return agent.Id;
        }
       
    }
}
