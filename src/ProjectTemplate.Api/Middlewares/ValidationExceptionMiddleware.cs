using FluentValidation;
using ProjectTemplate.Api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ProjectTemplate.Api.Middlewares
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _request;

        public ValidationExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (FluentValidation.ValidationException exception)
            {
                var errors = exception.Errors.Select(err => new Error
                {
                    PropertyName = err.PropertyName,
                    ErrorMessage = err.ErrorMessage
                });

                var errorModel = new ValidationErrorModel()
                {
                    Errors = errors
                };

                var errorText = JsonSerializer.Serialize(errorModel);
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorText);
            }
            catch (Exception exception)
            {
                var error = new
                {
                    StatusCode = 400,
                    ErrorMessage = exception.Message,
                    ExceptionDetails = exception.InnerException
                };

                var errorText = JsonSerializer.Serialize(error);
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorText);
            }
        }
    }
}
