using iFXManager.API.Models;
using iFXManager.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iFXManager.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}

