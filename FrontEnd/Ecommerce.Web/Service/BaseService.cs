using System;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;
using static Ecommerce.Web.Utility.SD;

namespace Ecommerce.Web.Service {
    public class BaseService : IBaseService {

        private readonly IHttpClientFactory _httpClientfactory;
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider){
            _httpClientfactory = httpClientFactory;
             _tokenProvider = tokenProvider;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true){

            try{

                HttpClient client = _httpClientfactory.CreateClient("EcommerceAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                message.RequestUri = new Uri(requestDto.Url);

                if(requestDto.Data != null){
                    message.Content = new StringContent(JsonSerializer.Serialize(requestDto.Data), System.Text.Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch(requestDto.ApiType){
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);

                switch(apiResponse.StatusCode){
                    case HttpStatusCode.NotFound:
                            return new() {IsSuccess = false, Message= " Not found"};
                    case HttpStatusCode.Unauthorized:
                            return new() {IsSuccess = false, Message= "Unauthorized"};
                    case HttpStatusCode.Forbidden:
                            return new() {IsSuccess = false, Message= "Access Denied"};
                    case HttpStatusCode.InternalServerError:
                            return new() {IsSuccess = false, Message= "Internal Server Error"};
                    default:
                            var apiContent = await apiResponse.Content.ReadAsStringAsync();
                            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                            var apiResponseDto = JsonSerializer.Deserialize<ResponseDto>(apiContent, options);
                            return apiResponseDto;
                }
            }catch(Exception ex){
                var dto = new ResponseDto{
                    IsSuccess = false,
                    Message = ex.Message
                };
                return dto;   
            }


        }
    }
}