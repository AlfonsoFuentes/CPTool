


using CPTool.Application.Generic;

namespace CPTool.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services )
        {
         
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           
            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddTransient(typeof(ICommandQuery<>), typeof(CommandQuery<>));

            return services;
        }
        
    }
}
