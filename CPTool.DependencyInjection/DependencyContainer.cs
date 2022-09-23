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
                .EnableSensitiveDataLogging()

             .UseSqlServer(
                 configuration.GetConnectionString(
                     "DefaultConnection")));

            var asse = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));


            services.AddScoped(typeof(IDTOManager<,>), typeof(DTOManager<,>));
            //services.AddTransient(typeof(ICreationMethod<,>), typeof(CreationMethod<,>));

            return services;
        }
    }
}