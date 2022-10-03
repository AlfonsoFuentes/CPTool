namespace CPTool.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
