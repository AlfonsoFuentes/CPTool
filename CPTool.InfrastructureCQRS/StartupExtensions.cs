using CPTool.ApplicationCQRSCQRS;
using CPTool.Domain.Entities;
using CPTool.InfrastructureCQRS;
using CPTool.InfrastructureCQRS.Services;
using CPTool.PersistenceCQRS;
using CPToolCQRS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CPTool.InfrastructureCQRS
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection Services, IConfiguration config)
        {


            Services.AddApplicationServices();
            Services.AddInfrastructureServices(config);
            Services.AddPersistenceServices(config);
            Services.AddScoped<IMWOTypeService, MWOTypeService>();
            Services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();
            Services.AddScoped<IGasketService, GasketService>();
            Services.AddScoped<IMaterialsService, MaterialsService>();
            Services.AddScoped<IConnectionTypeService, ConnectionTypeService>();
            Services.AddScoped<IProcessFluidsService, ProcessFluidsService>();
            Services.AddScoped<IPipeDimensionService, PipeDimensionService>();
            Services.AddScoped<IBrandSupplierService, BrandSupplierService>();
            Services.AddScoped<IUnitaryBasePrizeService, UnitaryBasePrizeService>();
            Services.AddScoped<ITaxCodeLDService, TaxCodeLDService>();
            Services.AddScoped<ITaxCodeLPService, TaxCodeLPService>();
            Services.AddScoped<IMWOService, MWOService>();
            Services.AddScoped<IMWOItemService, MWOItemService>();
            Services.AddScoped<INozzleService, NozzleService>();
            Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            Services.AddScoped<IDownPaymentsService, DownPaymentsService>();
            Services.AddScoped<ITaksService, TaksService>();
            Services.AddScoped<IUserRequirementService, UserRequirementService>();
            Services.AddScoped<ISignalService, SignalService>();
            Services.AddScoped<IControlLoopService, ControlLoopService>();
            Services.AddScoped<ISignalTypeService, SignalTypeService>();
            Services.AddScoped<IWireService, WireService>();
            Services.AddScoped<IFieldLocationService, FieldLocationService>();
            Services.AddScoped<IElectricalBoxService, ElectricalBoxService>();
            Services.AddScoped<IUserRequirementTypeService, UserRequirementTypeService>();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IMWOItemPrevisousValuesService, MWOItemPrevisousValuesService>();


            return Services;


        }



      
       
    }
}
