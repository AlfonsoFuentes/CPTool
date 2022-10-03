using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "59577820-5299-4bbe-981a-43b3b1c88f98",
                    Name = "Administrator",
                    NormalizedName = "ADMIN"

                },
                new IdentityRole
                {
                    Id = "f6328e1d-105d-4076-a037-33e336f426df",
                    Name = "Reader",
                    NormalizedName = "READER"

                }



                );


        }
    }
}
