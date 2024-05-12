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
        private IMapper _mapper;

        public AchievementController(IAchievementRepository achievementRepository, IMapper mapper)
        {
            _achievementRepository = achievementRepository;
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

        [HttpGet("user/{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Achievement>))]
        [ProducesResponseType(400)]
        public IActionResult GetAchievementsByUser(int userId)
        {
            var achievements = _mapper.Map<List<AchievementDto>>(_achievementRepository.GetAchievementsByUser(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(achievements);
        }
    }
}
