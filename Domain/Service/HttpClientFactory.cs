using Infrastructure.Entity;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;

namespace Domain.Service
{
    public class HttpClientFactory
    {
        private readonly HttpClient _client = new();

        public HttpRequestMessage CreateRequest<T>( HttpMethod method, string url, [Optional] T data )
        {
            try
            {
                var uri = new Uri(url);
                var request = new HttpRequestMessage(method, uri);
                
                if ( data != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                }

                return request;
            }
            catch ( Exception )
            {
                throw;
            }
        }
        
        public async Task<T> CallApi<T>(HttpRequestMessage request)
        {
            try
            {
                var response = await _client.SendAsync(request);
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
            }
            catch ( Exception )
            {
                throw;
            }
        }

        public void SetTokenAuthentication()
        {
            try
            {
                var token = TokenManagerService.GetToken();
                if(token.Length > 0)
                {
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }catch
            {
                throw;
            }
        }

    }
}
