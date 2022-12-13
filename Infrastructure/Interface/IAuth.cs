

using Infrastructure.Entity;
using Infrastructure.Entity.Response;

namespace Infrastructure.Interface
{
    public interface IAuth
    {
        CustomResponse FormatUrlTo_RequestAuthorization();
        Task<CustomResponse> GetAccessToken( string authorizationCode );
        Task<CustomResponse> GetPersonId();
    }
}
