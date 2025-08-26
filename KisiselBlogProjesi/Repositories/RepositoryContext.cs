using KisiselBlogProjesi.Models;
using KisiselBlogProjesi.Repositories.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KisiselBlogProjesi.Repositories
{
    public class RepositoryContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Iletisim> Iletisims { get; set; }


        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new IdentityRoleConfig());
        }
    }
}
