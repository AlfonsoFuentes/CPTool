using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPTool.Identity.Configuration
{
    public class UserRoleConfiguration :
        IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "59577820-5299-4bbe-981a-43b3b1c88f98",
                    UserId = "57b7572f-b3aa-4674-9fd3-e2e80f32a923",
                },
                 new IdentityUserRole<string>
                 {
                     RoleId = "f6328e1d-105d-4076-a037-33e336f426df",
                     UserId = "bd902e33-c650-42c7-babd-3e6900908a6f",
                 }

                );
        }
    }
}
