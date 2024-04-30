using JuniorRangers_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JuniorRangers_API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        
        }

        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }

        //to setup linking of many-to-many tables (without going directly into database)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAchievement>()
                .HasKey(ua => new { ua.UserId, ua.AchievementId });
            modelBuilder.Entity<UserAchievement>()
                .HasOne(u => u.User)
                .WithMany(ua => ua.UserAchievement)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserAchievement>()
                .HasOne(u => u.Achievement)
                .WithMany(ua => ua.UserAchievement)
                .HasForeignKey(a => a.AchievementId);
        }
    }
}
