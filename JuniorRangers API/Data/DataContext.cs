using JuniorRangers_API.Models;
using JuniorRangers_API.Models.JoinTables;
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
        public DbSet<MissionGroup> MissionGroups { get; set; }
        public DbSet<ClassMission> ClassMissions { get; set; }
        public DbSet<AchievementMissionGroup> AchievementMissionGroups { get; set; }
        public DbSet<ClassMissionStatus> ClassMissionStatuses { get; set; }

        //to setup linking of many-to-many tables (without going directly into database)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure UserNumber as a regular property
            modelBuilder.Entity<User>()
                .Property(u => u.UserNumber)
                .ValueGeneratedOnAdd();
                
            // Configure many-to-many relationship for UserAchievements
            modelBuilder.Entity<UserAchievement>()
                .HasKey(ua => new { ua.UserNumber, ua.AchievementId });
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAchievement)
                .HasForeignKey(ua => ua.UserNumber)
                .HasPrincipalKey(u => u.UserNumber);
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.Achievement)
                .WithMany(a => a.UserAchievement)
                .HasForeignKey(ua => ua.AchievementId);

            // Configure many-to-many relationship between Classroom and MissionGroup using ClassMissions
            modelBuilder.Entity<ClassMission>()
                .HasKey(cm => new { cm.ClassId, cm.MissionGroupId });
            modelBuilder.Entity<ClassMission>()
                .HasOne(cm => cm.Class)
                .WithMany(c => c.ClassMissions)
                .HasForeignKey(cm => cm.ClassId);
            modelBuilder.Entity<ClassMission>()
                .HasOne(cm => cm.MissionGroup)
                .WithMany(mg => mg.ClassMissions)
                .HasForeignKey(cm => cm.MissionGroupId);

            // Configure many-to-many relationship between Achievement and MissionGroup using AchievementMissionGroups
            modelBuilder.Entity<AchievementMissionGroup>()
                .HasKey(amg => new { amg.AchievementId, amg.MissionGroupId });
            modelBuilder.Entity<AchievementMissionGroup>()
                .HasOne(amg => amg.Achievement)
                .WithMany(a => a.AchievementMissionGroups)
                .HasForeignKey(amg => amg.AchievementId);
            modelBuilder.Entity<AchievementMissionGroup>()
                .HasOne(amg => amg.MissionGroup)
                .WithMany(mg => mg.AchievementMissionGroups)
                .HasForeignKey(amg => amg.MissionGroupId);

            // Configure many-to-many relationship for Classroom, MissionGroup, and Achievement through ClassroomAchievementStatus
            modelBuilder.Entity<ClassMissionStatus>()
                .HasKey(cms => new { cms.ClassroomId, cms.MissionGroupId, cms.AchievementId });
            modelBuilder.Entity<ClassMissionStatus>()
                .HasOne(cms => cms.Classroom)
                .WithMany(c => c.ClassMissionStatuses)
                .HasForeignKey(cms => cms.ClassroomId);
            modelBuilder.Entity<ClassMissionStatus>()
                .HasOne(cms => cms.MissionGroup)
                .WithMany(mg => mg.ClassMissionStatuses)
                .HasForeignKey(cms => cms.MissionGroupId);
            modelBuilder.Entity<ClassMissionStatus>()
                .HasOne(cms => cms.Achievement)
                .WithMany(a => a.ClassMissionStatuses)
                .HasForeignKey(cms => cms.AchievementId);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
                new IdentityRole
                {
                    Name = "Ranger",
                    NormalizedName = "RANGER"
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
