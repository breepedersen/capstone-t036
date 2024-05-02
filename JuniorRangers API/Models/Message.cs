using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuniorRangers_API.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [StringLength(20)]
        public String MessageType { get; set; }     //Announcement, Event, Chat

        [StringLength(1000)]
        public String MessageText { get; set; }

        public Classroom Classroom { get; set; }
        public User? Sender { get; set; }
        public DateTime Date { get; set; }          //Event date (if messagetype event), post date (is messagetype announcement or chat)
    }
}
