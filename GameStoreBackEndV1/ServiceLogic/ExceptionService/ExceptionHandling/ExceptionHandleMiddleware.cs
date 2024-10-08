﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameStoreBackEndV1.ServiceLogic.ExceptionService.ExceptionHandling
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandleMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (ExternalResourceNotFoundException ex)
            {
                httpContext.Response.StatusCode = ex.StatusCode;
                await httpContext.Response.WriteAsJsonAsync(httpContext.Response.StatusCode + " : " + ex.Message);
            }
            catch (Exception ex)
            {
                await httpContext.Response.WriteAsJsonAsync(httpContext.Response.StatusCode + " : " + ex.Message);
            }
        }
    }
}
