namespace JuniorRangers_API.Models.JoinTables
{
    //A join table between Achievements and Mission Groups (a mission group contains multiple achievements)
    public class AchievementMissionGroup
    {
        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; }

        public int MissionGroupId { get; set; }
        public MissionGroup MissionGroup { get; set; }
    }
}
