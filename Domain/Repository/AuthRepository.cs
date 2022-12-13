using Domain.Service;
using Infrastructure.Entity;
using Infrastructure.Entity.Response;
using Infrastructure.Interface;
using System.Net;


namespace Domain.Repository
{
    public class AuthRepository : IAuth
    {

        private readonly HttpClientFactory _client;

        private readonly string client_id = Environment.GetEnvironmentVariable("APP_CLIENT_ID")!;
        private readonly string client_secret = Environment.GetEnvironmentVariable("APP_CLIENT_SECRET")!;
        private readonly string redirectUrl = Environment.GetEnvironmentVariable("LINKEDIN_REDIRECT_URL")!;

        public AuthRepository( HttpClientFactory _clientFactory)
        {
            _client = _clientFactory;
        }

        public CustomResponse FormatUrlTo_RequestAuthorization()
        {
            
            string scope = "r_liteprofile%20r_emailaddress%20w_member_social";

            string baseUrl = Environment.GetEnvironmentVariable("LINKEDIN_REQUEST_AUTHORIZATION")!;
            var url = $"{baseUrl}?response_type=code&client_id={client_id}&redirect_uri={redirectUrl}&scope={scope}";

            return new CustomResponse(HttpStatusCode.OK, url);
        }

        public async Task<CustomResponse> GetAccessToken( string authorizationCode )
        {
            string baseUrl = Environment.GetEnvironmentVariable("LINKEDIN_GET_ACCESS_TOKEN")!;
           
            var url = $"{baseUrl}?code={authorizationCode}&grant_type=authorization_code&client_id={client_id}&client_secret={client_secret}&redirect_uri={redirectUrl}";
            HttpRequestMessage request = _client.CreateRequest<dynamic>(HttpMethod.Post, url);
            AccessToken response = await _client.CallApi<AccessToken>(request);

            TokenManagerService.SetToken(response);
            _client.SetTokenAuthentication();

            var person = await this.GetPersonId();
            return person;
        }

        public async Task<CustomResponse> GetPersonId()
        {
            try
            {
                _client.SetTokenAuthentication();
                var url = $"{Environment.GetEnvironmentVariable("LINKEDIN_BASE_URL")}/me";
                HttpRequestMessage request = _client.CreateRequest<PersonResponse>(HttpMethod.Get, url);
                PersonResponse response = await _client.CallApi<PersonResponse>(request);
                
                var accessTokenResponse = new PersonResponse(
                    response.Id,
                    response.LocalizedFirstName,
                    response.LocalizedLastName
                );

                return CustomResponseService.Mapping(
                    HttpStatusCode.OK,
                    accessTokenResponse
                );
            }
            catch ( Exception err )
            {

                return CustomResponseService.Mapping(
                    HttpStatusCode.InternalServerError,
                    err.Message
                );
            }
        }
    }
}
