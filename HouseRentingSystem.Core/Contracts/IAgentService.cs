namespace HouseRentingSystem.Core.Contracts
{
    public interface IAgentService
    {
        bool ExistsById(string userId);
        bool UserWithPhoneNumberExists(string phoneNumebr);
        bool UserHasRents(string userId);
        void Create(string userId, string phoneNumber);
        int GetAgentId(string userId);
    }
}
