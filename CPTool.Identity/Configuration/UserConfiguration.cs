using CPTool.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPTool.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "57b7572f-b3aa-4674-9fd3-e2e80f32a923",
                    Email = "pmtoolazure@gmail.com",
                    NormalizedEmail = "pmtoolazure@gmail.com",
                    FirstName = "pmtool",
                    LastName = "azure",
                    UserName = "pmtoolazure",
                    NormalizedUserName = "pmtoolazure",
                    PasswordHash = hasher.HashPassword(null!, "1506Afd1974*"),
                    EmailConfirmed = true,



                },
                new ApplicationUser
                {
                    Id = "bd902e33-c650-42c7-babd-3e6900908a6f",
                    Email = "pmtoolazure@gmail.com",
                    NormalizedEmail = "pmtoolazure@gmail.com",
                    FirstName = "pmtool2",
                    LastName = "azure2",
                    UserName = "pmtoolazure2",
                    NormalizedUserName = "pmtoolazure2",
                    PasswordHash = hasher.HashPassword(null!, "1506Afd1974*2"),
                    EmailConfirmed = true,


                }
            );

        }
    }
}
