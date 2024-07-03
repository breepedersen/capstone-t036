using JuniorRangers_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JuniorRangers_API.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DataContext(DbContextOptions options) : base(options) 
        {
        
        }

        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }

        //to setup linking of many-to-many tables (without going directly into database)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

/*            // Configure UserId as a regular property
            modelBuilder.Entity<User>()
                .Property(u => u.CustomUserId)
                .ValueGeneratedOnAdd();*/
                
            // Configure many-to-many relationship for UserAchievements
            modelBuilder.Entity<UserAchievement>()
                .HasKey(ua => new { ua.UserId, ua.AchievementId });
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAchievement)
                .HasForeignKey(ua => ua.UserId);
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.Achievement)
                .WithMany(a => a.UserAchievement)
                .HasForeignKey(ua => ua.AchievementId);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
