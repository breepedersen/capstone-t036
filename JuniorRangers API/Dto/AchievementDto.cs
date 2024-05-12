using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Dto
{
    public class AchievementDto
    {
        public int AchievementId { get; set; }

        [StringLength(50)]
        public String Description { get; set; }
        public int Points { get; set; }
        public int? MissionGroup { get; set; }
    }
}
