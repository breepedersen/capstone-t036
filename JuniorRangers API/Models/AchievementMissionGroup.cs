namespace JuniorRangers_API.Models
{
    //A join table between Achievements and Mission Groups
    public class AchievementMissionGroup
    {
        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; }

        public int MissionGroupId { get; set; }
        public MissionGroup MissionGroup { get; set; }
    }
}
