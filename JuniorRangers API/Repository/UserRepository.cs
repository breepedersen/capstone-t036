using JuniorRangers_API.Data;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;
using System.Diagnostics.CodeAnalysis;

namespace JuniorRangers_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) { 
        
            _context = context;
        }

        //Database Calls
        public User GetUser(int id)
        {
            return _context.Users.Where(u => u.UserId == id).FirstOrDefault();
        }

        public User GetUser(string firstname, string lastname)
        {
            return _context.Users.Where(u => u.FirstName == firstname && u.LastName == lastname).FirstOrDefault();
        }

/*        public ICollection<Achievement> GetUserAchievements()
        {
            return _context.Achievements.OrderBy(u => u.UserId).ToList();
        }*/

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.UserId).ToList();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(u => u.UserId == id);
        }

        public bool UserExists(string firstname, string lastname)
        {
            return _context.Users.Any(u => u.FirstName == firstname && u.LastName == lastname);
        }
    }
}
