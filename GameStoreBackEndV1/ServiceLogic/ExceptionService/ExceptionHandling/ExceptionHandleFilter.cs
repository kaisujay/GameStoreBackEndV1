using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Net;

namespace GameStoreBackEndV1.ServiceLogic.ExceptionService.ExceptionHandling
{
    public class ExceptionHandleFilter : ExceptionFilterAttribute // or "IExceptionFilter"
    {
        public override void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var requestPath = context.HttpContext.Request.Path;

            //context.HttpContext.Response.StatusCode
            Log.Error("Got Error : ExternalResourceNotFoundException");

            var message = $"\nTime: {DateTime.Now}, Controller: {controllerName}, Action: {actionName}, Exception: {context.Exception.Message}";

            context.Result = new ObjectResult(message)
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
            };
        }
    }
}
