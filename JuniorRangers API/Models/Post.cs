namespace JuniorRangers_API.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int Likes { get; set; }
        public String Text { get; set; }
        public DateTime PostDate { get; set; }
        public User? Poster { get; set; }
        public Classroom Classroom { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
