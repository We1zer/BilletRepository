using Billet_Utility;
using Billet_Web.Models;
using Billet_Web.Models.Dto;
using Billet_Web.Services.IServices;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Billet_Web.Services
{
    public class BilletUserService : BaseService, IBilletUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string billetUrl;
        public BilletUserService(IHttpClientFactory clientFactory, IConfiguration configuration): base(clientFactory)
        {
            _clientFactory = clientFactory;
            billetUrl = configuration.GetValue<string>("ServiceUrls:BilletAPI");
        }
        public Task<T> CreateAsync<T>(BilletUserDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = billetUrl + "/api/BilletUserAPI",
                Token = token

            }); 
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = billetUrl + "/api/BilletUserAPI/" + id,
                Token = token

            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = billetUrl + "/api/BilletUserAPI",
                Token = token

            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = billetUrl + "/api/BilletUserAPI/" + id,
                Token = token

            });
        }

        public Task<T> UpdateAsync<T>(BilletUserDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = billetUrl + "/api/BilletUserAPI/" + dto.BilletNo,
                Token = token

            });
        }
    }
}
