using JuniorRangers_API.Models;
namespace JuniorRangers_API.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int userNumber);
        User GetUser(string firstname, string lastname);
        bool UserExists(int userNumber);
        bool UserExists(string fname, string lname);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
