using Identity.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
    public class DataContext: DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(m => m.RoleId);
        }
    }
}