﻿using AutoMapper;
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

        //GET METHODS
        //Get list of all classrooms
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Classroom>))]
        public IActionResult GetClassrooms()
        {
            var classrooms = _mapper.Map<List<ClassroomDto>>(_classroomRepository.GetClassrooms());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(classrooms);

        }

        //Get a classroom by ID
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

        //Get list of users of a classroom
        [HttpGet("user/{classId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetUserByClassroom(int classId)
        {
            if (!_classroomRepository.ClassroomExists(classId))
                return NotFound();

            var users = _mapper.Map<List<UserDto>>(_classroomRepository.GetUsersByClassroom(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }


        //POST METHODS
        /// <summary>
        /// Create a classroom (only admin is able to)
        /// </summary>
        /// <param name="classroomCreate">Input ClassroomDto fields: name, location</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClassroom([FromBody] ClassroomDto classroomCreate)
        {
            if (classroomCreate == null)
                return BadRequest(ModelState);

            var classrooms = _classroomRepository.GetClassrooms()
                .Where(c => c.Name.Trim().ToUpper() == classroomCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (classrooms != null)
            {
                ModelState.AddModelError("", "Class name already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var classroomMap = _mapper.Map<Classroom>(classroomCreate);
            classroomMap.JoinCode = GenerateJoinCode(); //Generates random 7-digit join code


            if (!_classroomRepository.CreateClassroom(classroomMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        private string GenerateJoinCode()
        {
            var random = new Random();
            var joinCode = new string(Enumerable.Repeat("0123456789", 7)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return joinCode;
        }

        //PUT METHODS
        //Update a classroom's name or location
        [HttpPut("classId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateClassroom(int classId, [FromBody] ClassroomDto updatedClassroom)
        {
            if (updatedClassroom == null)
                return BadRequest(ModelState);

            if (classId != updatedClassroom.ClassId)
                return BadRequest(ModelState);

            if (!_classroomRepository.ClassroomExists(classId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var classroomMap = _mapper.Map<Classroom>(updatedClassroom);
            classroomMap.JoinCode = _classroomRepository.GetClassroom(classId).JoinCode;

            if (!_classroomRepository.UpdateClassroom(classroomMap))
            {
                ModelState.AddModelError("", "Something went wrong updating classroom");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        //DELETE METHODS
        //Delete a classroom
        [HttpDelete("classId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteClassroom(int classId)
        {
            if (!_classroomRepository.ClassroomExists(classId))
            {
                return NotFound();
            }

            var classroomToDelete = _classroomRepository.GetClassroom(classId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_classroomRepository.DeleteClassroom(classroomToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting classroom");
            }

            return NoContent();
        }
    }
}
