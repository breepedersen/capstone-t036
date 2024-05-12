using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IAchievementRepository
    {
        ICollection<Achievement> GetAchievements();
        Achievement GetAchievement(int id);
        ICollection<User> GetUsersByAchievement(int achievementId);
        ICollection<Achievement> GetAchievementsByUser(int UserId);
        ICollection<Achievement> GetAchievementsByMissionGroup(int missonGroupId);
        bool AchievementExists(int achievementId);
        bool CreateAchievement(Achievement achievement);
        bool Save();
    }
}
