using CPTool.ApplicationCQRS.Contracts.Infrastructure;

using CPTool.ApplicationCQRS.Models.Mail;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CPTool.InfrastructureCQRS
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("EmailSettings");
            services.Configure<EmailSettings>(section);

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IExcelService, ExcelService>();
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IPDFService, PDFService>();
        
            return services;
        }
    }
}
