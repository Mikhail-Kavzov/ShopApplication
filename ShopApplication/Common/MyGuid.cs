using System.Text;

namespace ShopApplication.Common
{
    public static class MyGuid
    {
        public static string GetGuid()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
        }
    }
}
