


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
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.InnerMaterial).WithMany(t => t.InnerMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EquipmentItem>().HasOne(c => c.OuterMaterial).WithMany(t => t.OuterMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BrandSupplier>().HasKey(i => new { i.BrandId, i.SupplierId });

            //modelBuilder.Entity<Chapter>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<MWOType>().Navigation(e => e.MWOs ).AutoInclude();
            ////modelBuilder.Entity<MWO>().Navigation(e => e.MWOType).AutoInclude();
            //modelBuilder.Entity<MWO>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<MWO>().Navigation(e => e.PurchaseOrders).AutoInclude();

            //modelBuilder.Entity<MWOItem>().Navigation(e => e.MWO).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.Chapter).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.UnitaryBasePrize).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.AlterationItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.FoundationItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.StructuralItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.EquipmentItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.ElectricalItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.PipingItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.InstrumentItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.InsulationItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.PaintingItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.EHSItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.TaxesItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.TestingItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.EngineeringCostItem).AutoInclude();
            ////modelBuilder.Entity<MWOItem>().Navigation(e => e.ContingencyItem).AutoInclude();

            ////modelBuilder.Entity<PurchaseOrder>().Navigation(e => e.MWO).AutoInclude();
            //modelBuilder.Entity<PurchaseOrder>().Navigation(e => e.PurchaseOrderItems).AutoInclude();

            ////modelBuilder.Entity<PurchaseOrderItem>().Navigation(e => e.PurchaseOrder).AutoInclude();

            //modelBuilder.Entity<AlterationItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<FoundationItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<StructuralItem>().Navigation(e => e.MWOItems).AutoInclude();

            //modelBuilder.Entity<EquipmentItem>().Navigation(e => e.MWOItems).AutoInclude();
            ////modelBuilder.Entity<EquipmentItem>().Navigation(e => e.Gasket).AutoInclude();
            ////modelBuilder.Entity<EquipmentItem>().Navigation(e => e.InnerMaterial).AutoInclude();
            ////modelBuilder.Entity<EquipmentItem>().Navigation(e => e.OuterMaterial).AutoInclude();
            ////modelBuilder.Entity<EquipmentItem>().Navigation(e => e.EquipmentType).AutoInclude();
            ////modelBuilder.Entity<EquipmentItem>().Navigation(e => e.EquipmentTypeSub).AutoInclude();
            ////modelBuilder.Entity<EquipmentItem>().Navigation(e => e.Brand).AutoInclude();
            ////modelBuilder.Entity<EquipmentItem>().Navigation(e => e.Supplier).AutoInclude();

            //modelBuilder.Entity<ElectricalItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<PipingItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<AlterationItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<InstrumentItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<PaintingItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<EHSItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<TaxesItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<TestingItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<EngineeringCostItem>().Navigation(e => e.MWOItems).AutoInclude();
            //modelBuilder.Entity<ContingencyItem>().Navigation(e => e.MWOItems).AutoInclude();

            //modelBuilder.Entity<UnitaryBasePrize>().Navigation(e => e.MWOItems).AutoInclude();

            //modelBuilder.Entity<Gasket>().Navigation(e => e.EquipmentItems).AutoInclude();

            //modelBuilder.Entity<EquipmentType>().Navigation(e => e.EquipmentItems).AutoInclude();
            //modelBuilder.Entity<EquipmentType>().Navigation(e => e.EquipmentTypeSubs).AutoInclude();

            //modelBuilder.Entity<EquipmentTypeSub>().Navigation(e => e.EquipmentItems).AutoInclude();
            ////modelBuilder.Entity<EquipmentTypeSub>().Navigation(e => e.EquipmentType).AutoInclude();

            //modelBuilder.Entity<Brand>().Navigation(e => e.EquipmentItems).AutoInclude();
            //modelBuilder.Entity<Brand>().Navigation(e => e.BrandSuppliers).AutoInclude();

            //modelBuilder.Entity<Supplier>().Navigation(e => e.EquipmentItems).AutoInclude();
            //modelBuilder.Entity<Supplier>().Navigation(e => e.BrandSuppliers).AutoInclude();

            ////modelBuilder.Entity<BrandSupplier>().Navigation(e => e.Brand).AutoInclude();
            ////modelBuilder.Entity<BrandSupplier>().Navigation(e => e.Supplier).AutoInclude();

            //modelBuilder.Entity<Material>().Navigation(e => e.InnerMaterials).AutoInclude();
            //modelBuilder.Entity<Material>().Navigation(e => e.OuterMaterials).AutoInclude();

        }

       
      
       
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<MWOType> MWOTypes { get; set; }
        public DbSet<MWO> MWOs { get; set; }
        public DbSet<MWOItem> MWOItems { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
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
