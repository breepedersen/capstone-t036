using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IPostRepository
    {
        bool PostExists(int postId);
        ICollection<Post> GetPosts();
        Post GetPost(int postId);
        ICollection<Post> GetPostsByClassroom(int classId);
        bool CreatePost(Post post);
        bool UpdatePost(Post post);
        bool DeletePost(Post post);
        bool Save();
    }
}
