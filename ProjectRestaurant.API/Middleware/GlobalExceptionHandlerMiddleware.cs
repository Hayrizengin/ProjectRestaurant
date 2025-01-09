using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ProjectRestaurant.Tools.Const;
using ProjectRestaurant.Tools.Response;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectRestaurant.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(FluentValidation.ValidationException))
                {
                    var validationException = ex as FluentValidation.ValidationException;

                    var validationErrors = validationException?.Errors.Select(q => q.ErrorMessage);

                    ErrorResult errorResult = new ErrorResult(validationErrors?.ToList());

                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(
                        ApiResponse<bool>.FailureResult(errorResult, HttpStatusCode.BadRequest),
                        new JsonSerializerOptions() { PropertyNamingPolicy = null }
                    );
                }
                else if (ex.GetType() == typeof(AppBaseException))
                {
                    List<string> errors = new() { ex.Message };
                    ErrorResult errorResult = new ErrorResult(errors);

                    httpContext.Response.StatusCode = (int)AppContextManager.ResponseStatusCode;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(
                        ApiResponse<bool>.FailureResult(errorResult, HttpStatusCode.NotFound),
                        new JsonSerializerOptions() { PropertyNamingPolicy = null }
                    );
                }
                else
                {
                    List<string> errors = new List<string>() { ex.Message };
                    ErrorResult errorResult = new ErrorResult(errors);

                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(
                        ApiResponse<bool>.FailureResult(errorResult, HttpStatusCode.InternalServerError));
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
