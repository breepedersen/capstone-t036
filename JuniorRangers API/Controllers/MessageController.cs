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

        public MessageController(IMessageRepository messageRepository, IMapper mapper) {
        
            _messageRepository = messageRepository;
            _mapper = mapper;
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
    }
}
