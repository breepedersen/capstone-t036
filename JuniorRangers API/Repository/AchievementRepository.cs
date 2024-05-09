using AutoMapper;
using JuniorRangers_API.Data;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;

namespace JuniorRangers_API.Repository
{
    public class AchievementRepository : IAchievementRepository
    {
        private DataContext _context;

        public AchievementRepository(DataContext context)
        {
            _context = context;
        }
        public bool AchievementExists(int id)
        {
            return _context.Achievements.Any(a => a.AchievementId == id);
        }

        public Achievement GetAchievement(int id)
        {
            return _context.Achievements.Where(a => a.AchievementId == id).FirstOrDefault();
        }

        public ICollection<Achievement> GetAchievements()
        {
            return _context.Achievements.OrderBy(a => a.AchievementId).ToList();
        }

        public ICollection<User> GetUsersByAchievement(int achievementId)
        {
            return _context.UserAchievements.Where(a => a.AchievementId == achievementId).Select(u => u.User).ToList();
        }
    }
}
