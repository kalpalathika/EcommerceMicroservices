using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}