namespace JuniorRangers_API.Models.JoinTables
{
    //A mission group table: each mission group has an ID, name, description, and a group of achievements
    public class MissionGroup
    {
        public int MissionGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<ClassMission> ClassMissions { get; set; }
        public ICollection<AchievementMissionGroup> AchievementMissionGroups { get; set; }
        public ICollection<ClassMissionStatus> ClassMissionStatuses { get; set; }
    }
}
