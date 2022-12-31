namespace CPTool.ApplicationCQRSResponses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public List<string> ValidationErrors { get; set; } = new();
    }
}
