using AutoMapper;
using JuniorRangers_API.Dto;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;
using JuniorRangers_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JuniorRangers_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private IMessageRepository _messageRepository;
        private IMapper _mapper;
        private IClassroomRepository _classroomRepository;
        private IUserRepository _userRepository;

        public MessageController(IMessageRepository messageRepository, IUserRepository userRepository, IClassroomRepository classroomRepository, IMapper mapper) {

            _classroomRepository = classroomRepository;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Message>))]
        public IActionResult GetMessages()
        {
            var messages = _mapper.Map<List<MessageDto>>(_messageRepository.GetMessages());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(messages);
        }

        [HttpGet("{messageId}")]
        [ProducesResponseType(200, Type = typeof(Message))]
        [ProducesResponseType(400)]
        public IActionResult GetMessage(int messageId)
        {
            if (!_messageRepository.MessageExists(messageId))
                return NotFound();

            var message = _mapper.Map<MessageDto>(_messageRepository.GetMessage(messageId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(message);
        }

        [HttpGet("{classId}/Announcements")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Message>))]
        [ProducesResponseType(400)]
        public IActionResult GetClassAnnouncements(int classId) 
        {
            var announcements = _mapper.Map<List<MessageDto>>(_messageRepository.GetClassAnnouncements(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(announcements);
        }

        [HttpGet("{classId}/Events")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Message>))]
        [ProducesResponseType(400)]
        public IActionResult GetClassEvents(int classId)
        {
            var events = _mapper.Map<List<MessageDto>>(_messageRepository.GetClassEvents(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{classId}/Chats")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Message>))]
        [ProducesResponseType(400)]
        public IActionResult GetClassChats(int classId)
        {
            var chats = _mapper.Map<List<MessageDto>>(_messageRepository.GetClassChats(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(chats);
        }


        //POST METHODS
        [HttpPost("Announcement")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAnnouncement([FromQuery] string title, [FromQuery] string announcementText, [FromQuery] int userId, [FromQuery] int classId)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Message message = new Message();
            var messageMap = _mapper.Map<Message>(message);
            messageMap.MessageType = "Announcement";
            messageMap.MessageTitle = title;
            messageMap.MessageText = announcementText;
            messageMap.Date = DateTime.Now;
            messageMap.Sender = _userRepository.GetUser(userId);
            messageMap.Classroom = _classroomRepository.GetClassroom(classId);


            if (!_messageRepository.CreateMessage(messageMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPost("Event")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEvent([FromQuery] string title, [FromQuery] string eventText, [FromQuery] DateTime date, [FromQuery] int userId, [FromQuery] int classId)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Message message = new Message();
            var messageMap = _mapper.Map<Message>(message);
            messageMap.MessageType = "Event";
            messageMap.MessageTitle = title;
            messageMap.MessageText = eventText;
            messageMap.Date = date;
            messageMap.Sender = _userRepository.GetUser(userId);
            messageMap.Classroom = _classroomRepository.GetClassroom(classId);


            if (!_messageRepository.CreateMessage(messageMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPost("Chat")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateChat([FromQuery] string chatText, [FromQuery] int userId, [FromQuery] int classId)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Message message = new Message();
            var messageMap = _mapper.Map<Message>(message);
            messageMap.MessageType = "Chat";
            messageMap.MessageText = chatText;
            messageMap.Date = DateTime.Now;
            messageMap.Sender = _userRepository.GetUser(userId);
            messageMap.Classroom = _classroomRepository.GetClassroom(classId);


            if (!_messageRepository.CreateMessage(messageMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        //PUT METHODS
        [HttpPut("messageId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMessage(int messageId, [FromBody] MessageDto updatedMessage)
        {
            if (updatedMessage == null)
                return BadRequest(ModelState);

            if (messageId != updatedMessage.MessageID)
                return BadRequest(ModelState);

            if (!_messageRepository.MessageExists(messageId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var messageMap = _mapper.Map<Message>(updatedMessage);

            if (!_messageRepository.UpdateMessage(messageMap))
            {
                ModelState.AddModelError("", "Something went wrong updating message");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        //DELETE METHODS
        [HttpDelete("messageId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteMessage(int messageId)
        {
            if (!_messageRepository.MessageExists(messageId))
            {
                return NotFound();
            }

            var messageToDelete = _messageRepository.GetMessage(messageId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_messageRepository.DeleteMessage(messageToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting message");
            }

            return NoContent();
        }
    }
}
