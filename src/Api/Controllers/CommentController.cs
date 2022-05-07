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
    [Route("comments")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository, ILogger<CommentController> logger)
        {
            _commentRepository = commentRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetAll()
        {
            return Ok(_commentRepository.GetAll());
        }


        [HttpGet("{id:guid}")]
        public ActionResult<Comment> Get([FromRoute] Guid id)
        {
            return Ok(_commentRepository.Get(id));

        }

        [HttpPost]
        public ActionResult<Comment> Post([FromBody] Comment comment)
        {
            return Ok(_commentRepository.Create(comment));
        }


        [HttpPut]
        public ActionResult<Comment> Put([FromBody] Comment comment)
        {
            return Ok(_commentRepository.Update(comment));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return _commentRepository.Delete(id) ? Ok() : StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}