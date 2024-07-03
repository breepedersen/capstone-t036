using AutoMapper;
using JuniorRangers_API.Dto;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;
using JuniorRangers_API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace JuniorRangers_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private IPostRepository _postRepository;
        private IUserRepository _userRepository;
        private IClassroomRepository _classroomRepository;
        private IPictureRepository _pictureRepository;
        private IMapper _mapper;

        public PostController(IPostRepository postRepository, IUserRepository userRepository, IClassroomRepository classroomRepository, IPictureRepository pictureRepository, IMapper mapper) {
        
            _postRepository = postRepository;
            _userRepository = userRepository;
            _classroomRepository = classroomRepository;
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Post>))]
        public IActionResult GetPosts()
        {
            var posts = _mapper.Map<List<PostDto>>(_postRepository.GetPosts());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(posts);
        }


        [HttpGet("{postId}")]
        [ProducesResponseType(200, Type = typeof(Post))]
        [ProducesResponseType(400)]
        public IActionResult GetPost(int postId)
        {
            if (!_postRepository.PostExists(postId))
                return NotFound();

            var post = _mapper.Map<PostDto>(_postRepository.GetPost(postId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(post);
        }

        [HttpGet("classoom/{classId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(400)]
        public IActionResult GetPostsByClassroom(int classId)
        {
            var posts = _mapper.Map<List<PostDto>>(_postRepository.GetPostsByClassroom(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(posts);
        }


        //POST METHODS
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePost([FromBody] PostDto postCreate, [FromQuery] string userId, [FromQuery] int classId)
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

            var postMap = _mapper.Map<Post>(postCreate);
            postMap.PostDate = DateTime.Now;
            postMap.Likes = 0;
            postMap.Poster = _userRepository.GetUser(userId);
            postMap.Classroom = _classroomRepository.GetClassroom(classId);

            if (!_postRepository.CreatePost(postMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        //PUT METHODS
        [HttpPut("postId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePost(int postId, [FromBody] PostDto updatedPost)
        {
            if (updatedPost == null)
                return BadRequest(ModelState);

            if (postId != updatedPost.PostId)
                return BadRequest(ModelState);

            if (!_postRepository.PostExists(postId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var postMap = _mapper.Map<Post>(updatedPost);

            if (!_postRepository.UpdatePost(postMap))
            {
                ModelState.AddModelError("", "Something went wrong updating post");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        //DELETE METHODS
        [HttpDelete("postId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePost(int postId)
        {
            if (!_postRepository.PostExists(postId))
            {
                return NotFound();
            }

            var postToDelete = _postRepository.GetPost(postId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_postRepository.DeletePost(postToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting post");
            }

            return NoContent();
        }
    }
}
