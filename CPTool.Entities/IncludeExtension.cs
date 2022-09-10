using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Entities
{
    public static class IncludeExtension
    {
        public static IQueryable<T> ToIncludeEntities<T>(this IQueryable<T> source) where T : AuditableEntity
        {
          
            return source;
        }
        public static IQueryable<AlterationItem> ToIncludeEntities(this IQueryable<AlterationItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<Brand> ToIncludeEntities(this IQueryable<Brand> source)
        {

            return source.Include(x => x.BrandSuppliers).Include(y => y.EquipmentItems);
        }
        public static IQueryable<BrandSupplier> ToIncludeEntities(this IQueryable<BrandSupplier> source)
        {

            return source.Include(x => x.Brand).Include(y => y.Supplier);
        }
        public static IQueryable<Chapter> ToIncludeEntities(this IQueryable<Chapter> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<ContingencyItem> ToIncludeEntities(this IQueryable<ContingencyItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<EHSItem> ToIncludeEntities(this IQueryable<EHSItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<ElectricalItem> ToIncludeEntities(this IQueryable<ElectricalItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<EngineeringCostItem> ToIncludeEntities(this IQueryable<EngineeringCostItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<EquipmentItem> ToIncludeEntities(this IQueryable<EquipmentItem> source)
        {

            return source.Include(x => x.MWOItems)
                .Include(x => x.Gasket)
                .Include(x => x.InnerMaterial)
                .Include(x => x.OuterMaterial)
                .Include(x => x.EquipmentType)
                .Include(x => x.EquipmentTypeSub)
                .Include(x => x.Brand)
                .Include(x => x.Supplier); ;
        }
        public static IQueryable<EquipmentType> ToIncludeEntities(this IQueryable<EquipmentType> source)
        {

            return source.Include(x => x.EquipmentItems)
                .Include(x => x.EquipmentTypeSubs);
        }
        public static IQueryable<EquipmentTypeSub> ToIncludeEntities(this IQueryable<EquipmentTypeSub> source)
        {

            return source.Include(x => x.EquipmentItems)
                .Include(x => x.EquipmentType);
        }
        public static IQueryable<FoundationItem> ToIncludeEntities(this IQueryable<FoundationItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<Gasket> ToIncludeEntities(this IQueryable<Gasket> source)
        {

            return source.Include(x => x.EquipmentItems);
        }
        public static IQueryable<InstrumentItem> ToIncludeEntities(this IQueryable<InstrumentItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<InsulationItem> ToIncludeEntities(this IQueryable<InsulationItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<Material> ToIncludeEntities(this IQueryable<Material> source)
        {

            return source.Include(x => x.InnerMaterials).Include(y => y.OuterMaterials);
        }
        public static IQueryable<MWO> ToIncludeEntities(this IQueryable<MWO> source)
        {

            return source.Include(x => x.MWOType)
                .Include(y => y.MWOItems)
                .Include(y => y.PurchaseOrders);
        }
        public static IQueryable<MWOItem> ToIncludeEntities(this IQueryable<MWOItem> source)
        {

            return source.Include(x => x.MWO)
                .Include(y => y.AlterationItem)
                .Include(y => y.FoundationItem)
                 .Include(y => y.StructuralItem)
                 .Include(y => y.EquipmentItem)
                  .Include(y => y.ElectricalItem)
                  .Include(y => y.PipingItem)
                  .Include(y => y.InstrumentItem)
                  .Include(y => y.InsulationItem)
                  .Include(y => y.PaintingItem)
                  .Include(y => y.EHSItem)
                  .Include(y => y.TaxesItem)
                  .Include(y => y.TestingItem)
                  .Include(y => y.EngineeringCostItem)
                  .Include(y => y.ContingencyItem)
                  .Include(y => y.Chapter)
                  .Include(y => y.UnitaryBasePrize)
                              ;
        }
        public static IQueryable<MWOType> ToIncludeEntities(this IQueryable<MWOType> source)
        {

            return source.Include(x => x.MWOs)
                ;
        }
        public static IQueryable<PaintingItem> ToIncludeEntities(this IQueryable<PaintingItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<PipingItem> ToIncludeEntities(this IQueryable<PipingItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<PurchaseOrder> ToIncludeEntities(this IQueryable<PurchaseOrder> source)
        {

            return source.Include(x => x.MWO).Include(y => y.PurchaseOrderItems);
        }
        public static IQueryable<PurchaseOrderItem> ToIncludeEntities(this IQueryable<PurchaseOrderItem> source)
        {

            return source.Include(x => x.PurchaseOrder);
        }
        public static IQueryable<StructuralItem> ToIncludeEntities(this IQueryable<StructuralItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<Supplier> ToIncludeEntities(this IQueryable<Supplier> source)
        {

            return source.Include(x => x.EquipmentItems)
                .Include(x => x.BrandSuppliers);
        }
        public static IQueryable<TaxesItem> ToIncludeEntities(this IQueryable<TaxesItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<TestingItem> ToIncludeEntities(this IQueryable<TestingItem> source)
        {

            return source.Include(x => x.MWOItems);
        }
        public static IQueryable<UnitaryBasePrize> ToIncludeEntities(this IQueryable<UnitaryBasePrize> source)
        {

            return source.Include(x => x.MWOItems);
        }
    }
}
