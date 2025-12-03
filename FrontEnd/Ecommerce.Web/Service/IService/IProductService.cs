using Ecommerce.Web.Models;
using Ecommerce.Web.Models.Dto;
using Ecommerce.Web.Service.IService;

namespace Ecommerce.Web.Service{

    public interface IProductService {
        Task<ResponseDto?> GetProductAsync(string productCode);
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductsAsync(ProductDto Product);
        Task<ResponseDto?> UpdateProductsAsync(ProductDto Product);
        Task<ResponseDto?> DeleteProductsAsync(int id);

    }
}