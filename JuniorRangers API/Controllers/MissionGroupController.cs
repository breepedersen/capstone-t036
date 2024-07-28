using AutoMapper;
using JuniorRangers_API.Dto;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;
using JuniorRangers_API.Models.JoinTables;
using JuniorRangers_API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuniorRangers_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MissionGroupController : Controller
    {
        private IMissionGroupRepository _missionGroupRepository;
        private IAchievementRepository _achievementRepository;
        private IUserRepository _userRepository;
        private IClassroomRepository _classroomRepository;
        private IMapper _mapper;

        public MissionGroupController(IMissionGroupRepository missionGroupRepository, IAchievementRepository achievementRepository, IUserRepository userRepository, IClassroomRepository classroomRepository, IMapper mapper)
        {
            _missionGroupRepository = missionGroupRepository;
            _achievementRepository = achievementRepository;
            _userRepository = userRepository;
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }


        //GET METHODS
        //Get list of all mission groups
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MissionGroup>))]
        public IActionResult GetMissionGroups()
        {
            var missionGroups = _missionGroupRepository.GetMissionGroups();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(missionGroups);
        }

        //Get list of all achievements in a missiongroup by missiongroupID
        [HttpGet("{missionGroupId}/achievements")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Achievement>))]
        [ProducesResponseType(400)]
        public IActionResult GetAchievementsByMissionGroup(int missionGroupId)
        {
            if (!_missionGroupRepository.MissionGroupExists(missionGroupId))
                return NotFound();

            var missions = _mapper.Map<List<AchievementDto>>(_missionGroupRepository.GetAchievementsByMissionGroup(missionGroupId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(missions);
        }

        //POST METHODS
        //Create a new mission group (input a name, description)
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateMissionGroup([FromBody] MissionGroupDto missionGroupCreate)
        {
            if (missionGroupCreate == null)
                return BadRequest(ModelState);

            var missionGroups = _missionGroupRepository.GetMissionGroups()
                .Where(c => c.Name.Trim().ToUpper() == missionGroupCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (missionGroups != null)
            {
                ModelState.AddModelError("", "Mini-mission name already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var missionGroupMap = _mapper.Map<MissionGroup>(missionGroupCreate);


            if (!_missionGroupRepository.CreateMissionGroup(missionGroupMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        //Add an achievement to a mission group
        [HttpPost("addToMissionGroup")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddAchievementToMissionGroup([FromQuery] int achievementId, [FromQuery] int missionGroupId)
        {
            //check if achievement and mission groups exist
            if (!_achievementRepository.AchievementExists(achievementId))
                return NotFound();
            if (!_missionGroupRepository.MissionGroupExists(missionGroupId))
                return NotFound();

            //create a new entry in missiongroup-achievement join table
            var achievementMissionGroup = new AchievementMissionGroup();

            achievementMissionGroup.Achievement = _achievementRepository.GetAchievement(achievementId);
            achievementMissionGroup.MissionGroup = _missionGroupRepository.GetMissionGroup(missionGroupId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_missionGroupRepository.AddAchievementToMissionGroup(achievementMissionGroup))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully added to mission group");
        }

        //Assign mission group to a classroom
        [HttpPost("addToClassroom")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AssignMissionGroupToClass([FromQuery] int missionGroupId, [FromQuery] int classroomId)
        {
            //check if achievement and mission groups exist
            if (!_missionGroupRepository.MissionGroupExists(missionGroupId))
                return NotFound();
            if (!_classroomRepository.ClassroomExists(classroomId))
                return NotFound();

            //create a new entry in missiongroup-achievement join table
            var classMissions = new ClassMission
            {
                ClassId = classroomId,
                MissionGroupId = missionGroupId,
                DateAssigned = DateTime.Now
            };

            //when assigning a missiongroup to a class, also track individual completion statuses of each achievement
            var achievements = _missionGroupRepository.GetAchievementsByMissionGroup(missionGroupId);
            foreach (var achievement in achievements)
            {
                var achievementId = achievement.AchievementId;
                var classMissionStatus = new ClassMissionStatus
                {
                    ClassroomId = classroomId,
                    MissionGroupId = missionGroupId,
                    AchievementId = achievementId,
                    IsAchievementComplete = false,
                    DateAssigned = classMissions.DateAssigned,

                    Classroom = _classroomRepository.GetClassroom(classroomId),
                    MissionGroup = _missionGroupRepository.GetMissionGroup(missionGroupId),
                    Achievement = _achievementRepository.GetAchievement(achievementId)
                };

                if (!_missionGroupRepository.AddClassMissionStatus(classMissionStatus))
                {
                    ModelState.AddModelError("", "Something went wrong while saving");
                    return StatusCode(500, ModelState);
                }
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_missionGroupRepository.AssignMissionGroupToClass(classMissions))
            {
                ModelState.AddModelError("", "Something went wrong while assigning mission group to class");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully assigned mission group to class");
        }


        //PUT METHODS
        //Edit mission group details
        [HttpPut("missionGroupId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMissionGroup(int missionGroupId, [FromBody] MissionGroupDto updatedMissionGroup)
        {
            if (updatedMissionGroup == null)
                return BadRequest(ModelState);

            if (missionGroupId != updatedMissionGroup.MissionGroupId)
                return BadRequest(ModelState);

            if (!_missionGroupRepository.MissionGroupExists(missionGroupId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var missionGroupMap = _mapper.Map<MissionGroup>(updatedMissionGroup);

            if (!_missionGroupRepository.UpdateMissionGroup(missionGroupMap))
            {
                ModelState.AddModelError("", "Something went wrong updating mission group");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //Update completion status of an achievement in a missiongroup assigned to a class
        [HttpPut("missionGroupId/achievementId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateClassAchievementStatus([FromQuery] int classroomId, [FromQuery] int missionGroupId, [FromQuery] int achievementId, [FromQuery] bool CompletionStatus)
        {
            //check if class, mission group and achievement exist
            if (!_classroomRepository.ClassroomExists(classroomId))
                return NotFound();
            if (!_missionGroupRepository.MissionGroupExists(missionGroupId))
                return NotFound();
            if (!_achievementRepository.AchievementExists(achievementId))
                return NotFound();

            //Get classmissionstatus and update status
            var classMissionStatus = _missionGroupRepository.GetClassMissionStatus(classroomId,missionGroupId,achievementId);

            classMissionStatus.IsAchievementComplete = CompletionStatus;
            if (CompletionStatus == true)
            {
                classMissionStatus.DateCompleted = DateTime.Now;
            }

            if (!_missionGroupRepository.UpdateClassAchievementStatus(classMissionStatus))
            {
                ModelState.AddModelError("", "Something went wrong achievement completion status");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
