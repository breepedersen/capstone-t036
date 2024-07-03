using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IAchievementRepository
    {
        ICollection<Achievement> GetAchievements();
        Achievement GetAchievement(int id);
        ICollection<User> GetUsersByAchievement(int achievementId);
        ICollection<Achievement> GetAchievementsByUser(string UserId);
        ICollection<Achievement> GetAchievementsByMissionGroup(int missonGroupId);
        bool AchievementExists(int achievementId);
        bool CreateAchievement(Achievement achievement);
        bool UpdateAchievement(Achievement achievement);
        bool AwardAchievement(UserAchievement userAchievement);
        bool DeleteAchievement(Achievement achievement);
        bool Save();
    }
}
