﻿


namespace CPTool.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {

            var section = config.GetSection("EmailSettings");
            services.Configure<EMailSettings>(c => config.GetSection("EmailSettings"));



            services.AddDbContext<TableContext>(options =>

            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
          

            services.AddTransient<IEmailService, EmailService>();



            return services;
        }

    }
}