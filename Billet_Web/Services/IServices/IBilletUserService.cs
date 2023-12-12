using Billet_Web.Models.Dto;

namespace Billet_Web.Services.IServices
{
    public interface IBilletUserService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(BilletUserDTO dto, string token);
        Task<T> UpdateAsync<T>(BilletUserDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);

    }
}
