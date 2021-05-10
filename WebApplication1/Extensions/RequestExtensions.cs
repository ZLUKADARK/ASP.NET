using Microsoft.AspNetCore.Http;
namespace WebApplication1.Extensions
{
    public static class RequestExtrensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request

            .Headers["x-requested-with"]
            .Equals("XMLHttpRequest");
        }
    }
}