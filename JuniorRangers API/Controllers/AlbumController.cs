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
    public class AlbumController : Controller
    {
        private IAlbumRepository _albumRepository;
        private IClassroomRepository _classroomRepository;
        private IMapper _mapper;

        public AlbumController(IAlbumRepository albumRepository, IClassroomRepository classroomRepository, IMapper mapper) {
            _albumRepository = albumRepository;
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }

        //GET METHODS
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Album>))]
        public IActionResult GetAlbums()
        {
            var albums = _mapper.Map<List<AlbumDto>>(_albumRepository.GetAlbums());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(albums);
        }

        [HttpGet("{albumId}")]
        [ProducesResponseType(200, Type = typeof(Album))]
        [ProducesResponseType(400)]
        public IActionResult GetAlbum(int albumId)
        {
            if (!_albumRepository.AlbumExists(albumId))
                return NotFound();

            var album = _mapper.Map<AlbumDto>(_albumRepository.GetAlbum(albumId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(album);
        }

        [HttpGet("classoom/{classId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Album>))]
        [ProducesResponseType(400)]
        public IActionResult GetAlbumsByClassroom(int classId)
        {
            var albums = _mapper.Map<List<AlbumDto>>(_albumRepository.GetAlbumsByClassroom(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(albums);
        }


        //POST METHODS
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAlbum([FromQuery] int classId, [FromBody] AlbumDto albumCreate)
        {
            if (albumCreate == null)
                return BadRequest(ModelState);

            var albums = _albumRepository.GetAlbums()
                .Where(a => a.Name.Trim().ToUpper() == albumCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (albums != null)
            {
                ModelState.AddModelError("", "Album already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var albumMap = _mapper.Map<Album>(albumCreate);
            albumMap.Classroom = _classroomRepository.GetClassroom(classId);


            if (!_albumRepository.CreateAlbum(albumMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }


}
