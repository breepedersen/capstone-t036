using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IAchievementRepository
    {
        ICollection<Achievement> GetAchievements();
        Achievement GetAchievement(int id);
        ICollection<User> GetUsersByAchievement(int achievementId);
        ICollection<Achievement> GetAchievementsByUser(int userNumber);
        bool AchievementExists(int achievementId);
        bool CreateAchievement(Achievement achievement);
        bool UpdateAchievement(Achievement achievement);
        bool AwardAchievement(UserAchievement userAchievement);
        bool DeleteAchievement(Achievement achievement);
        
        // Mission group methods
        ICollection<MissionGroup> GetMissionGroups();
        ICollection<Achievement> GetAchievementsByMissionGroup(int missonGroupId);
        bool MissionGroupExists(int missonGroupId);
        bool CreateMissionGroup(MissionGroup missonGroup);
        bool UpdateMissionGroup(MissionGroup missonGroup);
        bool AssignMissionGroupToClass(ClassMission classmission);
        //bool CompleteClassAchievement(UserAchievement userAchievement);
        bool DeleteMissionGroup(MissionGroup missonGroup);
        bool Save();
    }
}
