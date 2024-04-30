namespace JuniorRangers_API.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int Likes { get; set; }
        public String Text { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
