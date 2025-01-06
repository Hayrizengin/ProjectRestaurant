using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ErrorResult Error { get; set; }


        [JsonIgnore] public HttpStatusCode StatusCode { get; set; }

        public ApiResponse(bool success, string message, T data, HttpStatusCode statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        public ApiResponse(bool success, string message, T data, ErrorResult error)
        {
            Success = success;
            Message = message;
            Data = data;
            Error = error;
        }

        // Başarılı bir sonuç için fabrika metodu
        public static ApiResponse<T> SuccessResult(T data, string message = "İşlem Başarılı",
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResponse<T>(true, message, data, statusCode);
        }

        // Hatalı bir sonuç için fabrika metodu
        public static ApiResponse<T> FailureResult(ErrorResult error, string message = "İşlem Başarısız", HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ApiResponse<T>(false, message, default, error);
        }
        public static ApiResponse<T> FailureResult(ErrorResult error, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ApiResponse<T>(false, "İşlem Başarısız", default, error);
        }

        // Uyarı veya özel mesaj gerektiren durumlar için fabrika metodu
        public static ApiResponse<T> WarningResult(string message, T data = default,
            HttpStatusCode statusCode = HttpStatusCode.Accepted)
        {
            return new ApiResponse<T>(true, message, data, statusCode);
        }
    }
}
