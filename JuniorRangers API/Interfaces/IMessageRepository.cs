using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IMessageRepository
    {
        ICollection<Message> GetClassAnnouncements(int classId);
        ICollection<Message> GetClassEvents(int classId);
        ICollection<Message> GetClassChats(int classId);
        Message GetMessage(int classId);
        bool MessageExists(int messageId);
    }
}
