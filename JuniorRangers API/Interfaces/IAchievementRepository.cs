using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IAchievementRepository
    {
        ICollection<Achievement> GetAchievements();
        Achievement GetAchievement(int id);
        ICollection<User> GetUsersByAchievement(int achievementId);
        bool AchievementExists(int achievementId);
    }
}
