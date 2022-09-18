using CPTool.Context;
using CPTool.Interfaces;
using CPTool.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using CPTool.DTOS;
using CPTool.Entities;

namespace CPTool.DependencyInjection
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddCPToolServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");


            services.AddDbContextFactory<TableContext>(
                options => options
               
             .UseSqlServer(
                 configuration.GetConnectionString(
                     "DefaultConnection")));

            var asse = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));


            services.AddTransient(typeof(IDTOManager<,>), typeof(DTOManager<,>));
           
            return services;
        }
    }
}