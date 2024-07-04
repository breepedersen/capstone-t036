using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [MaxLength]
        public int Likes { get; set; }

        [StringLength(1000)]
        public String Text { get; set; }

        public DateTime PostDate { get; set; }
        public User? Poster { get; set; }
        public Classroom Classroom { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
    }
}