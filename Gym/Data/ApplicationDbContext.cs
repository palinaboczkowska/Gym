using Gym.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GymClass> GymClasses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserGymClass>()
                .HasKey(ug => new { ug.ApplicationUserId, ug.GymClassId });

            builder.Entity<ApplicationUserGymClass>()
                .HasOne(ug => ug.ApplicationUser)
                .WithMany(u => u.AttendedClasses)
                .HasForeignKey(ug => ug.ApplicationUserId);

            builder.Entity<ApplicationUserGymClass>()
                .HasOne(ug => ug.GymClass)
                .WithMany(g => g.AttendingMembers)
                .HasForeignKey(ug => ug.GymClassId);
        }


    }
}
