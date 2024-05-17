using Azure.Core;
using JuniorRangers_API.Data;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;

namespace JuniorRangers_API.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private DataContext _context;

        public MessageRepository(DataContext context) {
            _context = context;
        }
        public ICollection<Message> GetClassAnnouncements(int classId)
        {
            return _context.Messages.Where(m => m.Classroom.ClassId == classId && m.MessageType == "Announcement").ToList();
        }

        public ICollection<Message> GetClassEvents(int classId)
        {
            return _context.Messages.Where(m => m.Classroom.ClassId == classId && m.MessageType == "Event").ToList();
        }

        public ICollection<Message> GetClassChats(int classId)
        {
            return _context.Messages.Where(m => m.Classroom.ClassId == classId && m.MessageType == "Chat").ToList();
        }

        public Message GetMessage(int messageId)
        {
            return _context.Messages.Where(b => b.MessageID == messageId).FirstOrDefault();
        }

        public bool MessageExists(int messageId)
        {
            return _context.Messages.Any(m => m.MessageID == messageId);
        }

        public bool CreateMessage(Message message)
        {
            _context.Add(message);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Message> GetMessages()
        {
            return _context.Messages.OrderBy(m => m.MessageID).ToList();
        }

        public bool UpdateMessage(Message message)
        {
            _context.Update(message);
            return Save();
        }

        public bool DeleteMessage(Message message)
        {
            _context.Remove(message);
            return Save();
        }
    }
}
