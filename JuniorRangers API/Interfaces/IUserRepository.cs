using JuniorRangers_API.Models;
namespace JuniorRangers_API.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        User GetUser(string firstname, string lastname);
/*        ICollection<Achievement> GetUserAchievements();*/
        bool UserExists(int id);
        bool UserExists(string fname, string lname);
    }
}
