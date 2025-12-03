using Ecommerce.Web.Models;
using Ecommerce.Web.Models.Dto;
using Ecommerce.Web.Service.IService;

namespace Ecommerce.Web.Service{

    public interface IOrderService {
        Task<ResponseDto?> CreateOrder(CartDto cartDto);
        Task<ResponseDto?> CreateStripeSession(StripeRequestDto stripeRequestDto);
        Task<ResponseDto?> ValidateStripeSession(int orderHeaderId);

    }
}