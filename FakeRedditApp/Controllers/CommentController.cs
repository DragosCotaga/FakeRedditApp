using FakeRedditApp.Data.Models;
using FakeRedditApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeRedditApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult<List<Comment>> GetAllComments()
        {
            return _commentService.GetAllComments();
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetCommentById(string id)
        {
            return _commentService.GetCommentById(id);
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            _commentService.AddComment(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(string id, Comment comment)
        {
            if (id != comment.Id) return BadRequest();

            _commentService.UpdateComment(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(string id)
        {
            _commentService.DeleteComment(id);
            return NoContent();
        }
    }
}
