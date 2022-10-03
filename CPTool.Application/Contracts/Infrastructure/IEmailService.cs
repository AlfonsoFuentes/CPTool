


namespace CPTool.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EMail mail);
    }
}
