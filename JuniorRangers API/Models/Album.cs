namespace JuniorRangers_API.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Classroom Classroom { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
