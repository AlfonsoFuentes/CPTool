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
           

            modelBuilder.Entity<Chapter>().HasMany(c => c.MWOItems).WithOne(t => t.Chapter).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.UnitaryBasePrize).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MWOItem>().HasMany(c => c.MWOItemCurrencyValues).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity<EquipmentType>().HasMany(c => c.EquipmentTypeSubs).WithOne(t => t.EquipmentType).OnDelete(DeleteBehavior.Cascade);

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
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iProcessCondition).WithMany(t => t.InstrumentItems).OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.OuterDiameter).WithMany(t => t.ODs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.InternalDiameter).WithMany(t => t.IDs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.Thickness).WithMany(t => t.Thicknesss).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PurchaseOrder>().HasOne(c => c.pBrand).WithMany(t => t.PurchaseOrders).OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.Entity<Supplier>().HasOne(c => c.TaxCodeLD).WithMany(t => t.Suppliers).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Supplier>().HasOne(c => c.TaxCodeLP).WithMany(t => t.Suppliers).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Supplier>().HasOne(c => c.VendorCode).WithMany(t => t.Suppliers).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Nozzle>().HasOne(c => c.ConnectionType).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.nGasket).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.nMaterial).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.PipeDiameter).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.nPipeClass).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.ConnectedTo).WithMany(t => t.NozzlesConnecteds).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().Navigation(e => e.ConnectedTo).AutoInclude();

            modelBuilder.Entity<ProcessFluid>().HasOne(c => c.PropertyPackage).WithMany(t => t.ProcessFluids).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DownPayment>().HasOne(c => c.PurchaseOrder).WithMany(t => t.DownPayments).OnDelete(DeleteBehavior.NoAction);
           
            
            modelBuilder.Entity<Taks>().HasOne(c => c.MWO).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Taks>().HasOne(c => c.MWOItem).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Taks>().HasOne(c => c.PurchaseOrder).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Taks>().HasOne(c => c.DownPayment).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);


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

            modelBuilder.Entity<PurchaseOrderMWOItem>()
           .HasKey(t => new { t.PurchaseOrderId, t.MWOItemId });

            modelBuilder.Entity<PurchaseOrderMWOItem>()
                .HasOne(pt => pt.PurchaseOrder)
                .WithMany(p => p.PurchaseOrderMWOItems)
                .HasForeignKey(pt => pt.PurchaseOrderId);

            modelBuilder.Entity<PurchaseOrderMWOItem>()
                .HasOne(pt => pt.MWOItem)
                .WithMany(t => t.PurchaseOrderMWOItems)
                .HasForeignKey(pt => pt.MWOItemId);

            //Relation Many to Many Purchase Order  MWOItem

            modelBuilder.Entity<PurchaseOrder>().HasOne(c => c.pSupplier).WithMany(t => t.PurchaseOrders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PurchaseOrder>().HasOne(c => c.pBrand).WithMany(t => t.PurchaseOrders).OnDelete(DeleteBehavior.NoAction);




        }




        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<MWOType>? MWOTypes { get; set; }
        public DbSet<MWO>? MWOs { get; set; }
        public DbSet<MWOItem>? MWOItems { get; set; }
        public DbSet<MWOItemCurrencyValue>? MWOItemCurrencyValues { get; set; }
        public DbSet<PurchaseOrder>? PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderMWOItem>? PurchaseOrderMWOItems { get; set; }
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
        public DbSet<VendorCode>? VendorCodes { get; set; }
        public DbSet<TaxCodeLP>? TaxCodeLPs { get; set; }

        public DbSet<DownPayment>? DownPayments { get; set; }

        public DbSet<MeasuredVariable>? MeasuredVariables { get; set; }
        public DbSet<MeasuredVariableModifier>? MeasuredVariableModifiers { get; set; }
        public DbSet<DeviceFunction>? DeviceFunctions { get; set; }
        public DbSet<DeviceFunctionModifier>? DeviceFunctionModifiers { get; set; }
        public DbSet<Readout>? Readouts { get; set; }
        public DbSet<CPTool.Domain.Entities.Unit>? Units { get; set; }
        public DbSet<ProcessFluid>? ProcessFluids { get; set; }
        public DbSet<PipeDiameter>? PipeDiameters { get; set; }
        public DbSet<Nozzle>? Nozzles { get; set; }
        public DbSet<PipeAccesory>? PipeAccesorys { get; set; }
        public DbSet<PipeClass>? PipeClasss { get; set; }
        public DbSet<ConnectionType>? ConnectionTypes { get; set; }
        public DbSet<ProcessCondition>? ProcessConditions { get; set; }
        public DbSet<PropertyPackage>? PropertyPackages { get; set; }
        public DbSet<Taks>? Takss { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var entittes = ChangeTracker.Entries<BaseDomainModel>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
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
