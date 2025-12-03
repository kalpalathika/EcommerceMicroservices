using Ecommerce.Web.AuthAPI.Models.Dto;
using Ecommerce.Web.Models;
using Ecommerce.Web.Models.Dto;

namespace Ecommerce.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}