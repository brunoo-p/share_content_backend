using Infrastructure.Entity;
using Infrastructure.Entity.Response;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuth _repository;
        public AuthController(IAuth repository)
        {
            _repository = repository;
        }

        [SwaggerOperation(Summary = "Authentication", Description = "Return url to do authorize likedin access and code to get access token")]
        [ProducesResponseType(typeof(String), 200)]
        [HttpGet]
        [Route("authorization")]
        public async Task<CustomResponse> RequestAuthorization()
        {
            CustomResponse message = _repository.FormatUrlTo_RequestAuthorization();
            return message;
        }
        
        [SwaggerOperation(Summary = "Access Token", Description = "Get access token and return authenticated person")]
        [ProducesResponseType(typeof(PersonResponse), 200)]
        [HttpPost]
        [Route("accesstoken")]
        public async Task<CustomResponse> GetAccessToken( string authorizationCode )
        {
            var message = await _repository.GetAccessToken(authorizationCode);
            return message;
        }

        [SwaggerOperation(Summary = "Get Person", Description = "Get person authenticated")]
        [ProducesResponseType(typeof(PersonResponse), 200)]
        [HttpGet]
        [Route("person")]
        public async Task<CustomResponse> GetPerson()
        {
            CustomResponse message = await _repository.GetPersonId();
            return message;
        }
        
    }
}
