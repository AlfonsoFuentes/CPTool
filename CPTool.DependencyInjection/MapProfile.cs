using AutoMapper;

using CPTool.DTOS;
using CPTool.Entities;
using CPTool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
            CreateMap<AuditableEntity, AuditableEntityDTO>();



            CreateMap<ProcessCondition, ProcessConditionDTO>()
              .ForMember(dest => dest.PipeAccesorysDTO, act => act.MapFrom(src => src.PipeAccesorys))
              .ForMember(dest => dest.EquipmentItemsDTO, act => act.MapFrom(src => src.EquipmentItems))
              .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems))
              .ForMember(dest => dest.PressureDTO, act => act.MapFrom(src => src.Pressure))
              .ForMember(dest => dest.TemperatureDTO, act => act.MapFrom(src => src.Temperature))
              .ForMember(dest => dest.MassFlowDTO, act => act.MapFrom(src => src.MassFlow))
              .ForMember(dest => dest.VolumetricFlowDTO, act => act.MapFrom(src => src.VolumetricFlow))
              .ForMember(dest => dest.DensityDTO, act => act.MapFrom(src => src.Density))
              .ForMember(dest => dest.ViscosityDTO, act => act.MapFrom(src => src.Viscosity))
              .ForMember(dest => dest.EnthalpyFlowDTO, act => act.MapFrom(src => src.EnthalpyFlow))
              .ForMember(dest => dest.SpecificEnthalpyDTO, act => act.MapFrom(src => src.SpecificEnthalpy))
              .ForMember(dest => dest.ThermalConductivityDTO, act => act.MapFrom(src => src.ThermalConductivity))
              .ForMember(dest => dest.SpecificCpDTO, act => act.MapFrom(src => src.SpecificCp));

            CreateMap<ConnectionType, ConnectionTypeDTO>()
               .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles));
            CreateMap<PipeClass, PipeClassDTO>()
               .ForMember(dest => dest.PipingItemsDTO, act => act.MapFrom(src => src.PipingItems))
                .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles));
            CreateMap<PipeAccesory, PipeAccesoryDTO>()
                .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles))
                .ForMember(dest => dest.PipingItemDTO, act => act.MapFrom(src => src.PipingItem))
                .ForMember(dest => dest.ProcessConditionDTO, act => act.MapFrom(src => src.ProcessCondition))
                .ForMember(dest => dest.ReynoldDTO, act => act.MapFrom(src => src.Reynold))
                .ForMember(dest => dest.LevelInletDTO, act => act.MapFrom(src => src.LevelInlet))
                .ForMember(dest => dest.LevelOutletDTO, act => act.MapFrom(src => src.LevelOutlet))
                .ForMember(dest => dest.FrictionDropPressureDTO, act => act.MapFrom(src => src.FrictionDropPressure))
                .ForMember(dest => dest.OverallDropPressureDTO, act => act.MapFrom(src => src.OverallDropPressure))
                .ForMember(dest => dest.ElevationChangeDTO, act => act.MapFrom(src => src.ElevationChange))
                .ForMember(dest => dest.FrictionDTO, act => act.MapFrom(src => src.Friction));
            CreateMap<Nozzle, NozzleDTO>()
                .ForMember(dest => dest.StartPipingItemsDTO, act => act.MapFrom(src => src.StartPipingItems))
                .ForMember(dest => dest.FinishPipingItemsDTO, act => act.MapFrom(src => src.FinishPipingItems))
                .ForMember(dest => dest.PipeClassDTO, act => act.MapFrom(src => src.PipeClass))
                .ForMember(dest => dest.PipeDiameterDTO, act => act.MapFrom(src => src.PipeDiameter))
                .ForMember(dest => dest.ConnectionTypeDTO, act => act.MapFrom(src => src.ConnectionType))
                .ForMember(dest => dest.GasketDTO, act => act.MapFrom(src => src.Gasket))
                .ForMember(dest => dest.MaterialDTO, act => act.MapFrom(src => src.Material))
                .ForMember(dest => dest.PipeAccesoryDTO, act => act.MapFrom(src => src.PipeAccesory))
                .ForMember(dest => dest.EquipmentItemDTO, act => act.MapFrom(src => src.EquipmentItem))
                .ForMember(dest => dest.InstrumentItemDTO, act => act.MapFrom(src => src.InstrumentItem))
                .ForMember(dest => dest.PipingItemDTO, act => act.MapFrom(src => src.PipingItem));
            CreateMap<PipeDiameter, PipeDiameterDTO>()
                .ForMember(dest => dest.PipingItemsDTO, act => act.MapFrom(src => src.PipingItems))
                .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles))
                .ForMember(dest => dest.ODDTO, act => act.MapFrom(src => src.OD))
                .ForMember(dest => dest.IDDTO, act => act.MapFrom(src => src.ID))
                .ForMember(dest => dest.ThicknessDTO, act => act.MapFrom(src => src.Thickness));
            CreateMap<Unit, UnitDTO>()
                .ForMember(dest => dest.ODsDTO, act => act.MapFrom(src => src.ODs))
                .ForMember(dest => dest.IDsDTO, act => act.MapFrom(src => src.IDs))
                .ForMember(dest => dest.ThicknesssDTO, act => act.MapFrom(src => src.Thicknesss))
                .ForMember(dest => dest.SpecificCpsDTO, act => act.MapFrom(src => src.SpecificCps))
                .ForMember(dest => dest.ThermalConductivitysDTO, act => act.MapFrom(src => src.ThermalConductivitys))
                .ForMember(dest => dest.SpecificEnthalpysDTO, act => act.MapFrom(src => src.SpecificEnthalpys))
                .ForMember(dest => dest.EnthalpyFlowsDTO, act => act.MapFrom(src => src.EnthalpyFlows))
                .ForMember(dest => dest.ViscositysDTO, act => act.MapFrom(src => src.Viscositys))
                .ForMember(dest => dest.DensitysDTO, act => act.MapFrom(src => src.Densitys))
                .ForMember(dest => dest.VolumetricFlowsDTO, act => act.MapFrom(src => src.VolumetricFlows))
                .ForMember(dest => dest.MassFlowsDTO, act => act.MapFrom(src => src.MassFlows))
                .ForMember(dest => dest.TemperaturesDTO, act => act.MapFrom(src => src.Temperatures))
                .ForMember(dest => dest.PressuresDTO, act => act.MapFrom(src => src.Pressures))
                .ForMember(dest => dest.FrictionPipeAccesorysDTO, act => act.MapFrom(src => src.FrictionPipeAccesorys))
                .ForMember(dest => dest.ReynoldPipeAccesorysDTO, act => act.MapFrom(src => src.ReynoldPipeAccesorys))
                .ForMember(dest => dest.LevelInletPipeAccesorysDTO, act => act.MapFrom(src => src.LevelInletPipeAccesorys))
                .ForMember(dest => dest.LevelOutletPipeAccesorysDTO, act => act.MapFrom(src => src.LevelOutletPipeAccesorys))
                .ForMember(dest => dest.FrictionDropPressurePipeAccesorysDTO, act => act.MapFrom(src => src.FrictionDropPressurePipeAccesorys))
                .ForMember(dest => dest.OverallDropPressurePipeAccesorysDTO, act => act.MapFrom(src => src.OverallDropPressurePipeAccesorys))
                .ForMember(dest => dest.ElevationChangePipeAccesorysDTO, act => act.MapFrom(src => src.ElevationChangePipeAccesorys));

            CreateMap<ProcessFluid, ProcessFluidDTO>()
                .ForMember(dest => dest.EquipmentItemsDTO,act => act.MapFrom(src => src.EquipmentItems))
                .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems))
                .ForMember(dest => dest.PipingItemsDTO, act => act.MapFrom(src => src.PipingItems));


            CreateMap<DownPayment, DownPaymentDTO>()
                .ForMember(dest => dest.PurchaseOrderDTO,act => act.MapFrom(src => src.PurchaseOrder));

            CreateMap<TaxCodeLP, TaxCodeLPDTO>()
                .ForMember(dest => dest.SuppliersDTO,act => act.MapFrom(src => src.Suppliers));
            CreateMap<TaxCodeLD, TaxCodeLDDTO>()
            .ForMember(dest => dest.SuppliersDTO, act => act.MapFrom(src => src.Suppliers));
            CreateMap<VendorCode, VendorCodeDTO>()
               .ForMember(dest => dest.SuppliersDTO, act => act.MapFrom(src => src.Suppliers));
            CreateMap<Gasket, GasketDTO>()
                 .ForMember(dest => dest.EquipmentItemDTOs, act => act.MapFrom(src => src.EquipmentItems))
                .ForMember(dest => dest.InstrumentItemDTOs,act => act.MapFrom(src => src.InstrumentItems))
                .ForMember(dest => dest.NozzlesDTO,act => act.MapFrom(src => src.Nozzles));

            CreateMap<BrandSupplier, BrandSupplierDTO>()
               .ForMember(dest => dest.BrandDTO, act => { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); })
              .ForMember(dest => dest.SupplierDTO, act => { act.PreCondition(src => (src.Supplier != null)); act.MapFrom(src => src.Supplier); });
            CreateMap<Brand, BrandDTO>()
                .ForMember(dest => dest.BrandSupplierDTOs, act => act.MapFrom(src => src.BrandSuppliers))
         .ForMember(dest => dest.InstrumentItemDTOs,act => act.MapFrom(src => src.InstrumentItems))
                .ForMember(dest => dest.EquipmentItemDTOs,act => act.MapFrom(src => src.EquipmentItems))
            .ForMember(dest => dest.PurchaseOrderDTOs,act => act.MapFrom(src => src.PurchaseOrders));
            CreateMap<Supplier, SupplierDTO>()
               .ForMember(dest => dest.BrandSupplierDTOs, act => { act.PreCondition(src => (src.BrandSuppliers != null)); act.MapFrom(src => src.BrandSuppliers); })
               .ForMember(dest => dest.VendorCodeDTO, act => { act.PreCondition(src => (src.VendorCode != null)); act.MapFrom(src => src.VendorCode); })
               .ForMember(dest => dest.TaxCodeLDDTO, act => { act.PreCondition(src => (src.TaxCodeLD != null)); act.MapFrom(src => src.TaxCodeLD); })
               .ForMember(dest => dest.TaxCodeLPDTO, act => { act.PreCondition(src => (src.TaxCodeLP != null)); act.MapFrom(src => src.TaxCodeLP); })
                .ForMember(dest => dest.EquipmentItemDTOs,act => act.MapFrom(src => src.EquipmentItems))
                .ForMember(dest => dest.InstrumentItemDTOs,act => act.MapFrom(src => src.InstrumentItems))
            .ForMember(dest => dest.PurchaseOrderDTOs,act => act.MapFrom(src => src.PurchaseOrders));

            CreateMap<EquipmentType, EquipmentTypeDTO>()
                  .ForMember(dest => dest.EquipmentTypeSubDTOs, act => act.MapFrom(src => src.EquipmentTypeSubs))
                   .ForMember(dest => dest.EquipmentItemDTOs,act => act.MapFrom(src => src.EquipmentItems));
            CreateMap<EquipmentTypeSub, EquipmentTypeSubDTO>()
                .ForMember(dest => dest.EquipmentTypeDTO, act => act.MapFrom(src => src.EquipmentType))
                .ForMember(dest => dest.EquipmentItemDTOs,act => act.MapFrom(src => src.EquipmentItems));

            CreateMap<Material, MaterialDTO>()
                .ForMember(dest => dest.EquipmentItemInnerMaterialDTOs, act =>act.MapFrom(src => src.EquipmentItemInnerMaterials))
                .ForMember(dest => dest.EquipmentItemOuterMaterialDTOs, act => act.MapFrom(src => src.EquipmentItemOuterMaterials))
                 .ForMember(dest => dest.InstrumentItemInnerMaterialDTOs, act =>act.MapFrom(src => src.InstrumentItemInnerMaterials))
                .ForMember(dest => dest.InstrumentItemOuterMaterialDTOs, act =>act.MapFrom(src => src.InstrumentItemOuterMaterials))
                .ForMember(dest => dest.PipingItemsDTO, act => act.MapFrom(src => src.PipingItems))
                .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles));


            CreateMap<AlterationItem, AlterationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<ContingencyItem, ContingencyItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<EHSItem, EHSItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<ElectricalItem, ElectricalItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<EngineeringCostItem, EngineeringCostItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));


            CreateMap<EquipmentItem, EquipmentItemDTO>()
                 .ForMember(dest => dest.GasketDTO, act => act.MapFrom(src => src.Gasket))
                 .ForMember(dest => dest.InnerMaterialDTO, act => act.MapFrom(src => src.eInnerMaterial))
                 .ForMember(dest => dest.OuterMaterialDTO, act => act.MapFrom(src => src.eOuterMaterial))
                 .ForMember(dest => dest.EquipmentTypeDTO, act => act.MapFrom(src => src.EquipmentType))
                 .ForMember(dest => dest.EquipmentTypeSubDTO, act => act.MapFrom(src => src.EquipmentTypeSub))
                 .ForMember(dest => dest.SupplierDTO, act => act.MapFrom(src => src.Supplier))
                 .ForMember(dest => dest.ProcessConditionDTO, act => act.MapFrom(src => src.ProcessCondition))
                 .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles));

            CreateMap<FoundationItem, FoundationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<MeasuredVariable, MeasuredVariableDTO>()
                .ForMember(dest => dest.InstrumentItemDTOs, act => act.MapFrom(src => src.InstrumentItems));
            CreateMap<MeasuredVariableModifier, MeasuredVariableModifierDTO>()
                .ForMember(dest => dest.InstrumentItemDTOs, act => act.MapFrom(src => src.InstrumentItems));
            CreateMap<DeviceFunction, DeviceFunctionDTO>()
                  .ForMember(dest => dest.InstrumentItemDTOs, act => act.MapFrom(src => src.InstrumentItems));
            CreateMap<DeviceFunctionModifier, DeviceFunctionModifierDTO>()
                  .ForMember(dest => dest.InstrumentItemDTOs, act => act.MapFrom(src => src.InstrumentItems));
            CreateMap<Readout, ReadoutDTO>()
                  .ForMember(dest => dest.InstrumentItemDTOs, act => act.MapFrom(src => src.InstrumentItems));

            CreateMap<InstrumentItem, InstrumentItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
               .ForMember(dest => dest.GasketDTO, act => act.MapFrom(src => src.Gasket))
               .ForMember(dest => dest.InnerMaterialDTO, act => act.MapFrom(src => src.iInnerMaterial))
               .ForMember(dest => dest.OuterMaterialDTO, act => act.MapFrom(src => src.iOuterMaterial))
               .ForMember(dest => dest.MeasuredVariableDTO, act => act.MapFrom(src => src.MeasuredVariable))
               .ForMember(dest => dest.MeasuredVariableModifierDTO, act => act.MapFrom(src => src.MeasuredVariableModifier))
               .ForMember(dest => dest.DeviceFunctionDTO, act => act.MapFrom(src => src.DeviceFunction))
               .ForMember(dest => dest.DeviceFunctionModifierDTO, act => act.MapFrom(src => src.DeviceFunctionModifier))
               .ForMember(dest => dest.ReadoutDTO, act => act.MapFrom(src => src.Readout))
               .ForMember(dest => dest.SupplierDTO, act => act.MapFrom(src => src.Supplier))
               .ForMember(dest => dest.BrandDTO, act => act.MapFrom(src => src.Brand))
               .ForMember(dest => dest.ProcessFluidDTO, act => act.MapFrom(src => src.ProcessFluid))
                .ForMember(dest => dest.ProcessConditionDTO, act => act.MapFrom(src => src.ProcessCondition))
                 .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles));
            CreateMap<InsulationItem, InsulationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<PaintingItem, PaintingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<PipingItem, PipingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems))
               .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles))
               .ForMember(dest => dest.PipeAccesorysDTO, act => act.MapFrom(src => src.PipeAccesorys))
               .ForMember(dest => dest.MaterialDTO, act => act.MapFrom(src => src.Material))
               .ForMember(dest => dest.ProcessFluidDTO, act => act.MapFrom(src => src.ProcessFluid))
               .ForMember(dest => dest.DiameterDTO, act => act.MapFrom(src => src.Diameter))
               .ForMember(dest => dest.NozzleStartDTO, act => act.MapFrom(src => src.NozzleStart))
               .ForMember(dest => dest.NozzleFinishDTO, act => act.MapFrom(src => src.NozzleFinish))
               .ForMember(dest => dest.StartMWOItemDTO, act => act.MapFrom(src => src.StartMWOItem))
               .ForMember(dest => dest.FinishMWOItemDTO, act => act.MapFrom(src => src.FinishMWOItem))
               .ForMember(dest => dest.PipeClassDTO, act => act.MapFrom(src => src.PipeClass));
            CreateMap<StructuralItem, StructuralItemDTO>()
              .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<TaxesItem, TaxesItemDTO>()
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<TestingItem, TestingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));


            CreateMap<TestingItem, TestingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));


            CreateMap<PurchaseOrderMWOItem, PurchaseOrderMWOItemDTO>()
                .ForMember(dest => dest.PurchaseOrderDTO, act => act.MapFrom(src => src.PurchaseOrder))
                .ForMember(dest => dest.MWOItemDTO, act => act.MapFrom(src => src.MWOItem));

            CreateMap<PurchaseOrder, PurchaseOrderDTO>()
                .ForMember(dest => dest.PurchaseOrderMWOItemDTOs, act => act.MapFrom(src => src.PurchaseOrderMWOItems))
                .ForMember(dest => dest.DownPaymentDTOs, act => act.MapFrom(src => src.DownPayments))
                .ForMember(dest => dest.SupplierDTO, act => act.MapFrom(src => src.Supplier))
                .ForMember(dest => dest.BrandDTO, act => act.MapFrom(src => src.Brand));


            CreateMap<Chapter, ChapterDTO>()
             .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));
            CreateMap<UnitaryBasePrize, UnitaryBasePrizeDTO>()
                 .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));

            CreateMap<MWOItem, MWOItemDTO>()
                .ForMember(dest => dest.PurchaseOrderMWOItemDTOs, act => act.MapFrom(src => src.PurchaseOrderMWOItems))
                .ForMember(dest => dest.ChapterDTO, act => act.MapFrom(src => src.Chapter))
                .ForMember(dest => dest.MWODTO, act => act.MapFrom(src => src.MWO))
                .ForMember(dest => dest.UnitaryBasePrizeDTO, act => act.MapFrom(src => src.UnitaryBasePrize))
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
               .ForMember(dest => dest.TestingItemDTO, act => { act.PreCondition(src => (src.TestingItem != null)); act.MapFrom(src => src.TestingItem); });

            CreateMap<MWO, MWODTO>()
                 .ForMember(dest => dest.MWOTypeDTO, act => act.MapFrom(src => src.MWOType))
                .ForMember(dest => dest.MWOItemDTOs, act => act.MapFrom(src => src.MWOItems));


            CreateMap<MWOType, MWOTypeDTO>()
                .ForMember(dest => dest.MWODTOs, act => act.MapFrom(src => src.MWOs));

        }

      
        void DTOtoEntity()
        {
            CreateMap<AuditableEntityDTO, AuditableEntity>().ForMember(dest => dest.Id,
             act => act.Ignore());
            CreateMap<ProcessConditionDTO, ProcessCondition>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<PipeClassDTO, PipeClass>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<PipeAccesoryDTO, PipeAccesory>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<NozzleDTO, Nozzle>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<PipeDiameterDTO, PipeDiameter>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<ProcessFluidDTO, ProcessFluid>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<UnitDTO, Unit>().ForPath(s => s.Id, opt => opt.Ignore());

            CreateMap<DownPaymentDTO, DownPayment>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<TaxCodeLPDTO, TaxCodeLP>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<TaxCodeLDDTO, TaxCodeLD>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<VendorCodeDTO, VendorCode>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<GasketDTO, Gasket>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<MaterialDTO, Material>().ForPath(s => s.Id, opt => opt.Ignore());

            CreateMap<BrandDTO, Brand>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<SupplierDTO, Supplier>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<BrandSupplierDTO, BrandSupplier>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<EquipmentTypeDTO, EquipmentType>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<EquipmentTypeSubDTO, EquipmentTypeSub>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<AlterationItemDTO, AlterationItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<ContingencyItemDTO, ContingencyItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<EHSItemDTO, EHSItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<ElectricalItemDTO, ElectricalItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<EngineeringCostItemDTO, EngineeringCostItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<EquipmentItemDTO, EquipmentItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<FoundationItemDTO, FoundationItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<InstrumentItemDTO, InstrumentItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<InsulationItemDTO, InsulationItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<PaintingItemDTO, PaintingItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<PipingItemDTO, PipingItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<StructuralItemDTO, StructuralItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<TaxesItemDTO, TaxesItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<TestingItemDTO, TestingItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<PurchaseOrderDTO, PurchaseOrder>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<ChapterDTO, Chapter>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<UnitaryBasePrizeDTO, UnitaryBasePrize>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<MWOItemDTO, MWOItem>()
                 .ForMember(dest => dest.ChapterId,
             act => act.MapFrom(src => src.ChapterDTO.Id))
              .ForMember(dest => dest.MWOId,
             act => act.MapFrom(src => src.MWODTO!.Id))
              .ForMember(dest => dest.EquipmentItem,
             act => act.MapFrom(src => src.EquipmentItemDTO))
              .ForPath(s => s.Id, opt => opt.Ignore());

            CreateMap<MWODTO, MWO>().ForMember(dest => dest.MWOTypeId,
             act => act.MapFrom(src => src.MWOTypeDTO!.Id))
                .ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<MWOTypeDTO, MWOType>().ForPath(s => s.Id, opt => opt.Ignore());

            CreateMap<MeasuredVariableDTO, MeasuredVariable>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<MeasuredVariableModifierDTO, MeasuredVariableModifier>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<DeviceFunctionDTO, DeviceFunction>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<DeviceFunctionModifierDTO, DeviceFunctionModifier>().ForPath(s => s.Id, opt => opt.Ignore());
            CreateMap<ReadoutDTO, Readout>().ForPath(s => s.Id, opt => opt.Ignore());
        }

    }
}
