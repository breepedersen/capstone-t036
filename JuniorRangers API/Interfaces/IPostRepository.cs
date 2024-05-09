using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IPostRepository
    {
        bool PostExists(int postId);
        Post GetPost(int postId);
        ICollection<Post> GetPostsByClassroom(int classId);
    }
}
