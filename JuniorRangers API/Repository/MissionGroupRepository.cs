using AutoMapper;
using Azure.Core;
using JuniorRangers_API.Data;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Migrations;
using JuniorRangers_API.Models;
using JuniorRangers_API.Models.JoinTables;

namespace JuniorRangers_API.Repository
{
    public class MissionGroupRepository : IMissionGroupRepository
    {
        private DataContext _context;

        public MissionGroupRepository(DataContext context)
        {
            _context = context;
        }

        //Missions Groups
        public ICollection<MissionGroup> GetMissionGroups()
        {
            return _context.MissionGroups.OrderBy(m => m.MissionGroupId).ToList();
        }
        public ICollection<Achievement> GetAchievementsByMissionGroup(int missionGroupId)
        {
            return _context.AchievementMissionGroups
               .Where(amg => amg.MissionGroupId == missionGroupId)
               .Select(amg => amg.Achievement)
               .ToList();
        }
        public bool MissionGroupExists(int missonGroupId)
        {
            return _context.MissionGroups.Any(m => m.MissionGroupId == missonGroupId);
        }
        public bool CreateMissionGroup(MissionGroup missonGroup)
        {
            _context.Add(missonGroup);
            return Save();
        }
        public bool AddAchievementToMissionGroup(AchievementMissionGroup achievementMissionGroup)
        {
            _context.Add(achievementMissionGroup);
            return Save();
        }
        public bool UpdateMissionGroup(MissionGroup missonGroup)
        {
            _context.Update(missonGroup);
            return Save();
        }
        public bool UpdateClassAchievementStatus(Models.JoinTables.ClassMissionStatus classMissionStatus)
        {
            _context.Update(classMissionStatus);
            return Save();
        }
        public bool AssignMissionGroupToClass(ClassMission classmission)
        {
            _context.Add(classmission);
            return Save();
        }
        public bool DeleteMissionGroup(MissionGroup missonGroup)
        {
            _context.Remove(missonGroup);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public MissionGroup GetMissionGroup(int missionGroupId)
        {
            return _context.MissionGroups.Where(m => m.MissionGroupId == missionGroupId).FirstOrDefault();
        }

        public bool AddClassMissionStatus(Models.JoinTables.ClassMissionStatus classMissionStatus)
        {
            _context.Add(classMissionStatus);
            return Save();
        }

        public Models.JoinTables.ClassMissionStatus GetClassMissionStatus(int classroomId, int missionGroupId, int achievementId)
        {
            return _context.ClassMissionStatuses.Where(s => s.ClassroomId == classroomId && s.MissionGroupId == missionGroupId && s.AchievementId == achievementId).FirstOrDefault();
        }
    }
}
