﻿using AutoMapper;

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
            CreateMap<DownPayment, DownPaymentDTO>().ForMember(dest => dest.PurchaseOrderDTO,
               act => { act.PreCondition(src => (src.PurchaseOrder != null)); act.MapFrom(src => src.PurchaseOrder); });

            CreateMap<TaxCodeLP, TaxCodeLPDTO>().ForMember(dest => dest.SuppliersDTO,
                act => { act.PreCondition(src => (src.Suppliers != null)); act.MapFrom(src => src.Suppliers); });
            CreateMap<TaxCodeLD, TaxCodeLDDTO>()
              .ForMember(dest => dest.SuppliersDTO,
               act => { act.PreCondition(src => (src.Suppliers != null)); act.MapFrom(src => src.Suppliers); });
            CreateMap<VendorCode, VendorCodeDTO>()
               .ForMember(dest => dest.SuppliersDTO,
                act => { act.PreCondition(src => (src.Suppliers != null)); act.MapFrom(src => src.Suppliers); });
            CreateMap<Gasket, GasketDTO>()
                .ForMember(dest => dest.MaterialsGroupDTOs,
                 act => { act.PreCondition(src => (src.MaterialsGroups != null)); act.MapFrom(src => src.MaterialsGroups); });

            CreateMap<BrandSupplier, BrandSupplierDTO>()
               .ForMember(dest => dest.BrandDTO, act => { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); })
              .ForMember(dest => dest.SupplierDTO, act => { act.PreCondition(src => (src.Supplier != null)); act.MapFrom(src => src.Supplier); });
            CreateMap<Brand, BrandDTO>()
                .ForMember(dest => dest.BrandSupplierDTOs, act => { act.PreCondition(src => (src.BrandSuppliers != null)); act.MapFrom(src => src.BrandSuppliers); })
         .ForMember(dest => dest.InstrumentItemDTOs,
                  act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); })
                .ForMember(dest => dest.EquipmentItemDTOs,
                  act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); })
            .ForMember(dest => dest.PurchaseOrderDTOs,
                  act => { act.PreCondition(src => (src.PurchaseOrders != null)); act.MapFrom(src => src.PurchaseOrders); });
            CreateMap<Supplier, SupplierDTO>()
               .ForMember(dest => dest.BrandSupplierDTOs, act => { act.PreCondition(src => (src.BrandSuppliers != null)); act.MapFrom(src => src.BrandSuppliers); })
               .ForMember(dest => dest.VendorCodeDTO, act => { act.PreCondition(src => (src.VendorCode != null)); act.MapFrom(src => src.VendorCode); })
               .ForMember(dest => dest.TaxCodeLDDTO, act => { act.PreCondition(src => (src.TaxCodeLD != null)); act.MapFrom(src => src.TaxCodeLD); })
               .ForMember(dest => dest.TaxCodeLPDTO, act => { act.PreCondition(src => (src.TaxCodeLP != null)); act.MapFrom(src => src.TaxCodeLP); })
                .ForMember(dest => dest.EquipmentItemDTOs,
                 act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); })
                .ForMember(dest => dest.InstrumentItemDTOs,
                  act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); })
            .ForMember(dest => dest.PurchaseOrderDTOs,
                 act => { act.PreCondition(src => (src.PurchaseOrders != null)); act.MapFrom(src => src.PurchaseOrders); });

            CreateMap<EquipmentType, EquipmentTypeDTO>()
                  .ForMember(dest => dest.EquipmentTypeSubDTOs, act => { act.PreCondition(src => (src.EquipmentTypeSubs != null)); act.MapFrom(src => src.EquipmentTypeSubs); })
                   .ForMember(dest => dest.EquipmentItemDTOs,
                  act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); });
            CreateMap<EquipmentTypeSub, EquipmentTypeSubDTO>()
                .ForMember(dest => dest.EquipmentTypeDTO, act => { act.PreCondition(src => (src.EquipmentType != null)); act.MapFrom(src => src.EquipmentType); })
                .ForMember(dest => dest.EquipmentItemDTOs,
                 act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); });

            CreateMap<Material, MaterialDTO>()
                .ForMember(dest => dest.InnerMaterialDTOs, act => { act.PreCondition(src => (src.InnerMaterials != null)); act.MapFrom(src => src.InnerMaterials); })
                .ForMember(dest => dest.OuterMaterialDTOs, act => { act.PreCondition(src => (src.OuterMaterials != null)); act.MapFrom(src => src.OuterMaterials); });
            CreateMap<MaterialsGroup, MaterialsGroupDTO>()
                .ForMember(dest => dest.EquipmentItemDTOs, act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); })
                .ForMember(dest => dest.InstrumentItemDTOs, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); })
                .ForMember(dest => dest.GasketDTO, act => { act.PreCondition(src => (src.Gasket != null)); act.MapFrom(src => src.Gasket); })
                .ForMember(dest => dest.InnerMaterialDTO, act => { act.PreCondition(src => (src.InnerMaterial != null)); act.MapFrom(src => src.InnerMaterial); })
                .ForMember(dest => dest.OuterMaterialDTO, act => { act.PreCondition(src => (src.OuterMaterial != null)); act.MapFrom(src => src.OuterMaterial); });

            CreateMap<AlterationItem, AlterationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<ContingencyItem, ContingencyItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<EHSItem, EHSItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<ElectricalItem, ElectricalItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<EngineeringCostItem, EngineeringCostItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });


            CreateMap<EquipmentItem, EquipmentItemDTO>()
               .ForMember(dest => dest.MaterialsGroupDTO, act => { act.PreCondition(src => (src.MaterialsGroup != null)); act.MapFrom(src => src.MaterialsGroup); })

                .ForMember(dest => dest.EquipmentTypeDTO, act => { act.PreCondition(src => (src.EquipmentType != null)); act.MapFrom(src => src.EquipmentType); })
                 .ForMember(dest => dest.EquipmentTypeSubDTO, act => { act.PreCondition(src => (src.EquipmentTypeSub != null)); act.MapFrom(src => src.EquipmentTypeSub); })
               .ForMember(dest => dest.BrandDTO, act => { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); })
                .ForMember(dest => dest.SupplierDTO, act => { act.PreCondition(src => (src.Supplier != null)); act.MapFrom(src => src.Supplier); })
                 .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });

            CreateMap<FoundationItem, FoundationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<MeasuredVariable, MeasuredVariableDTO>()
                .ForMember(dest => dest.InstrumentItemDTOs, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); });
            CreateMap<MeasuredVariableModifier, MeasuredVariableModifierDTO>()
                .ForMember(dest => dest.InstrumentItemDTOs, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); }); ;
            CreateMap<DeviceFunction, DeviceFunctionDTO>()
                  .ForMember(dest => dest.InstrumentItemDTOs, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); }); ;
            CreateMap<DeviceFunctionModifier, DeviceFunctionModifierDTO>()
                  .ForMember(dest => dest.InstrumentItemDTOs, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); }); ;
            CreateMap<Readout, ReadoutDTO>()
                  .ForMember(dest => dest.InstrumentItemDTOs, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); }); ;

            CreateMap<InstrumentItem, InstrumentItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.MaterialsGroupDTO, act => { act.PreCondition(src => (src.MaterialsGroup != null)); act.MapFrom(src => src.MaterialsGroup); })
               .ForMember(dest => dest.MeasuredVariableDTO, act => { act.PreCondition(src => (src.MeasuredVariable != null)); act.MapFrom(src => src.MeasuredVariable); })
               .ForMember(dest => dest.MeasuredVariableModifierDTO, act => { act.PreCondition(src => (src.MeasuredVariableModifier != null)); act.MapFrom(src => src.MeasuredVariableModifier); })
               .ForMember(dest => dest.DeviceFunctionDTO, act => { act.PreCondition(src => (src.DeviceFunction != null)); act.MapFrom(src => src.DeviceFunction); })
               .ForMember(dest => dest.DeviceFunctionModifierDTO, act => { act.PreCondition(src => (src.DeviceFunctionModifier != null)); act.MapFrom(src => src.DeviceFunctionModifier); })
               .ForMember(dest => dest.ReadoutDTO, act => { act.PreCondition(src => (src.Readout != null)); act.MapFrom(src => src.Readout); })
               .ForMember(dest => dest.SupplierDTO, act => { act.PreCondition(src => (src.Supplier != null)); act.MapFrom(src => src.Supplier); })
                 .ForMember(dest => dest.BrandDTO, act => { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); });
            CreateMap<InsulationItem, InsulationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<PaintingItem, PaintingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<PipingItem, PipingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<StructuralItem, StructuralItemDTO>()
                .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<TaxesItem, TaxesItemDTO>()
                .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<TestingItem, TestingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });


            CreateMap<TestingItem, TestingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });


            CreateMap<PurchaseOrderMWOItem, PurchaseOrderMWOItemDTO>()
                .ForMember(dest => dest.PurchaseOrderDTO,
                act => { act.PreCondition(src => (src.PurchaseOrder != null)); act.MapFrom(src => src.PurchaseOrder); })
              .ForMember(dest => dest.MWOItemDTO,
                act => { act.PreCondition(src => (src.MWOItem != null)); act.MapFrom(src => src.MWOItem); });

            CreateMap<PurchaseOrder, PurchaseOrderDTO>()
               .ForMember(dest => dest.PurchaseOrderMWOItemDTOs, act => { act.PreCondition(src => (src.PurchaseOrderMWOItems != null)); act.MapFrom(src => src.PurchaseOrderMWOItems); })
                .ForMember(dest => dest.DownPaymentDTOs, act => { act.PreCondition(src => (src.DownPayments != null)); act.MapFrom(src => src.DownPayments); })
                .ForMember(dest => dest.SupplierDTO, act => { act.PreCondition(src => (src.Supplier != null)); act.MapFrom(src => src.Supplier); })
                .ForMember(dest => dest.BrandDTO, act => { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); });


            CreateMap<Chapter, ChapterDTO>()
             .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<UnitaryBasePrize, UnitaryBasePrizeDTO>()
                .ForMember(dest => dest.MWOItemDTOs,
                act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });

            CreateMap<MWOItem, MWOItemDTO>()
               .ForMember(dest => dest.PurchaseOrderMWOItemDTOs, act => { act.PreCondition(src => (src.PurchaseOrderMWOItems != null)); act.MapFrom(src => src.PurchaseOrderMWOItems); })
                .ForMember(dest => dest.MWODTO, act => act.MapFrom(src => src.MWO))
               .ForMember(dest => dest.AlterationItemDTO, act => { act.PreCondition(src => (src.AlterationItem != null)); act.MapFrom(src => src.AlterationItem); })
               .ForMember(dest => dest.ContingencyItemDTO, act => { act.PreCondition(src => (src.ContingencyItem != null)); act.MapFrom(src => src.ContingencyItem); })
               .ForMember(dest => dest.EHSItemDTO, act => { act.PreCondition(src => (src.EHSItem != null)); act.MapFrom(src => src.EHSItem); })
               .ForMember(dest => dest.ElectricalItemDTO, act => { act.PreCondition(src => (src.ElectricalItem != null)); act.MapFrom(src => src.ElectricalItem); })
               .ForMember(dest => dest.EngineeringCostItemDTO, act => { act.PreCondition(src => (src.EngineeringCostItem != null)); act.MapFrom(src => src.EngineeringCostItem); })
               .ForMember(dest => dest.EquipmentItemDTO, act => { act.PreCondition(src => (src.EquipmentItem != null)); act.MapFrom(src => src.EquipmentItem); })
               .ForMember(dest => dest.FoundationItemDTO, act => { act.PreCondition(src => (src.FoundationItem != null)); act.MapFrom(src => src.FoundationItem); })
               .ForMember(dest => dest.InstrumentItemDTO, act => { act.PreCondition(src => (src.InstrumentItem != null)); act.MapFrom(src => src.InstrumentItem); })
               .ForMember(dest => dest.InsulationItemDTO, act => { act.PreCondition(src => (src.InsulationItem != null)); act.MapFrom(src => src.InsulationItem); })
               .ForMember(dest => dest.PaintingItemDTO, act => { act.PreCondition(src => (src.PaintingItem != null)); act.MapFrom(src => src.PaintingItem); })
               .ForMember(dest => dest.PipingItemDTO, act => { act.PreCondition(src => (src.PipingItem != null)); act.MapFrom(src => src.PipingItem); })
               .ForMember(dest => dest.StructuralItemDTO, act => { act.PreCondition(src => (src.StructuralItem != null)); act.MapFrom(src => src.StructuralItem); })
               .ForMember(dest => dest.TaxesItemDTO, act => { act.PreCondition(src => (src.TaxesItem != null)); act.MapFrom(src => src.TaxesItem); })
               .ForMember(dest => dest.TestingItemDTO, act => { act.PreCondition(src => (src.TestingItem != null)); act.MapFrom(src => src.TestingItem); })
               .ForMember(dest => dest.UnitaryBasePrizeDTO, act => { act.PreCondition(src => (src.UnitaryBasePrize != null)); act.MapFrom(src => src.UnitaryBasePrize); })
               .ForMember(dest => dest.ChapterDTO, act => { act.PreCondition(src => (src.Chapter != null)); act.MapFrom(src => src.Chapter); });

            CreateMap<MWO, MWODTO>()
                 .ForMember(dest => dest.MWOTypeDTO, act => { act.PreCondition(src => (src.MWOType != null)); act.MapFrom(src => src.MWOType); })
                .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });


            CreateMap<MWOType, MWOTypeDTO>()
                .ForMember(dest => dest.MWODTOs, act => { act.PreCondition(src => (src.MWOs != null)); act.MapFrom(src => src.MWOs); });

        }

        void DTOtoEntity()
        {
            CreateMap<AuditableEntityDTO, AuditableEntity>();
            CreateMap<DownPaymentDTO, DownPayment>();
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
            CreateMap<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem>();
            CreateMap<PurchaseOrderDTO, PurchaseOrder>();
            CreateMap<ChapterDTO, Chapter>();
            CreateMap<UnitaryBasePrizeDTO, UnitaryBasePrize>();
            CreateMap<MWOItemDTO, MWOItem>();
            CreateMap<MWODTO, MWO>();
            CreateMap<MWOTypeDTO, MWOType>();
            CreateMap<MaterialsGroupDTO, MaterialsGroup>();
            CreateMap<MeasuredVariableDTO, MeasuredVariable>();
            CreateMap<MeasuredVariableModifierDTO, MeasuredVariableModifier>();
            CreateMap<DeviceFunctionDTO, DeviceFunction>();
            CreateMap<DeviceFunctionModifierDTO, DeviceFunctionModifier>();
            CreateMap<ReadoutDTO, Readout>();
        }

    }
}
