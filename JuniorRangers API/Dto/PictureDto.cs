using JuniorRangers_API.Models;
using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Dto
{
    public class PictureDto
    {
        public int PictureId { get; set; }
        public String Description { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
