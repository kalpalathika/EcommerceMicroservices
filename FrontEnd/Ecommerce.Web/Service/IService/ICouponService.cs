using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;

namespace Ecommerce.Web.Service{

    public interface ICouponService {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponsAsync(CouponDto coupon);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto coupon);
        Task<ResponseDto?> DeleteCouponsAsync(int id);

    }
}