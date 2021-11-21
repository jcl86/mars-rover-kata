using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MarsRover.Api
{
    public static class ProblemDetailsExtensions
    {
        public static IServiceCollection AddProblemDetails(this IServiceCollection services, IWebHostEnvironment environment,
          IConfiguration configuration)
        {
            return services.AddProblemDetails(configure =>
            {
                configure.IncludeExceptionDetails = (context, exception) => environment.IsDevelopment();
                configure.Map<ArgumentException>(exception =>
                {
                    return new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status400BadRequest,
                        Type = nameof(ArgumentException)
                    };
                });
                configure.Map<NotFoundException>(exception =>
                {
                    return new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status404NotFound,
                        Type = nameof(NotFoundException)
                    };
                });

                configure.Map<Exception>(exception =>
                {
                    Serilog.Log.Logger.Error(exception.Message);
                    return new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status500InternalServerError,
                        Type = nameof(Exception)
                    };
                });
            });
        }
    }
}
