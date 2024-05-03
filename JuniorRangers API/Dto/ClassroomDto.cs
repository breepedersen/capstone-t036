using JuniorRangers_API.Models;

namespace JuniorRangers_API.Dto
{
    public class ClassroomDto
    {
        public int ClassId { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
