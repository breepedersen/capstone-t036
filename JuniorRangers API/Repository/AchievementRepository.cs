using AutoMapper;
using Azure.Core;
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

        public bool AwardAchievement(UserAchievement userAchievement)
        {
            _context.Add(userAchievement);
            return Save();
        }

        public bool CreateAchievement(Achievement achievement)
        {
            _context.Add(achievement);
            return Save();
        }

        public bool DeleteAchievement(Achievement achievement)
        {
            _context.Remove(achievement);
            return Save();
        }

        public Achievement GetAchievement(int id)
        {
            return _context.Achievements.Where(a => a.AchievementId == id).FirstOrDefault();
        }

        public ICollection<Achievement> GetAchievements()
        {
            return _context.Achievements.OrderBy(a => a.AchievementId).ToList();
        }

        public ICollection<Achievement> GetAchievementsByMissionGroup(int missonGroupId)
        {
            return _context.Achievements.Where(a => a.MissionGroup == missonGroupId).ToList();
        }

        public ICollection<Achievement> GetAchievementsByUser(int userNumber)
        {
            return _context.UserAchievements.Where(u => u.UserNumber == userNumber).Select(a => a.Achievement).ToList();
        }

        public ICollection<User> GetUsersByAchievement(int achievementId)
        {
            return _context.UserAchievements.Where(a => a.AchievementId == achievementId).Select(u => u.User).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAchievement(Achievement achievement)
        {
            _context.Update(achievement);
            return Save();
        }
    }
}
