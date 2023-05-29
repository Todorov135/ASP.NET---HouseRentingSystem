namespace HouseRentingSystem.Core.Contracts
{
    using HouseRentingSystem.Core.Models.Home;
    using HouseRentingSystem.Core.Models.House;

    public interface IHouseService
    {
        IEnumerable<HouseIndexServiceModel> LastThreeHouses();
        Task<IEnumerable<HouseCategoriesViewModel>> AlLCategories();
        Task<int> Create(string title, string address, string description, string imageUrl, decimal pricePerMounth, int categoryId, int agentId);
        Task<bool> IsValidCategory(int categoryId);
    }
}
