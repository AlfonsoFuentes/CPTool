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
            CreateMap<EquipmentType, EquipmentTypeDTO>()
                   .ForMember(dest => dest.EquipmentTypeSubsDTO, act => act.MapFrom(src => src.EquipmentTypeSubs))
                    .ForMember(dest => dest.EquipmentItemsDTO, act => act.MapFrom(src => src.EquipmentItems));
            CreateMap<EquipmentTypeSub, EquipmentTypeSubDTO>()
                //.ForMember(dest => dest.EquipmentTypeDTO, act => act.MapFrom(src => src.EquipmentType))
                .ForMember(dest => dest.EquipmentItemsDTO, act => act.MapFrom(src => src.EquipmentItems));



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
                .ForMember(dest => dest.EquipmentItemsDTO, act => act.MapFrom(src => src.EquipmentItems))
                .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems))
                .ForMember(dest => dest.PipingItemsDTO, act => act.MapFrom(src => src.PipingItems));


            CreateMap<DownPayment, DownPaymentDTO>()
                .ForMember(dest => dest.PurchaseOrderDTO, act => act.MapFrom(src => src.PurchaseOrder));

            CreateMap<TaxCodeLP, TaxCodeLPDTO>()
                .ForMember(dest => dest.SuppliersDTO, act => act.MapFrom(src => src.Suppliers));
            CreateMap<TaxCodeLD, TaxCodeLDDTO>()
            .ForMember(dest => dest.SuppliersDTO, act => act.MapFrom(src => src.Suppliers));
            CreateMap<VendorCode, VendorCodeDTO>()
               .ForMember(dest => dest.SuppliersDTO, act => act.MapFrom(src => src.Suppliers));
            CreateMap<Gasket, GasketDTO>()
                 .ForMember(dest => dest.EquipmentItemsDTO, act => act.MapFrom(src => src.EquipmentItems))
                .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems))
                .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles));

            CreateMap<BrandSupplier, BrandSupplierDTO>()
               .ForMember(dest => dest.BrandDTO, act => act.MapFrom(src => src.Brand))
              .ForMember(dest => dest.SupplierDTO, act => act.MapFrom(src => src.Supplier));
            CreateMap<Brand, BrandDTO>()
                .ForMember(dest => dest.BrandSuppliersDTO, act => act.MapFrom(src => src.BrandSuppliers))
         .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems))
                .ForMember(dest => dest.EquipmentItemsDTO, act => act.MapFrom(src => src.EquipmentItems))
            .ForMember(dest => dest.PurchaseOrdersDTO, act => act.MapFrom(src => src.PurchaseOrders));
            CreateMap<Supplier, SupplierDTO>()
               .ForMember(dest => dest.BrandSuppliersDTO, act => act.MapFrom(src => src.BrandSuppliers))
               .ForMember(dest => dest.VendorCodeDTO, act => act.MapFrom(src => src.VendorCode))
               .ForMember(dest => dest.TaxCodeLDDTO, act => act.MapFrom(src => src.TaxCodeLD))
               .ForMember(dest => dest.TaxCodeLPDTO, act => act.MapFrom(src => src.TaxCodeLP))
                .ForMember(dest => dest.EquipmentItemsDTO, act => act.MapFrom(src => src.EquipmentItems))
                .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems))
            .ForMember(dest => dest.PurchaseOrdersDTO, act => act.MapFrom(src => src.PurchaseOrders));



            CreateMap<Material, MaterialDTO>()
                .ForMember(dest => dest.EquipmentItemInnerMaterialsDTO, act => act.MapFrom(src => src.EquipmentItemInnerMaterials))
                .ForMember(dest => dest.EquipmentItemOuterMaterialsDTO, act => act.MapFrom(src => src.EquipmentItemOuterMaterials))
                 .ForMember(dest => dest.InstrumentItemInnerMaterialsDTO, act => act.MapFrom(src => src.InstrumentItemInnerMaterials))
                .ForMember(dest => dest.InstrumentItemOuterMaterialsDTO, act => act.MapFrom(src => src.InstrumentItemOuterMaterials))
                .ForMember(dest => dest.PipingItemsDTO, act => act.MapFrom(src => src.PipingItems))
                .ForMember(dest => dest.NozzlesDTO, act => act.MapFrom(src => src.Nozzles));


            CreateMap<AlterationItem, AlterationItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<ContingencyItem, ContingencyItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<EHSItem, EHSItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<ElectricalItem, ElectricalItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<EngineeringCostItem, EngineeringCostItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));


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
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<MeasuredVariable, MeasuredVariableDTO>()
                .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems));
            CreateMap<MeasuredVariableModifier, MeasuredVariableModifierDTO>()
                .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems));
            CreateMap<DeviceFunction, DeviceFunctionDTO>()
                  .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems));
            CreateMap<DeviceFunctionModifier, DeviceFunctionModifierDTO>()
                  .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems));
            CreateMap<Readout, ReadoutDTO>()
                  .ForMember(dest => dest.InstrumentItemsDTO, act => act.MapFrom(src => src.InstrumentItems));

            CreateMap<InstrumentItem, InstrumentItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems))
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
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<PaintingItem, PaintingItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<PipingItem, PipingItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems))
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
              .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<TaxesItem, TaxesItemDTO>()
                .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<TestingItem, TestingItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));


            CreateMap<TestingItem, TestingItemDTO>()
               .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));


            CreateMap<PurchaseOrderMWOItem, PurchaseOrderMWOItemDTO>()
                .ForMember(dest => dest.PurchaseOrderDTO, act => act.MapFrom(src => src.PurchaseOrder))
                .ForMember(dest => dest.MWOItemDTO, act => act.MapFrom(src => src.MWOItem));

            CreateMap<PurchaseOrder, PurchaseOrderDTO>()
                .ForMember(dest => dest.PurchaseOrderMWOItemsDTO, act => act.MapFrom(src => src.PurchaseOrderMWOItems))
                .ForMember(dest => dest.DownPaymentsDTO, act => act.MapFrom(src => src.DownPayments))
                .ForMember(dest => dest.SupplierDTO, act => act.MapFrom(src => src.Supplier))
                .ForMember(dest => dest.BrandDTO, act => act.MapFrom(src => src.Brand));


            CreateMap<Chapter, ChapterDTO>()
             .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));
            CreateMap<UnitaryBasePrize, UnitaryBasePrizeDTO>()
                 .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));

            CreateMap<MWOItem, MWOItemDTO>()
                .ForMember(dest => dest.PurchaseOrderMWOItemsDTO, act => act.MapFrom(src => src.PurchaseOrderMWOItems))
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
                .ForMember(dest => dest.MWOItemsDTO, act => act.MapFrom(src => src.MWOItems));


            CreateMap<MWOType, MWOTypeDTO>()
                .ForMember(dest => dest.MWOsDTO, act => act.MapFrom(src => src.MWOs));

        }

        void DTOtoEntity()
        {
            CreateMap<EquipmentTypeDTO, EquipmentType>()
                 .ForMember(dest => dest.EquipmentTypeSubs, act => act.MapFrom(src => src.EquipmentTypeSubsDTO))
                 .ForMember(dest => dest.EquipmentItems, act => act.MapFrom(src => src.EquipmentItemsDTO));
            CreateMap<EquipmentTypeSubDTO, EquipmentTypeSub>()
                //.ForMember(dest => dest.EquipmentType, act => act.MapFrom(src => src.EquipmentTypeDTO))
                .ForMember(dest => dest.EquipmentItems, act => act.MapFrom(src => src.EquipmentItemsDTO));

            CreateMap<ProcessConditionDTO, ProcessCondition>()
              .ForMember(dest => dest.PipeAccesorys, act => act.MapFrom(src => src.PipeAccesorysDTO))
              .ForMember(dest => dest.EquipmentItems, act => act.MapFrom(src => src.EquipmentItemsDTO))
              .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO))
              .ForMember(dest => dest.Pressure, act => act.MapFrom(src => src.PressureDTO))
              .ForMember(dest => dest.Temperature, act => act.MapFrom(src => src.TemperatureDTO))
              .ForMember(dest => dest.MassFlow, act => act.MapFrom(src => src.MassFlowDTO))
              .ForMember(dest => dest.VolumetricFlow, act => act.MapFrom(src => src.VolumetricFlowDTO))
              .ForMember(dest => dest.Density, act => act.MapFrom(src => src.DensityDTO))
              .ForMember(dest => dest.Viscosity, act => act.MapFrom(src => src.ViscosityDTO))
              .ForMember(dest => dest.EnthalpyFlow, act => act.MapFrom(src => src.EnthalpyFlowDTO))
              .ForMember(dest => dest.SpecificEnthalpy, act => act.MapFrom(src => src.SpecificEnthalpyDTO))
              .ForMember(dest => dest.ThermalConductivity, act => act.MapFrom(src => src.ThermalConductivityDTO))
              .ForMember(dest => dest.SpecificCp, act => act.MapFrom(src => src.SpecificCpDTO));

            CreateMap<ConnectionTypeDTO, ConnectionType>()
               .ForMember(dest => dest.Nozzles, act => act.MapFrom(src => src.NozzlesDTO));
            CreateMap<PipeClassDTO, PipeClass>()
               .ForMember(dest => dest.PipingItems, act => act.MapFrom(src => src.PipingItemsDTO))
                .ForMember(dest => dest.Nozzles, act => act.MapFrom(src => src.NozzlesDTO));
            CreateMap<PipeAccesoryDTO, PipeAccesory>()
                .ForMember(dest => dest.Nozzles, act => act.MapFrom(src => src.NozzlesDTO))
                .ForMember(dest => dest.PipingItem, act => act.MapFrom(src => src.PipingItemDTO))
                .ForMember(dest => dest.ProcessCondition, act => act.MapFrom(src => src.ProcessConditionDTO))
                .ForMember(dest => dest.Reynold, act => act.MapFrom(src => src.ReynoldDTO))
                .ForMember(dest => dest.LevelInlet, act => act.MapFrom(src => src.LevelInletDTO))
                .ForMember(dest => dest.LevelOutlet, act => act.MapFrom(src => src.LevelOutletDTO))
                .ForMember(dest => dest.FrictionDropPressure, act => act.MapFrom(src => src.FrictionDropPressureDTO))
                .ForMember(dest => dest.OverallDropPressure, act => act.MapFrom(src => src.OverallDropPressureDTO))
                .ForMember(dest => dest.ElevationChange, act => act.MapFrom(src => src.ElevationChangeDTO))
                .ForMember(dest => dest.Friction, act => act.MapFrom(src => src.FrictionDTO));
            CreateMap<NozzleDTO, Nozzle>()
                .ForMember(dest => dest.StartPipingItems, act => act.MapFrom(src => src.StartPipingItemsDTO))
                .ForMember(dest => dest.FinishPipingItems, act => act.MapFrom(src => src.FinishPipingItemsDTO))
                .ForMember(dest => dest.PipeClass, act => act.MapFrom(src => src.PipeClassDTO))
                .ForMember(dest => dest.PipeDiameter, act => act.MapFrom(src => src.PipeDiameterDTO))
                .ForMember(dest => dest.ConnectionType, act => act.MapFrom(src => src.ConnectionTypeDTO))
                .ForMember(dest => dest.Gasket, act => act.MapFrom(src => src.GasketDTO))
                .ForMember(dest => dest.Material, act => act.MapFrom(src => src.MaterialDTO))
                .ForMember(dest => dest.PipeAccesory, act => act.MapFrom(src => src.PipeAccesoryDTO))
                .ForMember(dest => dest.EquipmentItem, act => act.MapFrom(src => src.EquipmentItemDTO))
                .ForMember(dest => dest.InstrumentItem, act => act.MapFrom(src => src.InstrumentItemDTO))
                .ForMember(dest => dest.PipingItem, act => act.MapFrom(src => src.PipingItemDTO));
            CreateMap<PipeDiameterDTO, PipeDiameter>()
                .ForMember(dest => dest.PipingItems, act => act.MapFrom(src => src.PipingItemsDTO))
                .ForMember(dest => dest.Nozzles, act => act.MapFrom(src => src.NozzlesDTO))
                .ForMember(dest => dest.OD, act => act.MapFrom(src => src.ODDTO))
                .ForMember(dest => dest.ID, act => act.MapFrom(src => src.IDDTO))
                .ForMember(dest => dest.Thickness, act => act.MapFrom(src => src.ThicknessDTO));
            CreateMap<UnitDTO, Unit>()
                .ForMember(dest => dest.ODs, act => act.MapFrom(src => src.ODsDTO))
                .ForMember(dest => dest.IDs, act => act.MapFrom(src => src.IDsDTO))
                .ForMember(dest => dest.Thicknesss, act => act.MapFrom(src => src.ThicknesssDTO))
                .ForMember(dest => dest.SpecificCps, act => act.MapFrom(src => src.SpecificCpsDTO))
                .ForMember(dest => dest.ThermalConductivitys, act => act.MapFrom(src => src.ThermalConductivitysDTO))
                .ForMember(dest => dest.SpecificEnthalpys, act => act.MapFrom(src => src.SpecificEnthalpysDTO))
                .ForMember(dest => dest.EnthalpyFlows, act => act.MapFrom(src => src.EnthalpyFlowsDTO))
                .ForMember(dest => dest.Viscositys, act => act.MapFrom(src => src.ViscositysDTO))
                .ForMember(dest => dest.Densitys, act => act.MapFrom(src => src.DensitysDTO))
                .ForMember(dest => dest.VolumetricFlows, act => act.MapFrom(src => src.VolumetricFlowsDTO))
                .ForMember(dest => dest.MassFlows, act => act.MapFrom(src => src.MassFlowsDTO))
                .ForMember(dest => dest.Temperatures, act => act.MapFrom(src => src.TemperaturesDTO))
                .ForMember(dest => dest.Pressures, act => act.MapFrom(src => src.PressuresDTO))
                .ForMember(dest => dest.FrictionPipeAccesorys, act => act.MapFrom(src => src.FrictionPipeAccesorysDTO))
                .ForMember(dest => dest.ReynoldPipeAccesorys, act => act.MapFrom(src => src.ReynoldPipeAccesorysDTO))
                .ForMember(dest => dest.LevelInletPipeAccesorys, act => act.MapFrom(src => src.LevelInletPipeAccesorysDTO))
                .ForMember(dest => dest.LevelOutletPipeAccesorys, act => act.MapFrom(src => src.LevelOutletPipeAccesorysDTO))
                .ForMember(dest => dest.FrictionDropPressurePipeAccesorys, act => act.MapFrom(src => src.FrictionDropPressurePipeAccesorysDTO))
                .ForMember(dest => dest.OverallDropPressurePipeAccesorys, act => act.MapFrom(src => src.OverallDropPressurePipeAccesorysDTO))
                .ForMember(dest => dest.ElevationChangePipeAccesorys, act => act.MapFrom(src => src.ElevationChangePipeAccesorysDTO));

            CreateMap<ProcessFluidDTO, ProcessFluid>()
                .ForMember(dest => dest.EquipmentItems, act => act.MapFrom(src => src.EquipmentItemsDTO))
                .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO))
                .ForMember(dest => dest.PipingItems, act => act.MapFrom(src => src.PipingItemsDTO));


            CreateMap<DownPaymentDTO, DownPayment>()
                .ForMember(dest => dest.PurchaseOrder, act => act.MapFrom(src => src.PurchaseOrderDTO));

            CreateMap<TaxCodeLPDTO, TaxCodeLP>()
                .ForMember(dest => dest.Suppliers, act => act.MapFrom(src => src.SuppliersDTO));
            CreateMap<TaxCodeLDDTO, TaxCodeLD>()
            .ForMember(dest => dest.Suppliers, act => act.MapFrom(src => src.SuppliersDTO));
            CreateMap<VendorCodeDTO, VendorCode>()
               .ForMember(dest => dest.Suppliers, act => act.MapFrom(src => src.SuppliersDTO));
            CreateMap<GasketDTO, Gasket>()
                 .ForMember(dest => dest.EquipmentItems, act => act.MapFrom(src => src.EquipmentItemsDTO))
                .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO))
                .ForMember(dest => dest.Nozzles, act => act.MapFrom(src => src.NozzlesDTO));

            CreateMap<BrandSupplierDTO, BrandSupplier>()
               .ForMember(dest => dest.Brand, act => act.MapFrom(src => src.BrandDTO))
              .ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.SupplierDTO));
            CreateMap<BrandDTO, Brand>()
                .ForMember(dest => dest.BrandSuppliers, act => act.MapFrom(src => src.BrandSuppliersDTO))
         .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO))
                .ForMember(dest => dest.EquipmentItems, act => act.MapFrom(src => src.EquipmentItemsDTO))
            .ForMember(dest => dest.PurchaseOrders, act => act.MapFrom(src => src.PurchaseOrdersDTO));
            CreateMap<SupplierDTO, Supplier>()
                 .ForMember(dest => dest.BrandSuppliers, act => act.MapFrom(src => src.BrandSuppliersDTO))
                 .ForMember(dest => dest.VendorCode, act => act.MapFrom(src => src.VendorCodeDTO))
                 .ForMember(dest => dest.TaxCodeLD, act => act.MapFrom(src => src.TaxCodeLDDTO))
                 .ForMember(dest => dest.TaxCodeLP, act => act.MapFrom(src => src.TaxCodeLPDTO))
                 .ForMember(dest => dest.EquipmentItems, act => act.MapFrom(src => src.EquipmentItemsDTO))
                 .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO))
                 .ForMember(dest => dest.PurchaseOrders, act => act.MapFrom(src => src.PurchaseOrdersDTO));



            CreateMap<MaterialDTO, Material>()
                .ForMember(dest => dest.EquipmentItemInnerMaterials, act => act.MapFrom(src => src.EquipmentItemInnerMaterialsDTO))
                .ForMember(dest => dest.EquipmentItemOuterMaterials, act => act.MapFrom(src => src.EquipmentItemOuterMaterialsDTO))
                 .ForMember(dest => dest.InstrumentItemInnerMaterials, act => act.MapFrom(src => src.InstrumentItemInnerMaterialsDTO))
                .ForMember(dest => dest.InstrumentItemOuterMaterials, act => act.MapFrom(src => src.InstrumentItemOuterMaterialsDTO))
                .ForMember(dest => dest.PipingItems, act => act.MapFrom(src => src.PipingItemsDTO))
                .ForMember(dest => dest.Nozzles, act => act.MapFrom(src => src.NozzlesDTO));


            CreateMap<AlterationItemDTO, AlterationItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<ContingencyItemDTO, ContingencyItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<EHSItemDTO, EHSItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<ElectricalItemDTO, ElectricalItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<EngineeringCostItemDTO, EngineeringCostItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));


            CreateMap<EquipmentItemDTO, EquipmentItem>()
                 .ForMember(dest => dest.Gasket, act => act.MapFrom(src => src.GasketDTO))
                 .ForMember(dest => dest.eInnerMaterial, act => act.MapFrom(src => src.InnerMaterialDTO))
                 .ForMember(dest => dest.eOuterMaterial, act => act.MapFrom(src => src.OuterMaterialDTO))
                 .ForMember(dest => dest.EquipmentType, act => act.MapFrom(src => src.EquipmentTypeDTO))
                 .ForMember(dest => dest.EquipmentTypeSub, act => act.MapFrom(src => src.EquipmentTypeSubDTO))
                 .ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.SupplierDTO))
                 .ForMember(dest => dest.ProcessCondition, act => act.MapFrom(src => src.ProcessConditionDTO))
                 .ForMember(dest => dest.Nozzles, act => act.MapFrom(src => src.NozzlesDTO));

            CreateMap<FoundationItemDTO, FoundationItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<MeasuredVariableDTO, MeasuredVariable>()
                .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO));
            CreateMap<MeasuredVariableModifierDTO, MeasuredVariableModifier>()
                .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO));
            CreateMap<DeviceFunctionDTO, DeviceFunction>()
                  .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO));
            CreateMap<DeviceFunctionModifierDTO, DeviceFunctionModifier>()
                  .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO));
            CreateMap<ReadoutDTO, Readout>()
                  .ForMember(dest => dest.InstrumentItems, act => act.MapFrom(src => src.InstrumentItemsDTO));

            CreateMap<InstrumentItemDTO, InstrumentItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO))
               .ForMember(dest => dest.Gasket, act => act.MapFrom(src => src.GasketDTO))
               .ForMember(dest => dest.iInnerMaterial, act => act.MapFrom(src => src.InnerMaterialDTO))
               .ForMember(dest => dest.iOuterMaterial, act => act.MapFrom(src => src.OuterMaterialDTO))
               .ForMember(dest => dest.MeasuredVariable, act => act.MapFrom(src => src.MeasuredVariableDTO))
               .ForMember(dest => dest.MeasuredVariableModifier, act => act.MapFrom(src => src.MeasuredVariableModifierDTO))
               .ForMember(dest => dest.DeviceFunction, act => act.MapFrom(src => src.DeviceFunctionDTO))
               .ForMember(dest => dest.DeviceFunctionModifier, act => act.MapFrom(src => src.DeviceFunctionModifierDTO))
               .ForMember(dest => dest.Readout, act => act.MapFrom(src => src.ReadoutDTO))
               .ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.SupplierDTO))
               .ForMember(dest => dest.Brand, act => act.MapFrom(src => src.BrandDTO))
               .ForMember(dest => dest.ProcessFluid, act => act.MapFrom(src => src.ProcessFluidDTO))
                .ForMember(dest => dest.ProcessCondition, act => act.MapFrom(src => src.ProcessConditionDTO))
                 .ForMember(dest => dest.Nozzles, act => act.MapFrom(src => src.NozzlesDTO));
            CreateMap<InsulationItemDTO, InsulationItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<PaintingItemDTO, PaintingItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<PipingItemDTO, PipingItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO))
               .ForMember(dest => dest.Nozzles, act => act.MapFrom(src => src.NozzlesDTO))
               .ForMember(dest => dest.PipeAccesorys, act => act.MapFrom(src => src.PipeAccesorysDTO))
               .ForMember(dest => dest.Material, act => act.MapFrom(src => src.MaterialDTO))
               .ForMember(dest => dest.ProcessFluid, act => act.MapFrom(src => src.ProcessFluidDTO))
               .ForMember(dest => dest.Diameter, act => act.MapFrom(src => src.DiameterDTO))
               .ForMember(dest => dest.NozzleStart, act => act.MapFrom(src => src.NozzleStartDTO))
               .ForMember(dest => dest.NozzleFinish, act => act.MapFrom(src => src.NozzleFinishDTO))
               .ForMember(dest => dest.StartMWOItem, act => act.MapFrom(src => src.StartMWOItemDTO))
               .ForMember(dest => dest.FinishMWOItem, act => act.MapFrom(src => src.FinishMWOItemDTO))
               .ForMember(dest => dest.PipeClass, act => act.MapFrom(src => src.PipeClassDTO));
            CreateMap<StructuralItemDTO, StructuralItem>()
              .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<TaxesItemDTO, TaxesItem>()
                .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<TestingItemDTO, TestingItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));


            CreateMap<TestingItemDTO, TestingItem>()
               .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));


            CreateMap<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem>()
                .ForMember(dest => dest.PurchaseOrder, act => act.MapFrom(src => src.PurchaseOrderDTO))
                .ForMember(dest => dest.MWOItem, act => act.MapFrom(src => src.MWOItemDTO));

            CreateMap<PurchaseOrderDTO, PurchaseOrder>()
                .ForMember(dest => dest.PurchaseOrderMWOItems, act => act.MapFrom(src => src.PurchaseOrderMWOItemsDTO))
                .ForMember(dest => dest.DownPayments, act => act.MapFrom(src => src.DownPaymentsDTO))
                .ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.SupplierDTO))
                .ForMember(dest => dest.Brand, act => act.MapFrom(src => src.BrandDTO));


            CreateMap<ChapterDTO, Chapter>()
             .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));
            CreateMap<UnitaryBasePrizeDTO, UnitaryBasePrize>()
                 .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));

            CreateMap<MWOItemDTO, MWOItem>()
                .ForMember(dest => dest.PurchaseOrderMWOItems, act => act.MapFrom(src => src.PurchaseOrderMWOItemsDTO))
                .ForMember(dest => dest.Chapter, act => act.MapFrom(src => src.ChapterDTO))
                .ForMember(dest => dest.MWO, act => act.MapFrom(src => src.MWODTO))
                .ForMember(dest => dest.UnitaryBasePrize, act => act.MapFrom(src => src.UnitaryBasePrizeDTO))

               .ForMember(dest => dest.AlterationItem, act => act.MapFrom(src => src.AlterationItemDTO))
               .ForMember(dest => dest.ContingencyItem, act => act.MapFrom(src => src.ContingencyItemDTO))
               .ForMember(dest => dest.EHSItem, act => act.MapFrom(src => src.EHSItemDTO))
               .ForMember(dest => dest.ElectricalItem, act => act.MapFrom(src => src.ElectricalItemDTO))
               .ForMember(dest => dest.EngineeringCostItem, act => act.MapFrom(src => src.EngineeringCostItemDTO))
               .ForMember(dest => dest.EquipmentItem, act => act.MapFrom(src => src.EquipmentItemDTO))
               .ForMember(dest => dest.FoundationItem, act => act.MapFrom(src => src.FoundationItemDTO))
               .ForMember(dest => dest.InstrumentItem, act => act.MapFrom(src => src.InstrumentItemDTO))
               .ForMember(dest => dest.InsulationItem, act => act.MapFrom(src => src.InsulationItemDTO))
               .ForMember(dest => dest.PaintingItem, act => act.MapFrom(src => src.PaintingItemDTO))
               .ForMember(dest => dest.PipingItem, act => act.MapFrom(src => src.PipingItemDTO))
               .ForMember(dest => dest.StructuralItem, act => act.MapFrom(src => src.StructuralItemDTO))
               .ForMember(dest => dest.TaxesItem, act => act.MapFrom(src => src.TaxesItemDTO))
               .ForMember(dest => dest.TestingItem, act => act.MapFrom(src => src.TestingItemDTO));
            ;
            CreateMap<MWODTO, MWO>()
                 .ForMember(dest => dest.MWOType, act => act.MapFrom(src => src.MWOTypeDTO))
                .ForMember(dest => dest.MWOItems, act => act.MapFrom(src => src.MWOItemsDTO));


            CreateMap<MWOTypeDTO, MWOType>()
                .ForMember(dest => dest.MWOs, act => act.MapFrom(src => src.MWOsDTO));

        }
        void DTOtoEntity2()
        {
            CreateMap<AuditableEntityDTO, AuditableEntity>().ForMember(dest => dest.Id,
             act => act.Ignore());
            CreateMap<ProcessConditionDTO, ProcessCondition>();
            CreateMap<PipeClassDTO, PipeClass>();
            CreateMap<PipeAccesoryDTO, PipeAccesory>();
            CreateMap<NozzleDTO, Nozzle>();
            CreateMap<PipeDiameterDTO, PipeDiameter>();
            CreateMap<ProcessFluidDTO, ProcessFluid>();
            CreateMap<UnitDTO, Unit>();

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
            CreateMap<MWOItemDTO, MWOItem>()
                 .ForMember(dest => dest.ChapterId, act => act.MapFrom(src => src.ChapterDTO.Id))
              .ForMember(dest => dest.MWOId, act => act.MapFrom(src => src.MWODTO!.Id))
              .ForMember(dest => dest.EquipmentItem,
             act => act.MapFrom(src => src.EquipmentItemDTO))
              ;

            CreateMap<MWODTO, MWO>().ForMember(dest => dest.MWOTypeId,
             act => act.MapFrom(src => src.MWOTypeDTO!.Id))
                ;
            CreateMap<MWOTypeDTO, MWOType>();

            CreateMap<MeasuredVariableDTO, MeasuredVariable>();
            CreateMap<MeasuredVariableModifierDTO, MeasuredVariableModifier>();
            CreateMap<DeviceFunctionDTO, DeviceFunction>();
            CreateMap<DeviceFunctionModifierDTO, DeviceFunctionModifier>();
            CreateMap<ReadoutDTO, Readout>();
        }

    }
}
