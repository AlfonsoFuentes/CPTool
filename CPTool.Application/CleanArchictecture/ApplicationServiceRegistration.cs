


using CPTool.ApplicationCA.Base.Interactors;
using CPTool.ApplicationCA.Base.Ports;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CPTool.ApplicationCA
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationCAServices(
        this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           
            services.AddTransient(typeof(IAddEditPort<,,>), typeof(AddEditBase<,,>));
            services.AddTransient(typeof(IDeletePort<,>), typeof(DeleteBase<,>));
            services.AddTransient(typeof(IListPort<,>), typeof(GetListBase<,>));
            services.AddTransient(typeof(IGetByIdPort<,>), typeof(GetByIdBase<,>));

            return services;
        }
    }
}
