namespace JuniorRangers_API.Models.JoinTables
{
    //Join table to track individual completion status' of achievements assigned to a class as part of a ClassMission group
    public class ClassMissionStatus
    {
        public int ClassroomId { get; set; }
        public int MissionGroupId { get; set; }
        public int AchievementId { get; set; }
        public bool IsAchievementComplete { get; set; }
        public DateTime? DateAssigned { get; set; }
        public DateTime? DateCompleted { get; set; }
        public Classroom Classroom { get; set; }
        public MissionGroup MissionGroup { get; set; }
        public Achievement Achievement { get; set; }
    }
}
