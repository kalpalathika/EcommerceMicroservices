using Ecommerce.Web.Models;
using Ecommerce.Web.Models.Dto;
using Ecommerce.Web.Service;
using Ecommerce.Web.Service.IService;
using Ecommerce.Web.Utility;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ecommerce.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }

        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }
        [HttpPost]
        [ActionName("Checkout")]
        public async Task<IActionResult> Checkout(CartDto cartDto)
        {

            CartDto cart = await LoadCartDtoBasedOnLoggedInUser();
            cart.CartHeader.Phone = cartDto.CartHeader.Phone;
            cart.CartHeader.Email = cartDto.CartHeader.Email;
            cart.CartHeader.Name = cartDto.CartHeader.Name;

            var response = await _orderService.CreateOrder(cart);

            if (response != null && response.IsSuccess)
            {
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                OrderHeaderDto orderHeaderDto = JsonSerializer.Deserialize<OrderHeaderDto>(JsonSerializer.Serialize(response.Result), jsonOptions);

                // get stripe session and redirect to stripe to place order

                var domain = Request.Scheme + "://" + Request.Host.Value + "/";

                StripeRequestDto stripeRequestDto = new()
                {
                    ApprovedUrl = domain + "cart/Confirmation?orderId=" + orderHeaderDto.OrderHeaderId,
                    CancelUrl = domain + "cart/checkout",
                    OrderHeader = orderHeaderDto
                };

                var stripeResponse = await _orderService.CreateStripeSession(stripeRequestDto);

                if (stripeResponse != null && stripeResponse.IsSuccess)
                {
                    StripeRequestDto stripeResponseResult = JsonSerializer.Deserialize<StripeRequestDto>
                                                (JsonSerializer.Serialize(stripeResponse.Result), jsonOptions);

                    if (stripeResponseResult?.StripeSessionUrl != null)
                    {
                        Response.Headers.Add("Location", stripeResponseResult.StripeSessionUrl);
                        return new StatusCodeResult(303);
                    }
                    else
                    {
                        TempData["error"] = "Failed to get Stripe checkout URL";
                    }
                }
                else
                {
                    TempData["error"] = stripeResponse?.Message ?? "Error creating Stripe session";
                }

            }
            else
            {
                TempData["error"] = response?.Message ?? "Error creating order";
            }
            return View();
        }

        public async Task<IActionResult> Confirmation(int orderId)
        {
            ResponseDto? response = await _orderService.ValidateStripeSession(orderId);
            if (response != null & response.IsSuccess)
            {
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                OrderHeaderDto orderHeader =JsonSerializer.Deserialize<OrderHeaderDto>
                                                (JsonSerializer.Serialize(response.Result), jsonOptions);
                if (orderHeader.Status == SD.Status_Approved)
                {
                    return View(orderId);
                }
            }
            //redirect to some error page based on status
            return View(orderId);
        }

        public async Task<IActionResult> Remove(int cartDetailsId)
        {
            var userId = User.Claims.Where(u => u.Type == JwtClaimTypes.Subject)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _cartService.RemoveFromCartAsync(cartDetailsId);
            if (response != null & response.IsSuccess)
            {
                TempData["success"] = "Cart updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(CartDto cartDto)
        {
            
            ResponseDto? response = await _cartService.ApplyCouponAsync(cartDto);
            if (response != null & response.IsSuccess)
            {
                TempData["success"] = "Cart updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailCart(CartDto cartDto)
        {
            CartDto cart = await LoadCartDtoBasedOnLoggedInUser();
            cart.CartHeader.Email = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Email)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _cartService.EmailCart(cart);
            if (response != null & response.IsSuccess)
            {
                TempData["success"] = "Email will be processed and sent shortly.";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RemoveCoupon(CartDto cartDto)
        {
            cartDto.CartHeader.CouponCode = "";
            ResponseDto? response = await _cartService.ApplyCouponAsync(cartDto);
            if (response != null & response.IsSuccess)
            {
                TempData["success"] = "Cart updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }


        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == JwtClaimTypes.Subject)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _cartService.GetCartByUserIdAsnyc(userId);
            if(response!=null & response.IsSuccess)
            {
                var jsonString = JsonSerializer.Serialize(response.Result);

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                CartDto cartDto = JsonSerializer.Deserialize<CartDto>(jsonString, options) ?? new();
                return cartDto;
            }
            return new CartDto();
        }
    }
}