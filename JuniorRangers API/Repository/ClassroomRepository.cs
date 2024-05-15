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

        public bool CreateClassroom(Classroom classroom)
        {
            _context.Add(classroom);
            return Save();
        }

        public Classroom GetClassroom(int id)
        {
            return _context.Classrooms.Where(c => c.ClassId == id).FirstOrDefault();
        }

        public ICollection<Classroom> GetClassrooms()
        {
            return _context.Classrooms.OrderBy(c => c.ClassId).ToList();
        }

        public ICollection<User> GetUsersByClassroom(int classId)
        {
            return _context.Users.Where(u => u.Classroom.ClassId == classId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateClassroom(Classroom classroom)
        {
            _context.ChangeTracker.Clear();
            _context.Update(classroom);
            return Save();
        }
    }
}
