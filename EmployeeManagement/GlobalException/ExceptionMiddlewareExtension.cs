using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace EmployeeManagement.GlobalException
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var example = context.Features.Get<IExceptionHandlerFeature>();
                        if (example != null)
                        {
                            await context.Response.WriteAsync(example.Error.Message);
                        }
                    });
                });
            }
        }
    }
}
