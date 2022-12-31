using CPTool.ApplicationCQRS.Models.Mail;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
