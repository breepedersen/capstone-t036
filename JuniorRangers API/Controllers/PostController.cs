using AutoMapper;
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
        private IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper) {
        
            _postRepository = postRepository;
            _mapper = mapper;
        }


        [HttpGet("{postId}")]
        [ProducesResponseType(200, Type = typeof(Post))]
        [ProducesResponseType(400)]
        public IActionResult GetPost(int postId)
        {
            if (!_postRepository.PostExists(postId))
                return NotFound();

            var post = _mapper.Map<Post>(_postRepository.GetPost(postId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(post);
        }

        [HttpGet("classoom/{classId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(400)]
        public IActionResult GetPostsByClassroom(int classId)
        {
            var posts = _mapper.Map<List<Post>>(_postRepository.GetPostsByClassroom(classId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(posts);
        }
    }
}
