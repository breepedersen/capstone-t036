using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Dto
{
    public class AlbumDto
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
