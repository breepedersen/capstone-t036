using JuniorRangers_API.Models.JoinTables;
using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IMissionGroupRepository
    {
        // Mission group methods
        ICollection<MissionGroup> GetMissionGroups();
        MissionGroup GetMissionGroup(int missionGroupId);
        ICollection<ClassMissionStatus> GetClassMissions(int classroomId);
        ICollection<Achievement> GetAchievementsByMissionGroup(int missonGroupId);
        ClassMissionStatus GetClassMissionStatus(int classroomId, int missionGroupId, int achievementId);
        bool MissionGroupExists(int missonGroupId);
        bool CreateMissionGroup(MissionGroup missonGroup);
        bool UpdateMissionGroup(MissionGroup missonGroup);
        bool UpdateClassAchievementStatus(ClassMissionStatus classMissionStatus);
        bool AddAchievementToMissionGroup(AchievementMissionGroup achievementMissionGroup);
        bool AddClassMissionStatus(ClassMissionStatus classMissionStatus);
        bool AssignMissionGroupToClass(ClassMission classmission);
        bool DeleteMissionGroup(MissionGroup missonGroup);
        bool Save();
    }
}
