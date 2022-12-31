using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using CPTool.Domain;
using CPTool.Domain.Entities;
using CPTool.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CPTool.UnitsSystem;


namespace CPTool.Infrastructure.Persistence
{
    public class TableContext : DbContext
    {

        public TableContext(DbContextOptions<TableContext> options)
            : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MWOType>().HasMany(c => c.MWOs).WithOne(t => t.MWOType).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasMany(c => c.MWOItems).WithOne(t => t.MWO).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasMany(c => c.UserRequirements).WithOne(t => t.MWO).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasMany(c => c.Signals).WithOne(t => t.MWO).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasMany(c => c.ControlLoops).WithOne(t => t.MWO).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<MWO>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<MWO>().Navigation(e => e.UserRequirements).AutoInclude();
            //modelBuilder.Entity<MWO>().Navigation(e => e.Signals).AutoInclude();
            //modelBuilder.Entity<MWO>().Navigation(e => e.ControlLoops).AutoInclude();

            modelBuilder.Entity<Chapter>().HasMany(c => c.MWOItems).WithOne(t => t.Chapter).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.UnitaryBasePrize).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MWOItem>().HasMany(c => c.PurchaseOrderItems).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasMany(c => c.Signals).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasMany(c => c.Taks).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MWOItem>().HasOne(c => c.AlterationItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.FoundationItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.StructuralItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.EquipmentItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.ElectricalItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.PipingItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.InstrumentItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.InsulationItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.PaintingItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.TaxesItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.EHSItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.TestingItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.EngineeringCostItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.ContingencyItem).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<MWOItem>().Navigation(e => e.Signals).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.Taks).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.PurchaseOrderItems).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.Chapter).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.AlterationItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.FoundationItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.StructuralItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.EquipmentItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.ElectricalItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.PipingItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.InstrumentItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.InsulationItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.PaintingItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.TaxesItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.EHSItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.TestingItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.EngineeringCostItem).AutoInclude();
            //modelBuilder.Entity<MWOItem>().Navigation(e => e.ContingencyItem).AutoInclude();

            modelBuilder.Entity<EquipmentType>().HasMany(c => c.EquipmentTypeSubs).WithOne(t => t.EquipmentType).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<EquipmentType>().Navigation(e => e.EquipmentTypeSubs).AutoInclude();

            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eEquipmentType).WithMany(t => t.EquipmentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eEquipmentTypeSub).WithMany(t => t.EquipmentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eProcessCondition).WithMany(t => t.EquipmentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eBrand).WithMany(t => t.EquipmentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eSupplier).WithMany(t => t.EquipmentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasMany(c => c.Nozzles).WithOne(t => t.EquipmentItem).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eProcessFluid).WithMany(t => t.EquipmentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eInnerMaterial).WithMany(t => t.EquipmentItemInnerMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eOuterMaterial).WithMany(t => t.EquipmentItemOuterMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eGasket).WithMany(t => t.EquipmentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().Navigation(e => e.eEquipmentType).AutoInclude();
            modelBuilder.Entity<EquipmentItem>().Navigation(e => e.eEquipmentTypeSub).AutoInclude();
            //modelBuilder.Entity<EquipmentItem>().Navigation(e => e.eProcessCondition).AutoInclude();
            //modelBuilder.Entity<EquipmentItem>().Navigation(e => e.eBrand).AutoInclude();
            ////modelBuilder.Entity<EquipmentItem>().Navigation(e => e.Nozzles).AutoInclude();
            //modelBuilder.Entity<EquipmentItem>().Navigation(e => e.eProcessFluid).AutoInclude();
            //modelBuilder.Entity<EquipmentItem>().Navigation(e => e.eInnerMaterial).AutoInclude();
            //modelBuilder.Entity<EquipmentItem>().Navigation(e => e.eOuterMaterial).AutoInclude();
            //modelBuilder.Entity<EquipmentItem>().Navigation(e => e.eGasket).AutoInclude();

            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iProcessFluid).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iInnerMaterial).WithMany(t => t.InstrumentItemInnerMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iOuterMaterial).WithMany(t => t.InstrumentItemOuterMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iProcessCondition).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iGasket).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iBrand).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iSupplier).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.DeviceFunction).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.DeviceFunctionModifier).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.Readout).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.MeasuredVariable).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.MeasuredVariableModifier).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasMany(c => c.Nozzles).WithOne(t => t.InstrumentItem).OnDelete(DeleteBehavior.Cascade);
   
            //modelBuilder.Entity<InstrumentItem>().Navigation(e => e.iProcessFluid).AutoInclude();
            //modelBuilder.Entity<InstrumentItem>().Navigation(e => e.iInnerMaterial).AutoInclude();
            //modelBuilder.Entity<InstrumentItem>().Navigation(e => e.iOuterMaterial).AutoInclude();
            //modelBuilder.Entity<InstrumentItem>().Navigation(e => e.iProcessCondition).AutoInclude();
            //modelBuilder.Entity<InstrumentItem>().Navigation(e => e.iGasket).AutoInclude();
            //modelBuilder.Entity<InstrumentItem>().Navigation(e => e.iBrand).AutoInclude();
            //modelBuilder.Entity<InstrumentItem>().Navigation(e => e.iSupplier).AutoInclude();
            modelBuilder.Entity<InstrumentItem>().Navigation(e => e.DeviceFunction).AutoInclude();
            modelBuilder.Entity<InstrumentItem>().Navigation(e => e.DeviceFunctionModifier).AutoInclude();
            modelBuilder.Entity<InstrumentItem>().Navigation(e => e.Readout).AutoInclude();
            modelBuilder.Entity<InstrumentItem>().Navigation(e => e.MeasuredVariable).AutoInclude();
            modelBuilder.Entity<InstrumentItem>().Navigation(e => e.MeasuredVariableModifier).AutoInclude();
            //modelBuilder.Entity<InstrumentItem>().Navigation(e => e.Nozzles).AutoInclude();

            modelBuilder.Entity<PipingItem>().HasOne(c => c.pProcessFluid).WithMany(t => t.PipingItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.NozzleStart).WithMany(t => t.StartPipingItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.NozzleFinish).WithMany(t => t.FinishPipingItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.pMaterial).WithMany(t => t.PipingItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.pDiameter).WithMany(t => t.PipingItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.StartMWOItem).WithMany(t => t.StartPipingItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.FinishMWOItem).WithMany(t => t.FisnishPipingItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipingItem>().HasMany(c => c.Nozzles).WithOne(t => t.PipingItem).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PipingItem>().HasMany(c => c.PipeAccesorys).WithOne(t => t.pPipingItem).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.pProcessCondition).WithMany(t => t.PipingItems).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<PipingItem>().Navigation(e => e.pProcessFluid).AutoInclude();
            ////modelBuilder.Entity<PipingItem>().Navigation(e => e.NozzleStart).AutoInclude();
            ////modelBuilder.Entity<PipingItem>().Navigation(e => e.NozzleFinish).AutoInclude();
            //modelBuilder.Entity<PipingItem>().Navigation(e => e.pMaterial).AutoInclude();
            //modelBuilder.Entity<PipingItem>().Navigation(e => e.pDiameter).AutoInclude();
            ////modelBuilder.Entity<PipingItem>().Navigation(e => e.StartMWOItem).AutoInclude();
            ////modelBuilder.Entity<PipingItem>().Navigation(e => e.FinishMWOItem).AutoInclude();
            ////modelBuilder.Entity<PipingItem>().Navigation(e => e.Nozzles).AutoInclude();
            //modelBuilder.Entity<PipingItem>().Navigation(e => e.PipeAccesorys).AutoInclude();
            //modelBuilder.Entity<PipingItem>().Navigation(e => e.pProcessCondition).AutoInclude();
 


            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.OuterDiameter).WithMany(t => t.ODs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.InternalDiameter).WithMany(t => t.IDs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.Thickness).WithMany(t => t.Thicknesss).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<PipeDiameter>().Navigation(e => e.OuterDiameter).AutoInclude();
            //modelBuilder.Entity<PipeDiameter>().Navigation(e => e.InternalDiameter).AutoInclude();
            //modelBuilder.Entity<PipeDiameter>().Navigation(e => e.Thickness).AutoInclude();

            modelBuilder.Entity<PurchaseOrder>().HasOne(c => c.pBrand).WithMany(t => t.PurchaseOrders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PurchaseOrder>().HasOne(c => c.pSupplier).WithMany(t => t.PurchaseOrders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PurchaseOrder>().HasMany(c => c.PurchaseOrderItems).WithOne(t => t.PurchaseOrder).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<PurchaseOrder>().Navigation(e => e.pBrand).AutoInclude();
            //modelBuilder.Entity<PurchaseOrder>().Navigation(e => e.pSupplier).AutoInclude();
            //modelBuilder.Entity<PurchaseOrder>().Navigation(e => e.PurchaseOrderItems).AutoInclude();

            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.Pressure).WithMany(t => t.Pressures).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.Temperature).WithMany(t => t.Temperatures).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.MassFlow).WithMany(t => t.MassFlows).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.VolumetricFlow).WithMany(t => t.VolumetricFlows).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.Density).WithMany(t => t.Densitys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.Viscosity).WithMany(t => t.Viscositys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.EnthalpyFlow).WithMany(t => t.EnthalpyFlows).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.SpecificEnthalpy).WithMany(t => t.SpecificEnthalpys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.ThermalConductivity).WithMany(t => t.ThermalConductivitys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.SpecificCp).WithMany(t => t.SpecificCps).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.Pressure).AutoInclude();
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.Temperature).AutoInclude();
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.MassFlow).AutoInclude();
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.VolumetricFlow).AutoInclude();
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.Density).AutoInclude();
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.Viscosity).AutoInclude();
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.EnthalpyFlow).AutoInclude();
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.SpecificEnthalpy).AutoInclude();
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.ThermalConductivity).AutoInclude();
            //modelBuilder.Entity<ProcessCondition>().Navigation(e => e.SpecificCp).AutoInclude();



            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.Friction).WithMany(t => t.FrictionPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.Reynold).WithMany(t => t.ReynoldPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.LevelInlet).WithMany(t => t.LevelInletPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.LevelOutlet).WithMany(t => t.LevelOutletPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.FrictionDropPressure).WithMany(t => t.FrictionDropPressurePipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.OverallDropPressure).WithMany(t => t.OverallDropPressurePipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.ElevationChange).WithMany(t => t.ElevationChangePipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.pProcessCondition).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.paProcessFluid).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasMany(c => c.Nozzles).WithOne(t => t.PipeAccesory).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.paDiameter).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.paPipeClass).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.paMaterial).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.Friction).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.Reynold).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.LevelInlet).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.LevelOutlet).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.FrictionDropPressure).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.ElevationChange).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.pProcessCondition).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.paProcessFluid).AutoInclude();
            ////modelBuilder.Entity<PipeAccesory>().Navigation(e => e.Nozzles).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.paDiameter).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.paPipeClass).AutoInclude();
            //modelBuilder.Entity<PipeAccesory>().Navigation(e => e.paMaterial).AutoInclude();

            modelBuilder.Entity<Supplier>().HasOne(c => c.TaxCodeLD).WithMany(t => t.Suppliers).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Supplier>().HasOne(c => c.TaxCodeLP).WithMany(t => t.Suppliers).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Supplier>().Navigation(e => e.TaxCodeLD).AutoInclude();
            modelBuilder.Entity<Supplier>().Navigation(e => e.TaxCodeLP).AutoInclude();

            modelBuilder.Entity<Nozzle>().HasOne(c => c.ConnectionType).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.nGasket).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.nMaterial).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.PipeDiameter).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.nPipeClass).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.ConnectedTo).WithMany(t => t.NozzlesConnecteds).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Nozzle>().Navigation(e => e.ConnectedTo).AutoInclude();
            //modelBuilder.Entity<Nozzle>().Navigation(e => e.ConnectionType).AutoInclude();
            //modelBuilder.Entity<Nozzle>().Navigation(e => e.nGasket).AutoInclude();
            //modelBuilder.Entity<Nozzle>().Navigation(e => e.nMaterial).AutoInclude();
            //modelBuilder.Entity<Nozzle>().Navigation(e => e.PipeDiameter).AutoInclude();
            //modelBuilder.Entity<Nozzle>().Navigation(e => e.ConnectedTo).AutoInclude();


            modelBuilder.Entity<ProcessFluid>().HasOne(c => c.PropertyPackage).WithMany(t => t.ProcessFluids).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessFluid>().Navigation(e => e.PropertyPackage).AutoInclude();

            modelBuilder.Entity<DownPayment>().HasOne(c => c.PurchaseOrder).WithMany(t => t.DownPayments).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DownPayment>().Navigation(e => e.PurchaseOrder).AutoInclude();

            modelBuilder.Entity<Taks>().HasOne(c => c.MWO).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Taks>().HasOne(c => c.MWOItem).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Taks>().HasOne(c => c.PurchaseOrder).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Taks>().HasOne(c => c.DownPayment).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            ////modelBuilder.Entity<Taks>().Navigation(e => e.MWO).AutoInclude();
            //modelBuilder.Entity<Taks>().Navigation(e => e.MWOItem).AutoInclude();
            //modelBuilder.Entity<Taks>().Navigation(e => e.PurchaseOrder).AutoInclude();
            //modelBuilder.Entity<Taks>().Navigation(e => e.DownPayment).AutoInclude();


            modelBuilder.Entity<UserRequirement>().HasOne(c => c.UserRequirementType).WithMany(t => t.UserRequirements).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRequirement>().HasOne(c => c.RequestedBy).WithMany(t => t.UserRequirements).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<UserRequirement>().Navigation(e => e.UserRequirementType).AutoInclude();
            //modelBuilder.Entity<UserRequirement>().Navigation(e => e.RequestedBy).AutoInclude();

            modelBuilder.Entity<BrandSupplier>()
             .HasKey(t => new { t.BrandId, t.SupplierId });

            modelBuilder.Entity<BrandSupplier>()
                .HasOne(pt => pt.Brand)
                .WithMany(p => p.BrandSuppliers)
                .HasForeignKey(pt => pt.BrandId);

            modelBuilder.Entity<BrandSupplier>()
                .HasOne(pt => pt.Supplier)
                .WithMany(t => t.BrandSuppliers)
                .HasForeignKey(pt => pt.SupplierId);

            //modelBuilder.Entity<BrandSupplier>().Navigation(e => e.Brand).AutoInclude();
            //modelBuilder.Entity<BrandSupplier>().Navigation(e => e.Supplier).AutoInclude();

            //modelBuilder.Entity<Brand>().Navigation(e => e.BrandSuppliers).AutoInclude();
            //modelBuilder.Entity<Supplier>().Navigation(e => e.BrandSuppliers).AutoInclude();
            //modelBuilder.Entity<Supplier>().Navigation(e => e.TaxCodeLD).AutoInclude();
            //modelBuilder.Entity<Supplier>().Navigation(e => e.TaxCodeLP).AutoInclude();

            modelBuilder.Entity<Signal>().HasOne(c => c.SignalType).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Signal>().HasOne(c => c.Wire).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Signal>().HasOne(c => c.FieldLocation).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Signal>().HasOne(c => c.ElectricalBox).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Signal>().HasOne(c => c.SignalModifier).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Signal>().Navigation(e => e.SignalType).AutoInclude();
            //modelBuilder.Entity<Signal>().Navigation(e => e.Wire).AutoInclude();
            //modelBuilder.Entity<Signal>().Navigation(e => e.FieldLocation).AutoInclude();
            //modelBuilder.Entity<Signal>().Navigation(e => e.ElectricalBox).AutoInclude();
            //modelBuilder.Entity<Signal>().Navigation(e => e.SignalModifier).AutoInclude();

            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ControlledVariable).WithMany(t => t.ControlledVariables).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ProcessVariable).WithMany(t => t.ProcessVariables).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ControlLoop>().HasOne(c => c.SP).WithMany(t => t.SPs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ProcessVariableMin).WithMany(t => t.ProcessVariableMins).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ProcessVariableMax).WithMany(t => t.ProcessVariableMaxs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ProcessVariableValue).WithMany(t => t.ProcessVariableValues).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ControlledVariable).WithMany(t => t.ControlledVariables).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<ControlLoop>().Navigation(e => e.SP).AutoInclude();
            //modelBuilder.Entity<ControlLoop>().Navigation(e => e.ProcessVariableMax).AutoInclude();
            //modelBuilder.Entity<ControlLoop>().Navigation(e => e.ProcessVariableValue).AutoInclude();
            //modelBuilder.Entity<ControlLoop>().Navigation(e => e.ControlledVariable).AutoInclude();
           


        }




        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<MWOType>? MWOTypes { get; set; }
        public DbSet<MWO>? MWOs { get; set; }
        public DbSet<MWOItem>? MWOItems { get; set; }
        public DbSet<PurchaseOrderItem>? PurchaseOrderItems { get; set; }
        public DbSet<PurchaseOrder>? PurchaseOrders { get; set; }

        public DbSet<AlterationItem>? AlterationItems { get; set; }
        public DbSet<FoundationItem>? FoundationItems { get; set; }
        public DbSet<StructuralItem>? StructuralItems { get; set; }
        public DbSet<EquipmentItem>? EquipmentItems { get; set; }
        public DbSet<ElectricalItem>? ElectricalItems { get; set; }
        public DbSet<PipingItem>? PipingItems { get; set; }
        public DbSet<InstrumentItem>? InstrumentItems { get; set; }
        public DbSet<InsulationItem>? InsulationItems { get; set; }
        public DbSet<PaintingItem>? PaintingItems { get; set; }
        public DbSet<EHSItem>? EHSItems { get; set; }
        public DbSet<TaxesItem>? TaxesItems { get; set; }
        public DbSet<TestingItem>? TestingItems { get; set; }
        public DbSet<EngineeringCostItem>? EngineeringCostItems { get; set; }
        public DbSet<ContingencyItem>? ContingencyItems { get; set; }
        public DbSet<UnitaryBasePrize>? UnitaryBasePrizes { get; set; }
        public DbSet<Gasket>? Gaskets { get; set; }
        public DbSet<EquipmentType>? EquipmentTypes { get; set; }
        public DbSet<EquipmentTypeSub>? EquipmentTypeSubs { get; set; }

        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<BrandSupplier>? BrandSuppliers { get; set; }
        public DbSet<Material>? Materials { get; set; }
        public DbSet<TaxCodeLD>? TaxCodeLDs { get; set; }

        public DbSet<TaxCodeLP>? TaxCodeLPs { get; set; }

        public DbSet<DownPayment>? DownPayments { get; set; }

        public DbSet<MeasuredVariable>? MeasuredVariables { get; set; }
        public DbSet<MeasuredVariableModifier>? MeasuredVariableModifiers { get; set; }
        public DbSet<DeviceFunction>? DeviceFunctions { get; set; }
        public DbSet<DeviceFunctionModifier>? DeviceFunctionModifiers { get; set; }
        public DbSet<Readout>? Readouts { get; set; }
        public DbSet<CPTool.Domain.Entities.EntityUnit>? Units { get; set; }
        public DbSet<ProcessFluid>? ProcessFluids { get; set; }
        public DbSet<PipeDiameter>? PipeDiameters { get; set; }
        public DbSet<Nozzle>? Nozzles { get; set; }
        public DbSet<PipeAccesory>? PipeAccesorys { get; set; }
        public DbSet<PipeClass>? PipeClasss { get; set; }
        public DbSet<ConnectionType>? ConnectionTypes { get; set; }
        public DbSet<ProcessCondition>? ProcessConditions { get; set; }
        public DbSet<PropertyPackage>? PropertyPackages { get; set; }
        public DbSet<Taks>? Takss { get; set; }
        public DbSet<UserRequirementType>? UserRequirementTypes { get; set; }
        public DbSet<UserRequirement>? UserRequirements { get; set; }
        public DbSet<User>? Users { get; set; }

        public DbSet<SignalType>? SignalTypes { get; set; }
        public DbSet<Wire>? Wires { get; set; }
        public DbSet<FieldLocation>? FieldLocations { get; set; }
        public DbSet<ElectricalBox>? ElectricalBoxs { get; set; }
        public DbSet<Signal>? Signals { get; set; }
        public DbSet<SignalModifier>? SignalModifiers { get; set; }
        public DbSet<ControlLoop>? ControlLoops { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var entittes = ChangeTracker.Entries<AuditableEntity>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            foreach (var entry in entittes)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "system";
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.UpdateDate = DateTime.UtcNow;
                        entry.Entity.UpdateBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateBy = "system";
                        entry.Entity.UpdateDate = DateTime.UtcNow;
                        break;
                }
            }
            var retorno = await base.SaveChangesAsync(cancellationToken);

            return retorno;
        }
    }
}
