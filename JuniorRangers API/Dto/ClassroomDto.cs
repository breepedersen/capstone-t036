using JuniorRangers_API.Models;
using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Dto
{
    public class ClassroomDto
    {
        public int ClassId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
