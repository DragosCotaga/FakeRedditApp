using FakeRedditApp.Data.Models;
using FakeRedditApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeRedditApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubForumController : ControllerBase
    {
        private readonly SubForumService _subForumService;

        public SubForumController(SubForumService subForumService)
        {
            _subForumService = subForumService;
        }

        [HttpGet]
        public ActionResult<List<SubForum>> GetAllSubForums()
        {
            return _subForumService.GetAllSubForums();
        }

        [HttpGet("{id}")]
        public ActionResult<SubForum> GetSubForumById(string id)
        {
            return _subForumService.GetSubForumById(id);
        }

        [HttpPost]
        public IActionResult AddSubForum(SubForum subForum)
        {
            _subForumService.AddSubForum(subForum);
            return CreatedAtAction(nameof(GetSubForumById), new { id = subForum.Id }, subForum);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubForum(string id, SubForum subForum)
        {
            if (id != subForum.Id) return BadRequest();

            _subForumService.UpdateSubForum(subForum);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubForum(string id)
        {
            _subForumService.DeleteSubForum(id);
            return NoContent();
        }
    }
}
