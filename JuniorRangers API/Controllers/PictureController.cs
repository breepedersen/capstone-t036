using AutoMapper;
using JuniorRangers_API.Dto;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;
using JuniorRangers_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace JuniorRangers_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PictureController : Controller
    {
        private IPictureRepository _pictureRepository;
        private IUserRepository _userRepository;
        private IAlbumRepository _albumRepository;
        private IPostRepository _postRepository;
        private IMapper _mapper;

        public PictureController(IPictureRepository pictureRepository, IUserRepository userRepository, IAlbumRepository albumRepository, IPostRepository postRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _userRepository = userRepository;
            _albumRepository = albumRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Picture>))]
        public IActionResult GetPictures()
        {
            var pictures = _mapper.Map<List<PictureDto>>(_pictureRepository.GetPictures());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pictures);
        }

        [HttpGet("{picId}")]
        [ProducesResponseType(200, Type = typeof(Picture))]
        [ProducesResponseType(400)]
        public IActionResult GetPicture(int picId)
        {
            if (!_pictureRepository.PictureExists(picId))
                return NotFound();

            var picture = _mapper.Map<PictureDto>(_pictureRepository.GetPicture(picId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(picture);
        }

        [HttpGet("post/{postId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Picture>))]
        [ProducesResponseType(400)]
        public IActionResult GetPicturesByPost(int postId)
        {
            var pictures = _mapper.Map<List<PictureDto>>(_pictureRepository.GetPicturesByPost(postId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pictures);
        }

        [HttpGet("album/{albumId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Picture>))]
        [ProducesResponseType(400)]
        public IActionResult GetPicturesByAlbum(int albumId)
        {
            var pictures = _mapper.Map<List<PictureDto>>(_pictureRepository.GetPicturesByAlbum(albumId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pictures);
        }


        //POST METHODS
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePicture([FromBody] PictureDto pictureCreate, [FromQuery] string userId, [FromQuery] int? albumId, [FromQuery] int? postId)
        {
/*            if (pictureCreate == null)
                return BadRequest(ModelState);

            var pictures = _pictureRepository.GetPictures()
                .Where(c => c.Username.Trim().ToUpper() == pictureCreate.Username.Trim().ToUpper())
                .FirstOrDefault();

            if (pictures != null)
            {
                ModelState.AddModelError("", "Picture already exists");
                return StatusCode(422, ModelState);
            }*/

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pictureMap = _mapper.Map<Picture>(pictureCreate);
            pictureMap.UploadDate = DateTime.Now;
            pictureMap.Uploader = _userRepository.GetUser(userId);
            if (albumId != null) 
                pictureMap.Album = _albumRepository.GetAlbum((int)albumId);
            if (postId != null)
                pictureMap.Post = _postRepository.GetPost((int)postId);
            


            if (!_pictureRepository.CreatePicture(pictureMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        //PUT METHODS
        [HttpPut("pictureId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePicture(int pictureId, [FromBody] PictureDto updatedPicture)
        {
            if (updatedPicture == null)
                return BadRequest(ModelState);

            if (pictureId != updatedPicture.PictureId)
                return BadRequest(ModelState);

            if (!_pictureRepository.PictureExists(pictureId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var pictureMap = _mapper.Map<Picture>(updatedPicture);

            if (!_pictureRepository.UpdatePicture(pictureMap))
            {
                ModelState.AddModelError("", "Something went wrong updating picture");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        //DELETE METHODS
        [HttpDelete("pictureId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePicture(int pictureId)
        {
            if (!_pictureRepository.PictureExists(pictureId))
            {
                return NotFound();
            }

            var pictureToDelete = _pictureRepository.GetPicture(pictureId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_pictureRepository.DeletePicture(pictureToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting picture");
            }

            return NoContent();
        }
    }
}
