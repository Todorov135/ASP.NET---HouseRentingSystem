namespace HouseRentingSystem.Core.Services
{
    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Core.Models.Home;
    using HouseRentingSystem.Core.Models.House;
    using HouseRentingSystem.Data;
    using HouseRentingSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext data;

        public HouseService(HouseRentingDbContext _data)
        {
            this.data = _data;                
        }

       

        public IEnumerable<HouseIndexServiceModel> LastThreeHouses()
        {
            List<HouseIndexServiceModel> lastThreeHouses = data
                                                            .Houses
                                                            .OrderByDescending(c => c.Id)
                                                            .Take(3)
                                                            .Select(h => new HouseIndexServiceModel()
                                                            {
                                                                Id = h.Id,
                                                                Title = h.Title,
                                                                ImageUrl = h.ImageUrl
                                                            })
                                                            .ToList();
            return lastThreeHouses;
        }

        public async Task<IEnumerable<HouseCategoriesViewModel>> AlLCategories()
        {
            return await this.data
                             .Categories
                             .OrderBy(c => c.Name)
                             .Select(c => new HouseCategoriesViewModel()
                             {
                                 Id = c.Id,
                                 Name = c.Name
                             })
                             .ToListAsync();
        }

        public async Task<int> Create(string title, string address, string description, string imageUrl, decimal pricePerMounth, int categoryId, int agentId)
        {
            House house = new House()
            {
                Title = title,
                Address = address,
                Description = description,
                ImageUrl = imageUrl,
                PricePerMonth = pricePerMounth,
                CategoryId = categoryId,
                AgentId = agentId
            };

            await data.Houses.AddAsync(house);
            await data.SaveChangesAsync();

            return house.Id;
        }

        public async Task<bool> IsValidCategory(int categoryId)
        {
            return await this.data.Categories.AnyAsync(c => c.Id == categoryId);
        }
    }
}
