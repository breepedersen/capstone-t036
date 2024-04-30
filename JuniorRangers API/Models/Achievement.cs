namespace JuniorRangers_API.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public String Description { get; set; }
/*        public int UserAwarded { get; set; }*/
        public DateTime DateAwarded { get; set; }
        public ICollection<UserAchievement> UserAchievement { get; set; }
    }
}
