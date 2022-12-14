using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace sample_ui_pipeline_v1.Infrastructure
{
    public class ActionLoggerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            System.Net.IPAddress ipAddress = context.HttpContext.Connection.RemoteIpAddress;
            string controllerName = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            string actionName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;

            if (context.Exception == null)
            {
                Log
                    .ForContext("IPAddress", ipAddress)
                    .ForContext("ControllerName", controllerName)
                    .ForContext("ActionName", actionName)
                    .Information($"IP Address: {ipAddress} - Controller Name: {controllerName} - Action Name: {actionName}");
            }
            else
            {
                Log
                    .ForContext("IPAddress", ipAddress)
                    .ForContext("ControllerName", controllerName)
                    .ForContext("ActionName", actionName)
                    .ForContext("ErrorMessage", context.Exception.Message)
                    .Error($"IP Address: {ipAddress} - Controller Name: {controllerName} - Action Name: {actionName}");
            }

            base.OnActionExecuted(context);
        }
    }
}
