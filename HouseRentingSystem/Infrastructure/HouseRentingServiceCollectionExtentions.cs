namespace HouseRentingSystem.Infrastructure
{
    using HouseRentingSystem.Core.Contracts;
    using HouseRentingSystem.Core.Services;

    public static class HouseRentingServiceCollectionExtentions 
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {            
            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IAgentService, AgentService>();

            return services;
        }
    }
}
