using AutoMapper;
using JuniorRangers_API.Dto;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;
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
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var user = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userId) 
        {
            if (!_userRepository.UserExists(userId))
                return NotFound();

            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }



        //POST METHODS
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromQuery] string password,[FromBody] UserDto userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            var users = _userRepository.GetUsers()
                .Where(c => c.Username.Trim().ToUpper() == userCreate.Username.Trim().ToUpper())
                .FirstOrDefault();

            if (users != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);
            userMap.Password = password;


            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

    }
}
