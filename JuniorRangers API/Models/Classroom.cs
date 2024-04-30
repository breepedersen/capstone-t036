using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Models
{
    public class Classroom
    {
        [Key]
        public int ClassId { get; set; }
        public String JoinCode { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
