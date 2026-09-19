using Domain_Layer.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace infrastructure_layer
{
    public class DbContextShipping
        : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbContextShipping(
            DbContextOptions<DbContextShipping> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Merchant> Merchants { get; set; }

        public DbSet<Courier> Couriers { get; set; }

        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(
                typeof(DbContextShipping).Assembly);
        }
    }
}