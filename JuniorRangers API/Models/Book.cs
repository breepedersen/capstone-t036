using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [StringLength(50)]
        public String Title { get; set; }

        [MaxLength]
        public String Content { get; set; }

        public Classroom Classroom { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
