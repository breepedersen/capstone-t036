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

        public bool CreateUser(User user)
        {
/*            var userAchievementEntity = _context.Achievements.Where(a => a.AchievementId == achievementId).FirstOrDefault();

            //add to join table
            var userAchievement = new UserAchievement()
            {
                Achievement = userAchievementEntity,
                User = user,
            };

            _context.Add(userAchievement);*/
            _context.Add(user);

            return Save();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(u => u.UserId == id).FirstOrDefault();
        }

        public User GetUser(string firstname, string lastname)
        {
            return _context.Users.Where(u => u.FirstName == firstname && u.LastName == lastname).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.UserId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;    
        }

        public bool UpdateUser(User user)
        {
            _context.ChangeTracker.Clear();
            _context.Update(user);
            return Save();
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
