using JuniorRangers_API.Models.JoinTables;
using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Models
{
    public class Classroom
    {
        [Key]
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        [StringLength(7)]
        public String JoinCode { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<ClassMission> ClassMissions { get; set; }
        public ICollection<ClassMissionStatus> ClassMissionStatuses { get; set; }
    }
}
