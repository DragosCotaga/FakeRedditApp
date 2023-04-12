using FakeRedditApp.Data.Models;
using FakeRedditApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeRedditApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetAllPosts()
        {
            return _postService.GetAllPosts();
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetPostById(string id)
        {
            return _postService.GetPostById(id);
        }

        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            _postService.AddPost(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost(string id, Post post)
        {
            if (id != post.Id) return BadRequest();

            _postService.UpdatePost(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(string id)
        {
            _postService.DeletePost(id);
            return NoContent();
        }
    }
}
