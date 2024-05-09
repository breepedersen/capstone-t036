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
    public class PictureController : Controller
    {
        private IPictureRepository _pictureRepository;
        private IMapper _mapper;

        public PictureController(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }


        [HttpGet("{picId}")]
        [ProducesResponseType(200, Type = typeof(Picture))]
        [ProducesResponseType(400)]
        public IActionResult GetPicture(int picId)
        {
            if (!_pictureRepository.PictureExists(picId))
                return NotFound();

            var picture = _mapper.Map<Picture>(_pictureRepository.GetPicture(picId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(picture);
        }

        [HttpGet("post/{postId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Picture>))]
        [ProducesResponseType(400)]
        public IActionResult GetPicturesByPost(int postId)
        {
            var pictures = _mapper.Map<List<Picture>>(_pictureRepository.GetPicturesByPost(postId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pictures);
        }

        [HttpGet("album/{albumId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Picture>))]
        [ProducesResponseType(400)]
        public IActionResult GetPicturesByAlbum(int albumId)
        {
            var pictures = _mapper.Map<List<Picture>>(_pictureRepository.GetPicturesByAlbum(albumId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pictures);
        }
    }
}
