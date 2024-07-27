namespace JuniorRangers_API.Models
{
    //A join table between Users and Achievements
    public class UserAchievement
    {
        public int UserNumber { get; set; }
        public int AchievementId { get; set;}
        public DateTime DateAwarded { get; set; }
        public User User { get; set; }
        public Achievement Achievement { get; set; }
    }
}
