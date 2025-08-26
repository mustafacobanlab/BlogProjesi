using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KisiselBlogProjesi.Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "b7a61d15-5c12-4f3b-85d6-88d4c97c12f4" 
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Editor",
                    NormalizedName = "EDITOR",
                    ConcurrencyStamp = "a1b5c4f2-98e3-4d7a-b2c8-89e4a3b7d1e8" 
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "c4d7e9f1-3b5a-4e2a-9f8c-1a2b3c4d5e6f" 
                }
            );
        }
    }
}