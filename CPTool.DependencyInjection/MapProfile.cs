using AutoMapper;

using CPTool.DTOS;
using CPTool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DependencyInjection
{

    public class MapProfile : Profile
    {
        public MapProfile()
        {
            EntitytoDTO();
            DTOtoEntity();
        }
        void EntitytoDTO()
        {
            CreateMap<AuditableEntity, AuditableEntityDTO>()
                .ReverseMap();


            CreateMap<TaxCodeLP, TaxCodeLPDTO>()

               .ForMember(dest => dest.SuppliersDTO,
                act => { act.PreCondition(src => (src.Suppliers != null)); act.MapFrom(src => src.Suppliers); }
               );
            CreateMap<TaxCodeLD, TaxCodeLDDTO>()
              .ForMember(dest => dest.SuppliersDTO,
               act => { act.PreCondition(src => (src.Suppliers != null)); act.MapFrom(src => src.Suppliers); });
            CreateMap<VendorCode, VendorCodeDTO>()
               .ForMember(dest => dest.SuppliersDTO,
                act => { act.PreCondition(src => (src.Suppliers != null)); act.MapFrom(src => src.Suppliers); });
            CreateMap<Gasket, GasketDTO>()
                .ForMember(dest => dest.EquipmentItemDTOs,
                 act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); }
                 );
            CreateMap<Material, MaterialDTO>()
                .ForMember(dest => dest.InnerMaterialsDTO,
                  act => act.MapFrom(src => src.InnerMaterials))
                .ForMember(dest => dest.OuterMaterialsDTO,
                  act => act.MapFrom(src => src.OuterMaterials));
            CreateMap<BrandSupplier, BrandSupplierDTO>()
               .ForMember(dest => dest.BrandDTO,
                 act => act.MapFrom(src => src.Brand))
              .ForMember(dest => dest.SupplierDTO,
                 act => act.MapFrom(src => src.Supplier));
            CreateMap<Brand, BrandDTO>()
                .ForMember(dest => dest.BrandSupplierDTOs,
                  act => act.MapFrom(src => src.BrandSuppliers))
                .ForMember(dest => dest.EquipmentItemDTOs,
                  act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); });
            CreateMap<Supplier, SupplierDTO>()
               .ForMember(dest => dest.BrandSupplierDTOs,
                 act => act.MapFrom(src => src.BrandSuppliers))
               .ForMember(dest => dest.VendorCodeDTO,
                 act => act.MapFrom(src => src.VendorCode))
               .ForMember(dest => dest.TaxCodeLDDTO,
                 act => act.MapFrom(src => src.TaxCodeLD))
               .ForMember(dest => dest.TaxCodeLPDTO,
                 act => act.MapFrom(src => src.TaxCodeLP))
                .ForMember(dest => dest.EquipmentItemDTOs,
                 act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); });

            CreateMap<EquipmentType, EquipmentTypeDTO>()
                  .ForMember(dest => dest.EquipmentTypeSubDTOs,
                  act => act.MapFrom(src => src.EquipmentTypeSubs))
                   .ForMember(dest => dest.EquipmentItemDTOs,
                  act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); });
            CreateMap<EquipmentTypeSub, EquipmentTypeSubDTO>()
                .ForMember(dest => dest.EquipmentTypeDTO,
                 act => act.MapFrom(src => src.EquipmentType))
                .ForMember(dest => dest.EquipmentItemDTOs,
                 act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); });



            CreateMap<AlterationItem, AlterationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
               ;
            CreateMap<ContingencyItem, ContingencyItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                ;
            CreateMap<EHSItem, EHSItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                ;
            CreateMap<ElectricalItem, ElectricalItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                ;
            CreateMap<EngineeringCostItem, EngineeringCostItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));


            CreateMap<EquipmentItem, EquipmentItemDTO>()
               .ForMember(dest => dest.GasketDTO, act => act.MapFrom(src => src.Gasket))
                .ForMember(dest => dest.InnerMaterialDTO, act => act.MapFrom(src => src.InnerMaterial))
                .ForMember(dest => dest.OuterMaterialDTO, act => act.MapFrom(src => src.OuterMaterial))
                .ForMember(dest => dest.EquipmentTypeDTO, act => act.MapFrom(src => src.EquipmentType))
                 .ForMember(dest => dest.EquipmentTypeSubDTO, act => act.MapFrom(src => src.EquipmentTypeSub))
               .ForMember(dest => dest.BrandDTO, act => 
               { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); })

                .ForMember(dest => dest.SupplierDTO, act =>
                { act.PreCondition(src => (src.Supplier != null)); act.MapFrom(src => src.Supplier); })
                 .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<FoundationItem, FoundationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<InstrumentItem, InstrumentItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<InsulationItem, InsulationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<PaintingItem, PaintingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<PipingItem, PipingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<StructuralItem, StructuralItemDTO>()
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<TaxesItem, TaxesItemDTO>()
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<TestingItem, TestingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));


            CreateMap<TestingItem, TestingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));


            CreateMap<PurchaseOrderItem, PurchaseOrderItemDTO>()
                .ForMember(dest => dest.PurchaseOrderDTO,
                act => act.MapFrom(src => src.PurchaseOrder));

            CreateMap<PurchaseOrder, PurchaseOrderDTO>()
               .ForMember(dest => dest.MWODTO, act => act.MapFrom(src => src.MWO))
               .ForMember(dest => dest.PurchaseOrderItemDTOs,
               act => act.MapFrom(src => src.PurchaseOrderItems));

            CreateMap<Chapter, ChapterDTO>()
             .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<UnitaryBasePrize, UnitaryBasePrizeDTO>()
                .ForMember(dest => dest.MWOItemDTOs,
                act => act.MapFrom(src => src.MWOItems));

            CreateMap<MWOItem, MWOItemDTO>()
               .ForMember(dest => dest.PurchaseOrderDTOs, act => act.MapFrom(src => src.PurchaseOrders))
               .ForMember(dest => dest.MWODTO, act => act.MapFrom(src => src.MWO))
               .ForMember(dest => dest.AlterationItemDTO, act => act.MapFrom(src => src.AlterationItem))
               .ForMember(dest => dest.ContingencyItemDTO, act => act.MapFrom(src => src.ContingencyItem))
               .ForMember(dest => dest.EHSItemDTO, act => act.MapFrom(src => src.EHSItem))
               .ForMember(dest => dest.ElectricalItemDTO, act => act.MapFrom(src => src.ElectricalItem))
               .ForMember(dest => dest.EngineeringCostItemDTO, act => act.MapFrom(src => src.EngineeringCostItem))
               .ForMember(dest => dest.EquipmentItemDTO, act => act.MapFrom(src => src.EquipmentItem))
               .ForMember(dest => dest.FoundationItemDTO, act => act.MapFrom(src => src.FoundationItem))
               .ForMember(dest => dest.InstrumentItemDTO, act => act.MapFrom(src => src.InstrumentItem))
               .ForMember(dest => dest.InsulationItemDTO, act => act.MapFrom(src => src.InsulationItem))
               .ForMember(dest => dest.PaintingItemDTO, act => act.MapFrom(src => src.PaintingItem))
               .ForMember(dest => dest.PipingItemDTO, act => act.MapFrom(src => src.PipingItem))
               .ForMember(dest => dest.StructuralItemDTO, act => act.MapFrom(src => src.StructuralItem))
               .ForMember(dest => dest.TaxesItemDTO, act => act.MapFrom(src => src.TaxesItem))
               .ForMember(dest => dest.TestingItemDTO, act => act.MapFrom(src => src.TestingItem))
               .ForMember(dest => dest.UnitaryBasePrizeDTO, act => act.MapFrom(src => src.UnitaryBasePrize))
               .ForMember(dest => dest.ChapterDTO, act => act.MapFrom(src => src.Chapter));

            CreateMap<MWO, MWODTO>()
                 .ForMember(dest => dest.MWOTypeDTO, act => act.MapFrom(src => src.MWOType))
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                .ForMember(dest => dest.PurchaseOrderDTOs, act => act.MapFrom(src => src.PurchaseOrders));


            CreateMap<MWOType, MWOTypeDTO>()
                .ForMember(dest => dest.MWODTOs, act => act.MapFrom(src => src.MWOs));

        }
        void DTOtoEntity()
        {
            CreateMap<AuditableEntityDTO, AuditableEntity>();
            CreateMap<TaxCodeLPDTO, TaxCodeLP>();
            CreateMap<TaxCodeLDDTO, TaxCodeLD>();
            CreateMap<VendorCodeDTO, VendorCode>();
            CreateMap<GasketDTO, Gasket>();
            CreateMap<MaterialDTO, Material>();
            CreateMap<BrandDTO, Brand>();
            CreateMap<SupplierDTO, Supplier>();
            CreateMap<BrandSupplierDTO, BrandSupplier>();
            CreateMap<EquipmentTypeDTO, EquipmentType>();
            CreateMap<EquipmentTypeSubDTO, EquipmentTypeSub>();
            CreateMap<AlterationItemDTO, AlterationItem>();
            CreateMap<ContingencyItemDTO, ContingencyItem>();
            CreateMap<EHSItemDTO, EHSItem>();
            CreateMap<ElectricalItemDTO, ElectricalItem>();
            CreateMap<EngineeringCostItemDTO, EngineeringCostItem>();
            CreateMap<EquipmentItemDTO, EquipmentItem>();
            CreateMap<FoundationItemDTO, FoundationItem>();
            CreateMap<InstrumentItemDTO, InstrumentItem>();
            CreateMap<InsulationItemDTO, InsulationItem>();
            CreateMap<PaintingItemDTO, PaintingItem>();
            CreateMap<PipingItemDTO, PipingItem>();
            CreateMap<StructuralItemDTO, StructuralItem>();
            CreateMap<TaxesItemDTO, TaxesItem>();
            CreateMap<TestingItemDTO, TestingItem>();
            CreateMap<PurchaseOrderItemDTO, PurchaseOrderItem>();
            CreateMap<PurchaseOrderDTO, PurchaseOrder>();
            CreateMap<ChapterDTO, Chapter>();
            CreateMap<UnitaryBasePrizeDTO, UnitaryBasePrize>();
            CreateMap<MWOItemDTO, MWOItem>();
            CreateMap<MWODTO, MWO>();
            CreateMap<MWOTypeDTO, MWOType>();
        }
    }
}
