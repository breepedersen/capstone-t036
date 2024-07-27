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
    public class AchievementController : Controller
    {
        private IAchievementRepository _achievementRepository;
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public AchievementController(IAchievementRepository achievementRepository, IUserRepository userRepository, IMapper mapper)
        {
            _achievementRepository = achievementRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        //Get all achievements
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Achievement>))]
        public IActionResult GetAchievements()
        {
            var achievements = _mapper.Map<List<AchievementDto>>(_achievementRepository.GetAchievements());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(achievements);

        }

        //Get a specific achievement by ID
        [HttpGet("{achievementId}")]
        [ProducesResponseType(200, Type = typeof(Achievement))]
        [ProducesResponseType(400)]
        public IActionResult GetAchievement(int achievementId)
        {
            if (!_achievementRepository.AchievementExists(achievementId))
                return NotFound();

            var achievement = _mapper.Map<AchievementDto>(_achievementRepository.GetAchievement(achievementId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(achievement);
        }

        //Get list of achievements by missiongroupID
        [HttpGet("mission/{missionGroup}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Achievement>))]
        [ProducesResponseType(400)]
        public IActionResult GetAchievementsByMissionGroup(int missionGroup)
        {
            var missions = _mapper.Map<List<AchievementDto>>(_achievementRepository.GetAchievementsByMissionGroup(missionGroup));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(missions);
        }

        //Get list of users that have been awarded a specific achievement
        [HttpGet("{achievementId}/users")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetUsersByAchievement(int achievementId)
        {
            if (!_achievementRepository.AchievementExists(achievementId))
                return NotFound();

            var users = _mapper.Map<List<UserDto>>(_achievementRepository.GetUsersByAchievement(achievementId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        //Get list of achievements that have been awarded to a specific user
        [HttpGet("user/{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Achievement>))]
        [ProducesResponseType(400)]
        public IActionResult GetAchievementsByUser(int userNumber)
        {
            var achievements = _mapper.Map<List<AchievementDto>>(_achievementRepository.GetAchievementsByUser(userNumber));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(achievements);
        }


        //POST METHODS
        //Create an achievement
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAchievement([FromBody] AchievementDto achievementCreate)
        {
            if (achievementCreate == null)
                return BadRequest(ModelState);

            var achievements = _achievementRepository.GetAchievements()
                .Where(c => c.Description.Trim().ToUpper() == achievementCreate.Description.Trim().ToUpper())
                .FirstOrDefault();

            if (achievements != null)
            {
                ModelState.AddModelError("", "Achievement already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var achievementMap = _mapper.Map<Achievement>(achievementCreate);


            if (!_achievementRepository.CreateAchievement(achievementMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        /// <summary>
        /// Award an achievement to a user
        /// </summary>
        /// <param name="achievementId">The achievement to be awarded</param>
        /// <param name="userNumber">The user to receive the achievement</param>
        /// <returns></returns>
        [HttpPost("userAchievement")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AwardAchievement([FromQuery] int achievementId, [FromQuery] int userNumber)
        {

            if (!_achievementRepository.AchievementExists(achievementId))
                return NotFound();
            if (!_userRepository.UserExists(userNumber))
                return NotFound();

            var userAchievement = new UserAchievement();

            userAchievement.User = _userRepository.GetUser(userNumber);
            userAchievement.Achievement = _achievementRepository.GetAchievement(achievementId);
            userAchievement.UserNumber = userNumber;
            userAchievement.AchievementId = achievementId;
            userAchievement.DateAwarded = DateTime.Now;


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_achievementRepository.AwardAchievement(userAchievement))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully awarded");
        }


        //PUT METHODS
        //Update an achievement
        [HttpPut("achievementId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAchievement(int achievementId, [FromBody] AchievementDto updatedAchievement)
        {
            if (updatedAchievement == null)
                return BadRequest(ModelState);

            if (achievementId != updatedAchievement.AchievementId)
                return BadRequest(ModelState);

            if (!_achievementRepository.AchievementExists(achievementId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var achievementMap = _mapper.Map<Achievement>(updatedAchievement);

            if (!_achievementRepository.UpdateAchievement(achievementMap))
            {
                ModelState.AddModelError("", "Something went wrong updating achievement");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        //DELETE METHODS
        //Delete an achievement
        [HttpDelete("achievementId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAchievement(int achievementId)
        {
            if (!_achievementRepository.AchievementExists(achievementId))
            {
                return NotFound();
            }

            var achievementToDelete = _achievementRepository.GetAchievement(achievementId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_achievementRepository.DeleteAchievement(achievementToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
