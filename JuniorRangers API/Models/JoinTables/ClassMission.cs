namespace JuniorRangers_API.Models.JoinTables
{
    //A join table between Classrooms and MissionGroups (a missiongroup can be assigned to a classroom)
    public class ClassMission
    {
        public int ClassId { get; set; }
        public int MissionGroupId { get; set; }
        public DateTime? DateAssigned { get; set; }
        public DateTime? DateCompleted { get; set; }
        public bool IsCompleted { get; set; }   //if the entire group of achievements are completed
        public Classroom Class { get; set; }
        public MissionGroup MissionGroup { get; set; }
    }
}
