using CPTool.Application.Exceptions;
using CPTool.Errors;

using System.Net;
using System.Text.Json;

namespace CPTool.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                var statuscode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment() ? new CodeErrorException(statuscode, ex.Message,ex.StackTrace!):new CodeErrorException(statuscode);
                var options=new JsonSerializerOptions { PropertyNamingPolicy= JsonNamingPolicy.CamelCase };
                var json =JsonSerializer.Serialize(response, options);  

                await context.Response.WriteAsync(json);
                //var result = string.Empty;
                //switch (ex)
                //{
                //    case NotFoundException:
                //        statuscode = (int)HttpStatusCode.NotFound;
                //        break;
                //    case ValidationException validationexception:
                //        statuscode = (int)HttpStatusCode.BadRequest;
                //        var validation = JsonConvert.SerializeObject(validationexception.Errors);
                //        result = JsonConvert.SerializeObject(new CodeErrorException(statuscode, ex.Message, validation));
                //        break;
                //    case BadRequestException badrequestexception:
                //        statuscode = (int)HttpStatusCode.BadRequest;
                //        break;
                //    default:
                //        break;
                //}
                //if (string.IsNullOrEmpty(result))
                //{
                //    result = JsonConvert.SerializeObject(new CodeErrorException
                //        (statuscode, ex.Message, ex.StackTrace!.ToString()));

                //}
                //context.Response.StatusCode = statuscode;

                //await context.Response.WriteAsync(result);

            }
        }
    }
}
