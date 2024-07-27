namespace JuniorRangers_API.Models
{
    public class MissionGroup
    {
        public int MissionGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<ClassMission> ClassMissions { get; set; }
        public ICollection<AchievementMissionGroup> AchievementMissionGroups { get; set; }
    }
}
