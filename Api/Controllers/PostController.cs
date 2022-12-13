using Infrastructure.Entity;
using Infrastructure.Entity.Post;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/post")]
    public class PostController : ControllerBase
    {

        private readonly IPost _repository;
        public PostController(IPost repository)
        {
            _repository = repository;
        }

        [SwaggerOperation(Summary = "Post on linkedin", Description = "Send post to linkedin account")]
        [ProducesResponseType(typeof(PostIdentify), 201)]
        [HttpPost]
        [Route("linkedin")]
        public async Task<CustomResponse> ShareOnLinked( string id, [FromForm] PostAttributes postAttributes )
        {
            var message = await _repository.PostOnLinkedin(id, postAttributes);
            return message;
        }
    }
}