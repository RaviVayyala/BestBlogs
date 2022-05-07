using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Repository;

namespace Api.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly ICommentRepository _commentRepository;
        public readonly IPostRepository _postRepository;

        public PostController(ICommentRepository commentRepository, IPostRepository postRepository, ILogger<PostController> logger)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAll()
        {
            _logger.LogInformation("Get all");
            return Ok(_postRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public ActionResult<Post> Get([FromRoute] Guid id)
        {
            return Ok(_postRepository.Get(id));
        }

        [HttpPost]
        public ActionResult<Post> Post([FromBody] Post post)
        {
            return Ok(_postRepository.Create(post));
        }

        [HttpPut]
        public ActionResult<Post> Put([FromBody] Post post)
        {
            return Ok(_postRepository.Update(post));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return _postRepository.Delete(id) ? Ok() : StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpGet("{id:guid}/comments")]
        public ActionResult<IEnumerable<Comment>> GetComments([FromRoute] Guid id)
        {
            return Ok(_commentRepository.GetByPostId(id));
        }
    }
}