using JuniorRangers_API.Models;
namespace JuniorRangers_API.Interfaces
{
    public interface IClassroomRepository
    {
        ICollection<Classroom> GetClassrooms();
        Classroom GetClassroom(int id);
        ICollection<User> GetUserByClassroom(int id);
        bool ClassroomExists(int id);
    }
}
