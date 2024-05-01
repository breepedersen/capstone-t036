using System.ComponentModel.DataAnnotations.Schema;

namespace JuniorRangers_API.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public String MessageType { get; set; }     //Announcement, Event, Chat
        public String MessageText { get; set; }

        [ForeignKey("ClassId")]
        public Classroom Classroom { get; set; }

        [ForeignKey("SenderId")]
        public User? User { get; set; }
        public DateTime Date { get; set; }          //Event date (if messagetype event), post date (is messagetype announcement or chat)
    }
}
