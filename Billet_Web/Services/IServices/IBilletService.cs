using Billet_Web.Models.Dto;

namespace Billet_Web.Services.IServices
{
    public interface IBilletService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(BilletDTO dto, string token);
        Task<T> UpdateAsync<T>(BilletDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);

    }
}
