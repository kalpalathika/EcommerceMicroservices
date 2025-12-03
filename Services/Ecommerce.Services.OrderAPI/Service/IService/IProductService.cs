using Ecommerce.Services.OrderAPI.Models.Dto;

namespace Ecommerce.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}