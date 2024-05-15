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

        public bool CreatePost(Post post)
        {
            _context.Add(post);
            return Save();
        }

        public Post GetPost(int postId)
        {
            return _context.Posts.Where(p => p.PostId == postId).FirstOrDefault();
        }

        public ICollection<Post> GetPosts()
        {
            return _context.Posts.OrderBy(p => p.PostId).ToList();
        }

        public ICollection<Post> GetPostsByClassroom(int classId)
        {
            return _context.Posts.Where(p => p.Classroom.ClassId == classId).ToList();
        }

        public bool PostExists(int postId)
        {
            return _context.Posts.Any(p => p.PostId == postId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePost(Post post)
        {
            _context.Update(post);
            return Save();
        }
    }
}
