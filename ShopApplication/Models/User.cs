using Microsoft.AspNetCore.Identity;

namespace ShopApplication.Models
{
    public class User:IdentityUser
    {
        public List<Product>? Products { get; set; }
    }
}
