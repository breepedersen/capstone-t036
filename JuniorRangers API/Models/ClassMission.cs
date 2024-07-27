namespace JuniorRangers_API.Models
{
    //A join table between Classrooms and MissionGroups
    public class ClassMission
    {
        public int ClassId { get; set; }
        public int MissionGroupId { get; set; }
        public DateTime? DateAssigned { get; set; }
        public DateTime? DateCompleted { get; set; }
        public bool IsCompleted { get; set; }
        public Classroom Class { get; set; }
        public MissionGroup MissionGroup { get; set; }
    }
}
