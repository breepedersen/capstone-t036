using JuniorRangers_API.Data;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;

namespace JuniorRangers_API.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly DataContext _context;
        public ClassroomRepository(DataContext context) 
        {
            _context = context;
        }
        public bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(c => c.ClassId == id);
        }

        public Classroom GetClassroom(int id)
        {
            return _context.Classrooms.Where(c => c.ClassId == id).FirstOrDefault();
        }

        public ICollection<Classroom> GetClassrooms()
        {
            return _context.Classrooms.OrderBy(c => c.ClassId).ToList();
        }

        public ICollection<User> GetUserByClassroom(int classId)
        {
            return (ICollection<User>)_context.Classrooms.Where(c => c.ClassId == classId).Select(u => u.Users).ToList();
        }
    }
}
