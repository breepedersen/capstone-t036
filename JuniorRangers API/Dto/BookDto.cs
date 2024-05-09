using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Dto
{
    public class BookDto
    {
        public int BookId { get; set; }

        [StringLength(50)]
        public String Title { get; set; }

        [MaxLength]
        public String Content { get; set; }
    }
}
