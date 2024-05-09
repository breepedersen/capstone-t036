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
    }
}
