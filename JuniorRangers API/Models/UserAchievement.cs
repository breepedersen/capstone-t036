﻿namespace JuniorRangers_API.Models
{
    public class UserAchievement
    {
        public string UserId { get; set; }
        public int AchievementId { get; set;}
        public DateTime DateAwarded { get; set; }
        public User User { get; set; }
        public Achievement Achievement { get; set; }
    }
}
