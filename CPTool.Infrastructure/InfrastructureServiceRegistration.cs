using CPTool.Application.Services;
using CPTool.Infrastructure.Services.ExcelService;

namespace CPTool.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {

         


            var defaultconnection = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<TableContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging(true));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IExcelService, ExcelService>();


            return services;
        }

    }
}
