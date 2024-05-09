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


        public AchievementController(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Achievement>))]
        public IActionResult GetAchievements()
        {
            var achievements = _achievementRepository.GetAchievements();

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

            var achievement = _achievementRepository.GetAchievement(achievementId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(achievement);
        }

        [HttpGet("user/{achievementId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetUsersByAchievement(int achievementId)
        {
            if (!_achievementRepository.AchievementExists(achievementId))
                return NotFound();

            var users = _achievementRepository.GetUsersByAchievement(achievementId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }
    }
}
