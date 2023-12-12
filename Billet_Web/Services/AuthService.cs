using Billet_Utility;
using Billet_Web.Models;
using Billet_Web.Models.Dto;
using Billet_Web.Services.IServices;

namespace Billet_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string billetUrl;
        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            billetUrl = configuration.GetValue<string>("ServiceUrls:BilletAPI");
        }

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {

            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = billetUrl + "/api/UsersAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = billetUrl + "/api/UsersAuth/register"
            });
        }
    }
}
