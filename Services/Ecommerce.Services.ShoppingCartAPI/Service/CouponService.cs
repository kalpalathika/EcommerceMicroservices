using System.Text.Json;
using Ecommerce.Services.ShoppingCartAPI.Models.Dto;
using Ecommerce.Services.ShoppingCartAPI.Service.IService;

namespace Ecommerce.Services.ShoppingCartAPI.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Coupon");
                var response = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");
                var apiContet = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(apiContet))
                {
                    return new CouponDto();
                }

                var resp = JsonSerializer.Deserialize<ResponseDto>(apiContet, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (resp != null && resp.IsSuccess)
                {
                    var jsonResult = JsonSerializer.Serialize(resp.Result);
                    return JsonSerializer.Deserialize<CouponDto>(jsonResult, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }

                return new CouponDto();
            }
            catch (Exception)
            {
                return new CouponDto();
            }
        }
    }
}