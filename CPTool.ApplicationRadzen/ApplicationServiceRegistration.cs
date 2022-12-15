using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Generic;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationRadzen
{
    public static class ApplicationRadzenServiceRegistration
    {
        public static IServiceCollection AddApplicationRadzenServices(
            this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(ICommandQuery<>), typeof(CommandQuery<>));
    
  
            return services;
        }
    }
}
