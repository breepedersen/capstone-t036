using System.ComponentModel.DataAnnotations.Schema;

namespace JuniorRangers_API.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public String Description { get; set; }
        public User Uploader { get; set; }
        public DateTime UploadDate { get; set; }
        public Album? Album { get; set; }           //Todo: either album OR post is required
        public Post? Post { get; set; }
    }
}
