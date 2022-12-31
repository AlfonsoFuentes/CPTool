using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CPTool.ApplicationCQRSCQRS
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
