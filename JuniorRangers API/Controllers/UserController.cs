using AutoMapper;
using JuniorRangers_API.Dto;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;
using JuniorRangers_API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace JuniorRangers_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IClassroomRepository classroomRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }

        //GET METHODS
        //Get list of all users
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var user = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        //Get a specific user by ID
        [HttpGet("{userNumber}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userNumber) 
        {
            if (!_userRepository.UserExists(userNumber))
                return NotFound();

            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userNumber));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }



        //POST METHODS



        //PUT METHODS
        //Update a user's UserDto fields (username, name, lastname)
        [HttpPut("updateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int userNumber, [FromBody] UserDto updatedUser)
        {
            if (updatedUser == null)
                return BadRequest(ModelState);

            if (userNumber != updatedUser.UserNumber)
                return BadRequest(ModelState);

            if (!_userRepository.UserExists(userNumber))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            // Get the user
            var existingUser = _userRepository.GetUser(userNumber);
            if (existingUser == null)
                return NotFound();

            // Update the necessary fields
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.UserName = updatedUser.UserName;

            if (!_userRepository.UpdateUser(existingUser))
            {
                ModelState.AddModelError("", "Something went wrong updating user");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //Manually ssign user to a classroom
        [Authorize(Roles = "Admin,Ranger")]
        [HttpPut("updateUserClass")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUserClass(int userNumber, [FromQuery] int classId)
        {
            if (!_userRepository.UserExists(userNumber))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var user = _userRepository.GetUser(userNumber);
            var currentClass = user.Classroom;
            var updatedClass = _classroomRepository.GetClassroom(classId);

            if (classId == (currentClass == null ? 0 : currentClass.ClassId))
            {
                ModelState.AddModelError("", "Please choose a different classroom.");
                return StatusCode(500, ModelState);
            }

            user.Classroom = updatedClass;

            if (!_userRepository.UpdateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong updating user classroom");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }



        //DELETE METHODS
        [HttpDelete("userNumber")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userNumber)
        {
            if (!_userRepository.UserExists(userNumber))
            {
                return NotFound();
            }

            var userToDelete = _userRepository.GetUser(userNumber);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting user");
            }

            return NoContent();
        }

    }
}
