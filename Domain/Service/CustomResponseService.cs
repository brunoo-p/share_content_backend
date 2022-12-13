using Infrastructure.Entity;
using System.Net;
namespace Domain.Service
{
    public class CustomResponseService
    {
        public static CustomResponse Mapping(HttpStatusCode status, dynamic response)
        {
            return new CustomResponse(
                status,
                response
            );
        }
    }
}
