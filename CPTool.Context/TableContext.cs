


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

            modelBuilder.Entity<Brand>().HasMany(c => c.BrandSuppliers).WithOne(t => t.Brand).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Supplier>().HasMany(c => c.BrandSuppliers).WithOne(t => t.Supplier).OnDelete(DeleteBehavior.Cascade);

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
