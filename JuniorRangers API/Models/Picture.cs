namespace JuniorRangers_API.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public String Description { get; set; }
        public DateTime UploadDate { get; set; }
        public User Uploader { get; set; }
        public Album Album { get; set; }
        public Post Post { get; set; }
    }
}
