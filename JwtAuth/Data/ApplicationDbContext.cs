using JwtAuth.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<IdentityUser> LiveUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<IdentityUser>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<IdentityUser>().Property(x => x.UserName).IsRequired();
        }
    }
}