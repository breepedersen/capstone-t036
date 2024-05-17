using JuniorRangers_API.Models;
using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Dto
{
    public class PostDto
    {
        public int PostId { get; set; }

        public int Likes { get; set; }

        public String Text { get; set; }

        public DateTime PostDate { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
    }
}
