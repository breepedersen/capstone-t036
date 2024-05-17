using JuniorRangers_API.Models;
using System.ComponentModel.DataAnnotations;

namespace JuniorRangers_API.Dto
{
    public class MessageDto
    {
        public int MessageID { get; set; }

        public String MessageType { get; set; }     //Announcement, Event, Chat

        public String MessageTitle { get; set; }
        public String MessageText { get; set; }

        //public User? Sender { get; set; }

        public DateTime Date { get; set; }          //Event date (if messagetype event), post date (is messagetype announcement or chat)
    }
}
