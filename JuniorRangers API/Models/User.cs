using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Models
{
    public class User : IdentityUser
    {
        //public int CustomUserId { get; set; }

        // [StringLength(20)]
        // public String Username { get; set; }

        [StringLength(50)]
        public String Password { get; set; }    //TODO: use hashes to encrypt password

        [StringLength(20)]
        public String FirstName { get; set; }

        [StringLength(20)]
        public String LastName { get; set; }

        [StringLength(20)]
        public String Role { get; set; }

        public Classroom? Classroom { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Picture> Picures { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserAchievement> UserAchievement { get; set; }
    }
}
