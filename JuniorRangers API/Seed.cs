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
                            UserName = "TomMan",
                            FirstName = "Tom",
                            LastName = "Pham",
                            //Password = "123",
                            //Role = "Ranger",
                            Classroom = new Classroom()
                            {
                                Name = "Team Super",
                                JoinCode = "class1",
                                Albums = new List<Album>()
                                {
                                    new Album
                                    {
                                        Name = "Beach Trip",
                                        CreationDate = DateTime.Now,
                                        Pictures = new List<Picture>()
                                        {
                                            new Picture { Description = "Caption 1", UploadDate = new DateTime(2022,02,21), Uploader = new User { UserName = "Username1", FirstName = "Chris", LastName = "Chesher", /*Password = "123". Role = "Admin" */}},
                                            new Picture { Description = "Caption 2", UploadDate = new DateTime(2022,02,13), Uploader = new User { UserName = "username2", FirstName = "Molly", LastName = "Arnold", /*Password = "123". Role = "Admin"*/ }}
                                        }
                                    }
                                },
                                Books = new List<Book>()
                                {
                                    new Book {Title = "Harry Potter", Content = "You are a wizard Harry", UploadDate = DateTime.Now},
                                    new Book {Title = "Australian Native Flora", Content = "This is a flower", UploadDate = DateTime.Now}
                                },
                                Posts = new List<Post>()
                                {
                                    new Post
                                    {
                                        Likes = 5,
                                        Text = "Check out this platypus",
                                        PostDate = DateTime.Now,
                                        Pictures = new List<Picture>()
                                        {
                                            new Picture { Description = "Platypus", UploadDate = new DateTime(2022,02,13), Uploader = new User { UserName = "tobyy", FirstName = "Toby", LastName = "Toby", /*Password = "123", Role = "Ranger"*/ }}
                                        }
                                    }
                                },
                                Messages = new List<Message>()
                                {
                                    new Message { MessageType = "Announcement", MessageTitle = "Weather Today", MessageText = "Today will be a cold day", Date = DateTime.Now, Sender = new User { UserName = "gregyy", FirstName = "Greg", LastName = "Polby", /*Password = "123", Role = "Ranger"*/ } },
                                    new Message { MessageType = "Event", MessageTitle = "Mountain Trip", MessageText = "A field trip to the mountains", Date = new DateTime(2024,06,12), Sender = new User { UserName = "TheRanger", FirstName = "Eve", LastName = "Smith", /*Password = "123", Role = "Ranger"*/ }},
                                    new Message { MessageType = "Chat", MessageText = "Hi all", Date = DateTime.Now , Sender = new User { UserName = "First", FirstName = "Adam", LastName = "Smith", /*Password = "123", Role = "Ranger" */}}
                                }
                            }
                        },
                        Achievement  = new Achievement()
                        {
                            Description = "Drank water",
                            Points = 10,
                            MissionGroup = 1
                        },
                        DateAwarded = new DateTime(2022,12,15)
                    },
                    new UserAchievement()
                    {
                        User = new User()
                        {
                            UserName = "Benname",
                            FirstName = "Ben",
                            LastName = "Eckersley",
                            //Password = "123",
                            //Role = "Student",
                            Classroom = new Classroom()
                            {
                                JoinCode = "class2",
                                Name = "Junior Rangers 2",
                            }
                        },
                        Achievement  = new Achievement()
                        {
                            Description = "Slept",
                            Points = 10,
                            MissionGroup = 1
                        },
                        DateAwarded = new DateTime(2023,11,15)
                    },
                    new UserAchievement()
                    {
                        User = new User()
                        {
                            UserName = "SP",
                            FirstName = "Sonnie",
                            LastName = "Poon",
                            //Password = "123",
                            //Role = "Student",
                            Classroom = new Classroom()
                            {
                                JoinCode = "class3",
                                Name = "The Rangers",
                            }
                        },
                        Achievement  = new Achievement()
                        {
                            Description = "Ate",
                            Points = 20,
                            MissionGroup = 1
                        },
                        DateAwarded = new DateTime(2022,01,15)
                    },
                    new UserAchievement()
                    {
                        User = new User()
                        {
                            UserName = "Br",
                            FirstName = "Bree",
                            LastName = "Pederson",
                            //Password = "123",
                            //Role = "Student",
                            Classroom = new Classroom()
                            {
                                JoinCode = "class4",
                                Name = "Team 4",
                            }
                        },
                        Achievement  = new Achievement()
                        {
                            Description = "Studied",
                            Points = 15,
                            MissionGroup = 2
                        },
                        DateAwarded = new DateTime(2023,11,15)
                    }
                };
                dataContext.UserAchievements.AddRange(UserAchievements);
                dataContext.SaveChanges();
            }
        }
    }
}
