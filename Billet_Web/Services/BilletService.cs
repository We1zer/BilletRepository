using Billet_Utility;
using Billet_Web.Models;
using Billet_Web.Models.Dto;
using Billet_Web.Services.IServices;
using Microsoft.Extensions.Configuration;

namespace Billet_Web.Services
{
    public class BilletService : BaseService, IBilletService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string billetUrl;
        public BilletService(IHttpClientFactory clientFactory, IConfiguration configuration): base(clientFactory)
        {
            _clientFactory = clientFactory;
            billetUrl = configuration.GetValue<string>("ServiceUrls:BilletAPI");
        }
        public Task<T> CreateAsync<T>(BilletDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = billetUrl + "/api/BilletAPI",
                Token = token

            }); 
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = billetUrl + "/api/BilletAPI/"+id,
                Token = token

            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = billetUrl + "/api/BilletAPI",
                Token = token

            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = billetUrl + "/api/BilletAPI/"+id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(BilletDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = billetUrl + "/api/BilletAPI/"+dto.Id,
                Token = token
            });
        }
    }
}
