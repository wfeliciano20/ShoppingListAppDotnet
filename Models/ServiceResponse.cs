using System.Net;

namespace ShoppingListApp.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string? Message { get; set; } = string.Empty;
        public HttpStatusCode? ResponseCode { get; set; } = HttpStatusCode.OK;
    }
}