namespace JuniorRangers_API.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public Classroom Classroom { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
