using Application.Core.Utilities.Middleware.API;
using Application.Core.Utilities.Middleware.MVC;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAPIExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<APIExceptionMiddleware>();
        }

        public static IApplicationBuilder UseMVCExceptionMiddleware(this IApplicationBuilder app, string errorPageUrl)
        {
            return app.UseMiddleware<MVCExceptionMiddleware>(errorPageUrl);
        }
    }
}
