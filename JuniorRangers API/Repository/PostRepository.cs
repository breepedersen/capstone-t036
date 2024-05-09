using JuniorRangers_API.Data;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;

namespace JuniorRangers_API.Repository
{
    public class PostRepository : IPostRepository
    {
        private DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public Post GetPost(int postId)
        {
            return _context.Posts.Where(p => p.PostId == postId).FirstOrDefault();
        }

        public ICollection<Post> GetPostsByClassroom(int classId)
        {
            return _context.Posts.Where(p => p.Classroom.ClassId == classId).ToList();
        }

        public bool PostExists(int postId)
        {
            return _context.Posts.Any(p => p.PostId == postId);
        }
    }
}
