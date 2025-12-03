using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;

namespace Ecommerce.Web.Service.IService{
    public interface IBaseService {
        Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true);
    }

}