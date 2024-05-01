﻿namespace JuniorRangers_API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Role { get; set; }
        public Classroom? Classroom { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Picture> Picures { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserAchievement> UserAchievement { get; set; }
    }
}
