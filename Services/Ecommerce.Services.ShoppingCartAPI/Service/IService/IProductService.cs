using Ecommerce.Services.ShoppingCartAPI.Models.Dto;

namespace Ecommerce.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}