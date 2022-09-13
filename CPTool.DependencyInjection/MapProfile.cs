using AutoMapper;

using CPTool.DTOS;
using CPTool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DependencyInjection
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AuditableEntity, AuditableEntityDTO>()
                .ReverseMap();
            CreateMap<TaxCodeLP, TaxCodeLPDTO>()
               .ForMember(dest => dest.SuppliersDTO,
                act => act.MapFrom(src => src.Suppliers))
              .ReverseMap();
            CreateMap<TaxCodeLD, TaxCodeLDDTO>()
              .ForMember(dest => dest.SuppliersDTO,
               act => act.MapFrom(src => src.Suppliers))
             .ReverseMap();
            CreateMap<VendorCode, VendorCodeDTO>()
               .ForMember(dest => dest.SuppliersDTO,
                act => act.MapFrom(src => src.Suppliers))
              .ReverseMap();
            CreateMap<Gasket, GasketDTO>()
                 .ForMember(dest => dest.EquipmentItemDTOs,
                  act => act.MapFrom(src => src.EquipmentItems))
                .ReverseMap();
            CreateMap<Material, MaterialDTO>()
                .ForMember(dest => dest.InnerMaterialsDTO,
                  act => act.MapFrom(src => src.InnerMaterials))
                .ForMember(dest => dest.OuterMaterialsDTO,
                  act => act.MapFrom(src => src.OuterMaterials))
               .ReverseMap();
            CreateMap<BrandSupplier, BrandSupplierDTO>()
                .ForMember(dest => dest.BrandDTO,
                  act => act.MapFrom(src => src.Brand))
               .ForMember(dest => dest.SupplierDTO,
                  act => act.MapFrom(src => src.Supplier))
             .ReverseMap();
            CreateMap<BrandSupplierDTO, CreateBrandSupplierDTO>();
            CreateMap<CreateBrandSupplierDTO, BrandSupplier>();
            CreateMap<Brand, BrandDTO>()
                .ForMember(dest => dest.BrandSupplierDTOs,
                  act => act.MapFrom(src => src.BrandSuppliers))
                .ForMember(dest => dest.EquipmentItemDTOs,
                  act => act.MapFrom(src => src.EquipmentItems))
                .ReverseMap();

            CreateMap<Supplier, SupplierDTO>()
                 //.ForMember(dest => dest.VendorCodeDTO,
                 // act => act.MapFrom(src => src.VendorCode))
                 // .ForMember(dest => dest.TaxCodeLPDTO,
                 // act => act.MapFrom(src => src.TaxCodeLP))
                 //  .ForMember(dest => dest.TaxCodeLDDTO,
                 // act => act.MapFrom(src => src.TaxCodeLD))
                .ForMember(dest => dest.BrandSupplierDTOs,
                  act => act.MapFrom(src => src.BrandSuppliers))
                 .ForMember(dest => dest.EquipmentItemDTOs,
                  act => act.MapFrom(src => src.EquipmentItems))
                .ReverseMap();
            //CreateMap<SupplierDTO, CreateSupplierDTO>()
            //    .ForMember(dest => dest.VendorCodeDTO,
            //      act => act.MapFrom(src => src.VendorCodeDTO))
            //      .ForMember(dest => dest.TaxCodeLPDTO,
            //      act => act.MapFrom(src => src.TaxCodeLPDTO))
            //       .ForMember(dest => dest.TaxCodeLDDTO,
            //      act => act.MapFrom(src => src.TaxCodeLDDTO))
            //       .ForMember(dest => dest.BrandSupplierDTOs,
            //      act => act.MapFrom(src => src.BrandSupplierDTOs))
            //     .ForMember(dest => dest.EquipmentItemDTOs,
            //      act => act.MapFrom(src => src.EquipmentItemDTOs));
            //CreateMap<CreateSupplierDTO, Supplier>().ForMember(dest => dest.BrandSuppliers,
            //      act => act.MapFrom(src => src.BrandSupplierDTOs))
            //     .ForMember(dest => dest.EquipmentItems,
            //      act => act.MapFrom(src => src.EquipmentItemDTOs));
            CreateMap<EquipmentType, EquipmentTypeDTO>()
                  .ForMember(dest => dest.EquipmentTypeSubDTOs,
                  act => act.MapFrom(src => src.EquipmentTypeSubs))
                   .ForMember(dest => dest.EquipmentItemDTOs,
                  act => act.MapFrom(src => src.EquipmentItems))
               .ReverseMap();
            CreateMap<EquipmentTypeSubDTO, CreateEquipmentTypeSubDTO>()
                .ForMember(dest => dest.EquipmentItemDTOs,
                  act => act.MapFrom(src => src.EquipmentItemDTOs));
            CreateMap<CreateEquipmentTypeSubDTO, EquipmentTypeSub>()
                .ForMember(dest => dest.EquipmentItems,
                  act => act.MapFrom(src => src.EquipmentItemDTOs));
            CreateMap<EquipmentTypeSub, EquipmentTypeSubDTO>()
                 .ForMember(dest => dest.EquipmentTypeDTO,
                  act => act.MapFrom(src => src.EquipmentType))
                 .ForMember(dest => dest.EquipmentItemDTOs,
                  act => act.MapFrom(src => src.EquipmentItems))
               .ReverseMap();
            CreateMap<AlterationItem, AlterationItemDTO>()
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                .ReverseMap();
            CreateMap<ContingencyItem, ContingencyItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                .ReverseMap();
            CreateMap<EHSItem, EHSItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                .ReverseMap();
            CreateMap<ElectricalItem, ElectricalItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                .ReverseMap();
            CreateMap<EngineeringCostItem, EngineeringCostItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems)).ReverseMap();
            CreateMap<EquipmentItem, EquipmentItemDTO>()
                .ForMember(dest => dest.GasketDTO, act => act.MapFrom(src => src.Gasket))
                 .ForMember(dest => dest.InnerMaterialDTO, act => act.MapFrom(src => src.InnerMaterial))
                 .ForMember(dest => dest.OuterMaterialDTO, act => act.MapFrom(src => src.OuterMaterial))
                 .ForMember(dest => dest.EquipmentTypeDTO, act => act.MapFrom(src => src.EquipmentType))
                  .ForMember(dest => dest.EquipmentTypeSubDTO, act => act.MapFrom(src => src.EquipmentTypeSub))
                .ForMember(dest => dest.BrandDTO, act => act.MapFrom(src => src.Brand))
                 .ForMember(dest => dest.SupplierDTO, act => act.MapFrom(src => src.Supplier))
                  .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                .ReverseMap();
            CreateMap<CreateEquipmentItemDTO, EquipmentItem>()
                .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemDTOs));
            CreateMap<EquipmentItemDTO, CreateEquipmentItemDTO>();
            CreateMap<FoundationItem, FoundationItemDTO>()
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems)).ReverseMap();
            CreateMap<InstrumentItem, InstrumentItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems)).ReverseMap();
            CreateMap<InsulationItem, InsulationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems)).ReverseMap();

            CreateMap<PaintingItem, PaintingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems)).ReverseMap();
            CreateMap<PipingItem, PipingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems)).ReverseMap();
            CreateMap<StructuralItem, StructuralItemDTO>()
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems)).ReverseMap();
            CreateMap<TaxesItem, TaxesItemDTO>()
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems)).ReverseMap();
            CreateMap<TestingItem, TestingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems)).ReverseMap();

            CreateMap<PurchaseOrder, PurchaseOrderDTO>()
                .ForMember(dest => dest.MWODTO, act => act.MapFrom(src => src.MWO))
                .ForMember(dest => dest.PurchaseOrderItemDTOs, act => act.MapFrom(src => src.PurchaseOrderItems))
                .ReverseMap();
            CreateMap<PurchaseOrderDTO, CreatePurchaseOrderDTO>()
                .ForMember(dest => dest.PurchaseOrderItemDTOs,
                act => act.MapFrom(src => src.PurchaseOrderItemDTOs));
            CreateMap<CreatePurchaseOrderDTO, PurchaseOrder>()
                .ForMember(dest => dest.PurchaseOrderItems,
                act => act.MapFrom(src => src.PurchaseOrderItemDTOs));

            CreateMap<PurchaseOrderItem, PurchaseOrderItemDTO>()
                .ForMember(dest => dest.PurchaseOrderDTO,
                act => act.MapFrom(src => src.PurchaseOrder))
                .ReverseMap();
            CreateMap<PurchaseOrderItemDTO, CreatePurchaseOrderDTO>();
            CreateMap<CreatePurchaseOrderDTO, PurchaseOrderItem>();
            CreateMap<Chapter, ChapterDTO>()
             .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
             .ReverseMap();
            CreateMap<UnitaryBasePrize, UnitaryBasePrizeDTO>()
                 .ForMember(dest => dest.MWOItemDTOs,
                 act => act.MapFrom(src => src.MWOItems)).ReverseMap();
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
                .ForMember(dest => dest.ChapterDTO, act => act.MapFrom(src => src.Chapter))

               .ReverseMap();
            CreateMap<MWOItemDTO, CreateMWOItemDTO>()
                .ForMember(dest => dest.PurchaseOrderDTOs, act => act.MapFrom(src => src.PurchaseOrderDTOs));
            ;
            CreateMap<CreateMWOItemDTO, MWOItem>()
                .ForMember(dest => dest.PurchaseOrders, act => act.MapFrom(src => src.PurchaseOrderDTOs));

            CreateMap<MWO, MWODTO>()
                 .ForMember(dest => dest.MWOTypeDTO, act => act.MapFrom(src => src.MWOType))
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
                .ForMember(dest => dest.PurchaseOrderDTOs, act => act.MapFrom(src => src.PurchaseOrders))
                .ReverseMap();
            CreateMap<CreateMWODTO, MWO>()
              .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemDTOs))
              .ForMember(dest => dest.PurchaseOrders, act => act.MapFrom(src => src.PurchaseOrderDTOs));

            CreateMap<MWODTO, CreateMWODTO>();
            CreateMap<MWOType, MWOTypeDTO>()
                .ForMember(dest => dest.MWODTOs, act => act.MapFrom(src => src.MWOs))
                .ReverseMap();


        }
    }
}
