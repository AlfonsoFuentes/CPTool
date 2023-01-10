
using CPTool.ApplicationCQRSCQRS;
using CPTool.Domain.Entities;
using CPTool.InfrastructureCQRS;
using CPTool.PersistenceCQRS;
using CPTool.UIApp.Services;
using CPToolCQRS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            Services.AddScoped<IMWOItemPrevisousValuesService, MWOItemPrevisousValuesService>();
            

            return Services;


        }



        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<TableContext>();
                if (context != null)
                {
                    //await UpdateEquipmentItem(context);
                    //await UpdatePiping(context);
                    //await UpdateInstrument(context);
                    //context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
            await Task.CompletedTask;
        }
        //static async Task UpdateEquipmentItem(TableContext context)
        //{
        //    var MWOitemList = await context.MWOItems.Where(x => x.ChapterId == 4).ToListAsync();
        //    foreach (var row in MWOitemList)
        //    {
        //        var rowitem = await context.EquipmentItems.FindAsync(row.EquipmentItemId);
        //        row.EquipmentTypeId = rowitem.eEquipmentTypeId;
        //        row.EquipmentTypeSubId = rowitem.eEquipmentTypeSubId;
        //        row.ProcessConditionId = rowitem.eProcessConditionId;
        //        row.ProcessFluidId = rowitem.eProcessFluidId;
        //        row.InnerMaterialId = rowitem.eInnerMaterialId;
        //        row.OuterMaterialId = rowitem.eOuterMaterialId;
        //        row.BrandId = rowitem.eBrandId;
        //        row.SupplierId = rowitem.eSupplierId;
        //        row.TagId = rowitem.TagId;
        //        row.TagLetter = rowitem.TagLetter;
        //        row.TagNumber = rowitem.TagNumber;
        //        row.Model = rowitem.Model;
        //        row.Reference = rowitem.Reference;
        //        row.SerialNumber = rowitem.SerialNumber;

        //        var nozzles = await context.Nozzles.Where(x => x.EquipmentItemId == rowitem.Id).ToListAsync();
        //        foreach (var nozz in nozzles)
        //        {
        //            nozz.MWOItemId = row.Id;
        //            context.Update(nozz);
        //        }
        //        context.MWOItems.Update(row);
        //    }
        //}
        //static async Task UpdateInstrument(TableContext context)
        //{
        //    var ItemList = await context.MWOItems.Where(x => x.ChapterId == 7).ToListAsync();
        //    foreach (var row in ItemList)
        //    {
        //        var rowitem = await context.InstrumentItems.FindAsync(row.InstrumentItemId);
        //        row.ProcessConditionId = rowitem.iProcessConditionId;
        //        row.ProcessFluidId = rowitem.iProcessFluidId;
        //        row.InnerMaterialId = rowitem.iInnerMaterialId;
        //        row.OuterMaterialId = rowitem.iOuterMaterialId;
        //        row.BrandId = rowitem.iBrandId;
        //        row.SupplierId = rowitem.iSupplierId;

        //        row.DeviceFunctionId = rowitem.DeviceFunctionId;
        //        row.DeviceFunctionModifierId = rowitem.DeviceFunctionModifierId;
        //        row.MeasuredVariableId = rowitem.MeasuredVariableId;
        //        row.MeasuredVariableModifierId = rowitem.MeasuredVariableModifierId;
        //        row.ReadoutId = rowitem.ReadoutId;
        //        row.TagId = rowitem.TagId;
        //        row.TagLetter = rowitem.TagLetter;
        //        row.TagNumber = rowitem.TagNumber;
        //        row.Model = rowitem.Model;
        //        row.Reference = rowitem.Reference;
        //        row.SerialNumber = rowitem.SerialNumber;

        //        var nozzles = await context.Nozzles.Where(x => x.InstrumentItemId == rowitem.Id).ToListAsync();
        //        foreach (var nozz in nozzles)
        //        {
        //            nozz.MWOItemId = row.Id;
        //            context.Update(nozz);
        //        }
        //        context.MWOItems.Update(row);
        //    }
        //}
        //static async Task UpdatePiping(TableContext context)
        //{
        //    var MWOitemList = await context.MWOItems.Where(x => x.ChapterId == 6).ToListAsync();
        //    foreach (var row in MWOitemList)
        //    {
        //        var rowitem = await context.PipingItems.FindAsync(row.PipingItemId);
        //        row.ProcessConditionId = rowitem.pProcessFluidId;
        //        row.ProcessFluidId = rowitem.pProcessFluidId;
        //        row.TagId = rowitem.TagId;

        //        row.TagNumber = rowitem.TagNumber;
        //        row.StartMWOItemId = rowitem.StartMWOItemId;
        //        row.FinishMWOItemId = rowitem.FinishMWOItemId;
        //        row.NozzleFinishId = rowitem.NozzleFinishId;
        //        row.NozzleStartId = rowitem.NozzleStartId;
        //        row.InnerMaterialId = rowitem.pMaterialId;
        //        row.DiameterId = rowitem.pDiameterId;
        //        row.PipeClassId= rowitem.pPipeClassId;
        //        row.Insulation = rowitem.Insulation;
        //        row.TagNumber = rowitem.TagNumber;

        //        var nozzles = await context.Nozzles.Where(x => x.PipingItemId == rowitem.Id).ToListAsync();
        //        foreach (var nozz in nozzles)
        //        {
        //            nozz.MWOItemId = row.Id;
        //            context.Update(nozz);
        //        }
        //        context.MWOItems.Update(row);
        //    }
        //}
    }
}
