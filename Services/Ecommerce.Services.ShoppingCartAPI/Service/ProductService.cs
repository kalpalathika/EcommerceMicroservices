using System.Text.Json;
using Ecommerce.Services.ShoppingCartAPI.Models.Dto;
using Ecommerce.Services.ShoppingCartAPI.Service.IService;

namespace Ecommerce.Services.ShoppingCartAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Product");
                var response = await client.GetAsync($"/api/product");
                var apiContet = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(apiContet))
                {
                    return new List<ProductDto>();
                }

                var resp = JsonSerializer.Deserialize<ResponseDto>(apiContet, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (resp != null && resp.IsSuccess)
                {
                    var jsonResult = JsonSerializer.Serialize(resp.Result);
                    return JsonSerializer.Deserialize<IEnumerable<ProductDto>>(jsonResult, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                return new List<ProductDto>();
            }
            catch (Exception)
            {
                return new List<ProductDto>();
            }
        }
    }
}