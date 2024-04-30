using JuniorRangers_API.Data;
using JuniorRangers_API.Models;

namespace JuniorRangers_API
{
    public class Seed
    {
        //Script to prepopulate database with data
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.UserAchievements.Any())
            {
                var UserAchievements = new List<UserAchievement>()
                {
                    new UserAchievement()
                    {
                        User = new User()
                        {
                            FirstName = "Tom",
                            LastName = "Pham",
                            Password = "123",
                            Role = "Student",
                            Classroom = new Classroom()
                            {
                                JoinCode = "joinme"
                            }
                        },
                        Achievement  = new Achievement()
                        {
                            Description = "Drank water",
                            DateAwarded = new DateTime(2022,12,15)
                        }
                    },
                    new UserAchievement()
                    {
                        User = new User()
                        {
                            FirstName = "Ben",
                            LastName = "Eckersley",
                            Password = "123",
                            Role = "Student",
                            Classroom = new Classroom()
                            {
                                JoinCode = "class2"
                            }
                        },
                        Achievement  = new Achievement()
                        {
                            Description = "Slept",
                            DateAwarded = new DateTime(2023,11,15)
                        }
                    },
                    new UserAchievement()
                    {
                        User = new User()
                        {
                            FirstName = "Sonnie",
                            LastName = "Poon",
                            Password = "123",
                            Role = "Student",
                            Classroom = new Classroom()
                            {
                                JoinCode = "class3"
                            }
                        },
                        Achievement  = new Achievement()
                        {
                            Description = "Ate",
                            DateAwarded = new DateTime(2022,01,15)
                        }
                    },
                    new UserAchievement()
                    {
                        User = new User()
                        {
                            FirstName = "Bree",
                            LastName = "Pederson",
                            Password = "123",
                            Role = "Student",
                            Classroom = new Classroom()
                            {
                                JoinCode = "class4"
                            }
                        },
                        Achievement  = new Achievement()
                        {
                            Description = "Studied",
                            DateAwarded = new DateTime(2023,11,15)
                        }
                    }
                };
                dataContext.UserAchievements.AddRange(UserAchievements);
                dataContext.SaveChanges();
            }

        }
    }
}
