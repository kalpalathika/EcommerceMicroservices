using Ecommerce.Services.EmailAPI.Models.Dto;

namespace Ecommerce.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
        Task RegisterUserEmailAndLog(string email);
        // Task LogOrderPlaced(RewardsMessage rewardsDto);
    }
}