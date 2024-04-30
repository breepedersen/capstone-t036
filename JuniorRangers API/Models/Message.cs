namespace JuniorRangers_API.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public String MessageType { get; set; }     //Announcement, Event, Chat
        public Classroom Classroom { get; set; }
        public String MessageText { get; set; }
        public User Sender { get; set; }
        public DateTime Date { get; set; }          //Event date (if messagetype event), post date (is messagetype announcement or chat)
    }
}
