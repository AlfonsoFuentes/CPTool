using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.ApplicationRadzen.FeaturesGeneric;
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
            services.AddTransient(typeof(ICommandQuery<EditBrandSupplier>),typeof( CommandQueryBrandSupplier));
  
            return services;
        }
    }
}
