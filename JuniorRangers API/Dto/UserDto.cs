using JuniorRangers_API.Models;

namespace JuniorRangers_API.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Role { get; set; }
    }
}
