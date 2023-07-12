using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace ProjectTemplate.Api.Extensions
{
    public static class ExceptionHandling
    {
        public static void AddExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature?.Error;

                    if (!(exception is ValidationException validationException))
                    {
                        throw exception!;
                    }

                    var errors = validationException.Errors.Select(err => new Error
                    {
                        PropertyName =  err.PropertyName,
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
                });
            });
        }
    }

    public class ValidationErrorModel
    {
        public IEnumerable<Error>? Errors { get; set; }
        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
        public String Type { get; set; } = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
    }

    public class Error
    {
        public String PropertyName { get; set; } = string.Empty;
        public String ErrorMessage { get; set; } = string.Empty;
    }
}
