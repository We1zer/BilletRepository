using Billet_Web.Models.Dto;

namespace Billet_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
        Task<T> RegisterAsync<T>(RegistrationRequestDTO objToCreate);

    }
}
