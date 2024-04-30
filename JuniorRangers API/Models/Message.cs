namespace JuniorRangers_API.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public String Text { get; set; }
        public Classroom Classroom { get; set; }
    }
}
