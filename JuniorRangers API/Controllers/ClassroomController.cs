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
    public class ClassroomController : Controller
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;

        public ClassroomController(IClassroomRepository classroomRepository, IMapper mapper) 
        {
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Classroom>))]
        public IActionResult GetClassrooms()
        {
            var classrooms = _mapper.Map<List<ClassroomDto>>(_classroomRepository.GetClassrooms());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(classrooms);

        }

        [HttpGet("{classId}")]
        [ProducesResponseType(200, Type = typeof(Classroom))]
        [ProducesResponseType(400)]
        public IActionResult GetClassroom(int classId)
        {
            if (!_classroomRepository.ClassroomExists(classId))
                return NotFound();

            var user = _mapper.Map<ClassroomDto>(_classroomRepository.GetClassroom(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("user/{classId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Classroom>))]
        [ProducesResponseType(400)]
        public IActionResult GetUserByClassroom(int classId)
        {
            if (!_classroomRepository.ClassroomExists(classId))
                return NotFound();

            var users = _mapper.Map<List<ClassroomDto>>(_classroomRepository.GetUserByClassroom(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }
    }
}
