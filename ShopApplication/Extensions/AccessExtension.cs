using Microsoft.AspNetCore.Mvc;

namespace ShopApplication.Extensions
{
    public static class AccessExtension
    {
        public static bool HasAccess(this ControllerBase cb, string name)
        {
            return cb.User.IsInRole("Admin") || cb.User.Identity!.Name == name;
        }
    }
}
