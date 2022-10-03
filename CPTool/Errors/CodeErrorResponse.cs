namespace CPTool.Errors
{
    public class CodeErrorResponse
    {


        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public CodeErrorResponse(int statusCode, string message = null!)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(StatusCode);
        }
        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Errors",
                401 => "Not Authorized",
                404 => "Resource not found",
                500 => "Server Errors",
                _ => string.Empty,
            };
        }
    }
}
