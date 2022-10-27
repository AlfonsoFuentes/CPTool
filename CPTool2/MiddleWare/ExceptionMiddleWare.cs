using CPTool.Application.Exceptions;
using CPTool2.Errors;
using Newtonsoft.Json;
using System.Net;

namespace CPTool2.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;

        public ExceptionMiddleWare(RequestDelegate next,
            ILogger<ExceptionMiddleWare> logger)
        {
            _next = next;
            _logger = logger;

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
                var result = string.Empty;
                switch (ex)
                {
                    case NotFoundException:
                        statuscode = (int)HttpStatusCode.NotFound;
                        break;
                    case ValidationException validationexception:
                        statuscode = (int)HttpStatusCode.BadRequest;
                        var validation = JsonConvert.SerializeObject(validationexception.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statuscode, ex.Message, validation));
                        break;
                    case BadRequestException badrequestexception:
                        statuscode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        break;
                }
                if (string.IsNullOrEmpty(result))
                {
                    result = JsonConvert.SerializeObject(new CodeErrorException
                        (statuscode, ex.Message, ex.StackTrace!.ToString()));

                }
                context.Response.StatusCode = statuscode;

                await context.Response.WriteAsync(result);

            }
        }
    }
}
