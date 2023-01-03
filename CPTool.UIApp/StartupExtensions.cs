
using CPTool.ApplicationCQRSCQRS;
using CPTool.InfrastructureCQRS;
using CPTool.PersistenceCQRS;
using CPTool.UIApp.Services;

namespace CPTool.UIApp
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
            
            return Services;


        }



        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                //var context = scope.ServiceProvider.GetService<TableContext>();
                //if (context != null)
                //{
                //    await context.Database.EnsureDeletedAsync();
                //    await context.Database.MigrateAsync();
                //}
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
            await Task.CompletedTask;
        }
    }
}
