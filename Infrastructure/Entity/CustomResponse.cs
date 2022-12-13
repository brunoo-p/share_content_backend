using Infrastructure.Interface;
using System.Net;

namespace Infrastructure.Entity
{
    public class CustomResponse
    {
        public HttpStatusCode StatusCode { get; private set; }
        public dynamic Response { get; private set; }

        public CustomResponse( HttpStatusCode statusCode, dynamic response )
        {
            StatusCode = statusCode;
            Response = response;
        }
    }
}
