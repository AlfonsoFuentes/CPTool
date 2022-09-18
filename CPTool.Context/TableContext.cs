﻿


using CPTool.Interfaces;
using System.Diagnostics;

namespace CPTool.Context
{
    public class TableContext : DbContext
    {
        public TableContext(DbContextOptions<TableContext> options)
            : base(options)
        {


        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialsGroup>().HasOne(c => c.InnerMaterial).WithMany(t => t.InnerMaterials).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MaterialsGroup>().HasOne(c => c.OuterMaterial).WithMany(t => t.OuterMaterials).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PipingItem>().HasOne(c => c.NozzleStart).WithMany(t => t.StartPipingItems).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PipingItem>().HasOne(c => c.NozzleFinish).WithMany(t => t.FinishPipingItems).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.OD).WithMany(t => t.ODs).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.ID).WithMany(t => t.IDs).OnDelete(DeleteBehavior.Cascade);
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


            //Relation Many to Many Brand Supplier
            modelBuilder.Entity<BrandSupplier>().HasKey(i => new { i.BrandId, i.SupplierId });
            modelBuilder.Entity<Brand>().HasMany(c => c.BrandSuppliers).WithOne(t => t.Brand).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Supplier>().HasMany(c => c.BrandSuppliers).WithOne(t => t.Supplier).OnDelete(DeleteBehavior.Cascade);

            //Relation Many to Many Purchase Order  MWOItem
            modelBuilder.Entity<PurchaseOrderMWOItem>().HasKey(i => new { i.PurchaseOrderId, i.MWOItemId });
            modelBuilder.Entity<PurchaseOrder>().HasMany(c => c.PurchaseOrderMWOItems).WithOne(t => t.PurchaseOrder).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasMany(c => c.PurchaseOrderMWOItems).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.Cascade);
        }

       
      
       
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<MWOType> MWOTypes { get; set; }
        public DbSet<MWO> MWOs { get; set; }
        public DbSet<MWOItem> MWOItems { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderMWOItem> PurchaseOrderMWOItems { get; set; }
        public DbSet<AlterationItem> AlterationItems { get; set; }
        public DbSet<FoundationItem> FoundationItems { get; set; }
        public DbSet<StructuralItem> StructuralItems { get; set; }
        public DbSet<EquipmentItem> EquipmentItems { get; set; }
        public DbSet<ElectricalItem> ElectricalItems { get; set; }
        public DbSet<PipingItem> PipingItems { get; set; }
        public DbSet<InstrumentItem> InstrumentItems { get; set; }
        public DbSet<InsulationItem> InsulationItems { get; set; }
        public DbSet<PaintingItem> PaintingItems { get; set; }
        public DbSet<EHSItem> EHSItems { get; set; }
        public DbSet<TaxesItem> TaxesItems { get; set; }
        public DbSet<TestingItem> TestingItems { get; set; }
        public DbSet<EngineeringCostItem> EngineeringCostItems { get; set; }
        public DbSet<ContingencyItem> ContingencyItems { get; set; }
        public DbSet<UnitaryBasePrize> UnitaryBasePrizes { get; set; }
        public DbSet<Gasket> Gaskets { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<EquipmentTypeSub> EquipmentTypeSubs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<BrandSupplier> BrandSuppliers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<TaxCodeLD> TaxCodeLDs { get; set; }
        public DbSet<VendorCode> VendorCodes { get; set; }
        public DbSet<TaxCodeLP> TaxCodeLPs { get; set; }

        public DbSet<DownPayment> DownPayments { get; set; }

        public DbSet<MeasuredVariable> MeasuredVariables { get; set; }
        public DbSet<MeasuredVariableModifier> MeasuredVariableModifiers { get; set; }
        public DbSet<DeviceFunction> DeviceFunctions { get; set; }
        public DbSet<DeviceFunctionModifier> DeviceFunctionModifiers { get; set; }
        public DbSet<Readout> Readouts { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;

                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
