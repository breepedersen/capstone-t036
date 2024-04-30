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

/*        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(String fname, String lname)
        {
            if (!_userRepository.UserExists(fname, lname))
                return NotFound();

            var user = _userRepository.GetUser(fname, lname);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }*/

    }
}
