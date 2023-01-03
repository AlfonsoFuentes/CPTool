

using CPTool.ApplicationCQRS.Contracts.Persistence;

using CPToolCQRS.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.PersistenceCQRS
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultconnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextFactory<TableContext>(
                options =>options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging(false)
                .EnableDetailedErrors(),
                ServiceLifetime.Scoped);

            //services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddScoped<IRepositoryChapter, RepositoryChapter>();
            services.AddScoped<IRepositoryMWOType, RepositoryMWOType>(); 
            services.AddScoped<IRepositoryMWO, RepositoryMWO>();
            services.AddScoped<IRepositoryMWOItem, RepositoryMWOItem>();
            services.AddScoped<IRepositoryMWOItemWithEquipment, RepositoryMWOItemWithEquipment>();
            services.AddScoped<IRepositoryMWOItemWithInstrument, RepositoryMWOItemWithInstrument>();
            services.AddScoped<IRepositoryMWOItemWithPiping, RepositoryMWOItemWithPiping>();
            services.AddScoped<IRepositoryMWOItemWithNozzles, RepositoryMWOItemWithNozzles>();
            services.AddScoped<IRepositoryPurchaseOrderItem, RepositoryPurchaseOrderItem>();
            services.AddScoped<IRepositoryPurchaseOrder, RepositoryPurchaseOrder>();
            services.AddScoped<IRepositoryAlterationItem, RepositoryAlterationItem>();
            services.AddScoped<IRepositoryFoundationItem, RepositoryFoundationItem>();
            services.AddScoped<IRepositoryStructuralItem, RepositoryStructuralItem>();
            services.AddScoped<IRepositoryEquipmentItem, RepositoryEquipmentItem>();
          
            services.AddScoped<IRepositoryElectricalItem, RepositoryElectricalItem>();
            services.AddScoped<IRepositoryPipingItem, RepositoryPipingItem>();
            services.AddScoped<IRepositoryInstrumentItem, RepositoryInstrumentItem>();
           
            services.AddScoped<IRepositoryInsulationItem, RepositoryInsulationItem>();
            services.AddScoped<IRepositoryPaintingItem, RepositoryPaintingItem>();
            services.AddScoped<IRepositoryEHSItem, RepositoryEHSItem>();
            services.AddScoped<IRepositoryTaxesItem, RepositoryTaxesItem>();
            services.AddScoped<IRepositoryTestingItem, RepositoryTestingItem>();
            services.AddScoped<IRepositoryEngineeringCostItem, RepositoryEngineeringCostItem>();
            services.AddScoped<IRepositoryContingencyItem, RepositoryContingencyItem>();
            services.AddScoped<IRepositoryUnitaryBasePrize, RepositoryUnitaryBasePrize>();
            services.AddScoped<IRepositoryGasket, RepositoryGasket>();
            services.AddScoped<IRepositoryEquipmentType, RepositoryEquipmentType>();
            services.AddScoped<IRepositoryEquipmentTypeSub, RepositoryEquipmentTypeSub>();
            services.AddScoped<IRepositoryBrand, RepositoryBrand>();
            services.AddScoped<IRepositorySupplier, RepositorySupplier>();
            services.AddScoped<IRepositoryBrandSupplier, RepositoryBrandSupplier>();
            services.AddScoped<IRepositoryMaterial, RepositoryMaterial>();
            services.AddScoped<IRepositoryTaxCodeLD, RepositoryTaxCodeLD>();
            services.AddScoped<IRepositoryTaxCodeLP, RepositoryTaxCodeLP>();
            services.AddScoped<IRepositoryDownPayment, RepositoryDownPayment>();
            services.AddScoped<IRepositoryMeasuredVariable, RepositoryMeasuredVariable>();
            services.AddScoped<IRepositoryMeasuredVariableModifier, RepositoryMeasuredVariableModifier>();
            services.AddScoped<IRepositoryDeviceFunction, RepositoryDeviceFunction>();
            services.AddScoped<IRepositoryDeviceFunctionModifier, RepositoryDeviceFunctionModifier>();
            services.AddScoped<IRepositoryReadout, RepositoryReadout>();
            services.AddScoped<IRepositoryEntityUnit, RepositoryEntityUnit>();
            services.AddScoped<IRepositoryProcessFluid, RepositoryProcessFluid>();
            services.AddScoped<IRepositoryPipeDiameter, RepositoryPipeDiameter>();
            services.AddScoped<IRepositoryNozzle, RepositoryNozzle>();
            services.AddScoped<IRepositoryPipeAccesory, RepositoryPipeAccesory>();
            services.AddScoped<IRepositoryPipeClass, RepositoryPipeClass>();
            services.AddScoped<IRepositoryConnectionType, RepositoryConnectionType>();
            services.AddScoped<IRepositoryProcessCondition, RepositoryProcessCondition>();
            services.AddScoped<IRepositoryPropertyPackage, RepositoryPropertyPackage>();
            services.AddScoped<IRepositoryTaks, RepositoryTaks>();
            services.AddScoped<IRepositoryUserRequirementType, RepositoryUserRequirementType>();
            services.AddScoped<IRepositoryUserRequirement, RepositoryUserRequirement>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            services.AddScoped<IRepositorySignalType, RepositorySignalType>();
            services.AddScoped<IRepositoryWire, RepositoryWire>();
            services.AddScoped<IRepositoryFieldLocation, RepositoryFieldLocation>();
            services.AddScoped<IRepositoryElectricalBox, RepositoryElectricalBox>();
            services.AddScoped<IRepositorySignal, RepositorySignal>();
            services.AddScoped<IRepositorySignalModifier, RepositorySignalModifier>();
            services.AddScoped<IRepositoryControlLoop, RepositoryControlLoop>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));



            return services;
        }
    }
}