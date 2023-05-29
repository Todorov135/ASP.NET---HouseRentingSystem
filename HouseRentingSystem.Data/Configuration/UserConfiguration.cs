namespace HouseRentingSystem.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private IEnumerable<IdentityUser> CreateUsers()
        {
            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();

            var users = new List<IdentityUser>();
            var firstUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            firstUser.PasswordHash =
                 hasher.HashPassword(firstUser, "agent123");

            users.Add(firstUser);

            var secondUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            secondUser.PasswordHash =
            hasher.HashPassword(secondUser, "guest123");

            users.Add(secondUser);



            return users;
        }
    }
}
