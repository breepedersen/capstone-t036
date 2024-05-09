using AutoMapper;
using JuniorRangers_API.Dto;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace JuniorRangers_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AlbumController : Controller
    {
        private IAlbumRepository _albumRepository;
        private IMapper _mapper;

        public AlbumController(IAlbumRepository albumRepository, IMapper mapper) {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }


        [HttpGet("{albumId}")]
        [ProducesResponseType(200, Type = typeof(Album))]
        [ProducesResponseType(400)]
        public IActionResult GetAlbum(int albumId)
        {
            if (!_albumRepository.AlbumExists(albumId))
                return NotFound();

            var album = _mapper.Map<Album>(_albumRepository.GetAlbum(albumId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(album);
        }

        [HttpGet("classoom/{classId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Album>))]
        [ProducesResponseType(400)]
        public IActionResult GetAlbumsByClassroom(int classId)
        {
            var albums = _mapper.Map<List<Album>>(_albumRepository.GetAlbumsByClassroom(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(albums);
        }
    }


}
