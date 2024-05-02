﻿using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }

        [StringLength(50)]
        public String Description { get; set; }

        public DateTime DateAwarded { get; set; }
        public ICollection<UserAchievement> UserAchievement { get; set; }
    }
}
