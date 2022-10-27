


namespace CPTool.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {

            var section = config.GetSection("EmailSettings");
            services.Configure<EMailSettings>(c => config.GetSection("EmailSettings"));


            var defaultconnection = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<TableContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging(true));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));


            services.AddTransient<IEmailService, EmailService>();



            return services;
        }

    }
}
