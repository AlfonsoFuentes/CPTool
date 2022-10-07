using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using CPTool.Domain;
using CPTool.Domain.Entities;
using CPTool.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eInnerMaterial).WithMany(t => t.EquipmentItemInnerMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.eOuterMaterial).WithMany(t => t.EquipmentItemOuterMaterials).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iInnerMaterial).WithMany(t => t.InstrumentItemInnerMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InstrumentItem>().HasOne(c => c.iOuterMaterial).WithMany(t => t.InstrumentItemOuterMaterials).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PipingItem>().HasOne(c => c.NozzleStart).WithMany(t => t.StartPipingItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.NozzleFinish).WithMany(t => t.FinishPipingItems).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.OD).WithMany(t => t.ODs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.ID).WithMany(t => t.IDs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.Thickness).WithMany(t => t.Thicknesss).OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.Entity<PipingItem>().HasOne(c => c.StartMWOItem).WithMany(t => t.StartPipingItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.FinishMWOItem).WithMany(t => t.FisnishPipingItems).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.Friction).WithMany(t => t.FrictionPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.Reynold).WithMany(t => t.ReynoldPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.LevelInlet).WithMany(t => t.LevelInletPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.LevelOutlet).WithMany(t => t.LevelOutletPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.FrictionDropPressure).WithMany(t => t.FrictionDropPressurePipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.OverallDropPressure).WithMany(t => t.OverallDropPressurePipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.ElevationChange).WithMany(t => t.ElevationChangePipeAccesorys).OnDelete(DeleteBehavior.NoAction);

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



            //Relation Many to Many Purchase Order  MWOItem
            modelBuilder.Entity<PurchaseOrderMWOItem>().HasKey(i => new { i.PurchaseOrderId, i.MWOItemId });
            modelBuilder.Entity<PurchaseOrder>().HasMany(c => c.PurchaseOrderMWOItems).WithOne(t => t.PurchaseOrder).OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<MWOItem>().HasMany(c => c.PurchaseOrderMWOItems).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.NoAction);
        
       
        }




        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<MWOType>? MWOTypes { get; set; }
        public DbSet<MWO>? MWOs { get; set; }
        public DbSet<MWOItem>? MWOItems { get; set; }
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
        public DbSet<Unit>? Units { get; set; }
        public DbSet<ProcessFluid>? ProcessFluids { get; set; }
        public DbSet<PipeDiameter>? PipeDiameters { get; set; }
        public DbSet<Nozzle>? Nozzles { get; set; }
        public DbSet<PipeAccesory>? PipeAccesorys { get; set; }
        public DbSet<PipeClass>? PipeClasss { get; set; }
        public DbSet<ConnectionType>? ConnectionTypes { get; set; }
        public DbSet<ProcessCondition>? ProcessConditions { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "system";
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.UpdateDate = DateTime.UtcNow;
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
