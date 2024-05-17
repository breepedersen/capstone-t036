﻿using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Models
{
    public class Classroom
    {
        [Key]
        public int ClassId { get; set; }
        public string Name { get; set; }

        [StringLength(10)]
        public String JoinCode { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
