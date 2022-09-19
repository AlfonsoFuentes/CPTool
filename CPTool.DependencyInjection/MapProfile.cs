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
            CreateMap<ProcessCondition, ProcessConditionDTO>()
              .ForMember(dest => dest.PipeAccesorysDTO,
             act => { act.PreCondition(src => (src.PipeAccesorys != null)); act.MapFrom(src => src.PipeAccesorys); })
              .ForMember(dest => dest.EquipmentItemsDTO,
             act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); })
              .ForMember(dest => dest.InstrumentItemsDTO,
             act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); })
              .ForMember(dest => dest.PressureDTO,
             act => { act.PreCondition(src => (src.Pressure != null)); act.MapFrom(src => src.Pressure); })
              .ForMember(dest => dest.TemperatureDTO,
             act => { act.PreCondition(src => (src.Temperature != null)); act.MapFrom(src => src.Temperature); })
              .ForMember(dest => dest.MassFlowDTO,
             act => { act.PreCondition(src => (src.MassFlow != null)); act.MapFrom(src => src.MassFlow); })
              .ForMember(dest => dest.VolumetricFlowDTO,
             act => { act.PreCondition(src => (src.VolumetricFlow != null)); act.MapFrom(src => src.VolumetricFlow); })
              .ForMember(dest => dest.DensityDTO,
             act => { act.PreCondition(src => (src.Density != null)); act.MapFrom(src => src.Density); })
              .ForMember(dest => dest.ViscosityDTO,
             act => { act.PreCondition(src => (src.Viscosity != null)); act.MapFrom(src => src.Viscosity); })
              .ForMember(dest => dest.EnthalpyFlowDTO,
             act => { act.PreCondition(src => (src.EnthalpyFlow != null)); act.MapFrom(src => src.EnthalpyFlow); })
              .ForMember(dest => dest.SpecificEnthalpyDTO,
             act => { act.PreCondition(src => (src.SpecificEnthalpy != null)); act.MapFrom(src => src.SpecificEnthalpy); })
              .ForMember(dest => dest.ThermalConductivityDTO,
             act => { act.PreCondition(src => (src.ThermalConductivity != null)); act.MapFrom(src => src.ThermalConductivity); })
              .ForMember(dest => dest.SpecificCpDTO,
             act => { act.PreCondition(src => (src.SpecificCp != null)); act.MapFrom(src => src.SpecificCp); })
              .ForMember(dest => dest.ProcessFluidDTO,
             act => { act.PreCondition(src => (src.ProcessFluid != null)); act.MapFrom(src => src.ProcessFluid); });
            CreateMap<ConnectionType, ConnectionTypeDTO>()
               .ForMember(dest => dest.NozzlesDTO,
              act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); });
            CreateMap<PipeClass, PipeClassDTO>()
               .ForMember(dest => dest.PipingItemsDTO,
              act => { act.PreCondition(src => (src.PipingItems != null)); act.MapFrom(src => src.PipingItems); });
            CreateMap<PipeAccesory, PipeAccesoryDTO>()
                .ForMember(dest => dest.NozzlesDTO,
               act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); })
                .ForMember(dest => dest.PipingItemDTO,
               act => { act.PreCondition(src => (src.PipingItem != null)); act.MapFrom(src => src.PipingItem); })
                .ForMember(dest => dest.ProcessConditionDTO,
               act => { act.PreCondition(src => (src.ProcessCondition != null)); act.MapFrom(src => src.ProcessCondition); })
                .ForMember(dest => dest.ReynoldDTO,
               act => { act.PreCondition(src => (src.Reynold != null)); act.MapFrom(src => src.Reynold); })
                .ForMember(dest => dest.LevelInletDTO,
               act => { act.PreCondition(src => (src.LevelInlet != null)); act.MapFrom(src => src.LevelInlet); })
                .ForMember(dest => dest.LevelOutletDTO,
               act => { act.PreCondition(src => (src.LevelOutlet != null)); act.MapFrom(src => src.LevelOutlet); })
                .ForMember(dest => dest.FrictionDropPressureDTO,
               act => { act.PreCondition(src => (src.FrictionDropPressure != null)); act.MapFrom(src => src.FrictionDropPressure); })
                .ForMember(dest => dest.OverallDropPressureDTO,
               act => { act.PreCondition(src => (src.OverallDropPressure != null)); act.MapFrom(src => src.OverallDropPressure); })
                .ForMember(dest => dest.ElevationChangeDTO,
               act => { act.PreCondition(src => (src.ElevationChange != null)); act.MapFrom(src => src.ElevationChange); })
                .ForMember(dest => dest.FrictionDTO,
               act => { act.PreCondition(src => (src.Friction != null)); act.MapFrom(src => src.Friction); });
            CreateMap<Nozzle, NozzleDTO>()
                .ForMember(dest => dest.StartPipingItemsDTO,
               act => { act.PreCondition(src => (src.StartPipingItems != null)); act.MapFrom(src => src.StartPipingItems); })
                .ForMember(dest => dest.FinishPipingItemsDTO,
               act => { act.PreCondition(src => (src.FinishPipingItems != null)); act.MapFrom(src => src.FinishPipingItems); })
                .ForMember(dest => dest.PipeClassDTO,
               act => { act.PreCondition(src => (src.PipeClass != null)); act.MapFrom(src => src.PipeClass); })
                .ForMember(dest => dest.PipeDiameterDTO,
               act => { act.PreCondition(src => (src.PipeDiameter != null)); act.MapFrom(src => src.PipeDiameter); })
                .ForMember(dest => dest.ConnectionTypeDTO,
               act => { act.PreCondition(src => (src.ConnectionType != null)); act.MapFrom(src => src.ConnectionType); })
                .ForMember(dest => dest.GasketDTO,
               act => { act.PreCondition(src => (src.Gasket != null)); act.MapFrom(src => src.Gasket); })
                .ForMember(dest => dest.MaterialDTO,
               act => { act.PreCondition(src => (src.Material != null)); act.MapFrom(src => src.Material); })
                .ForMember(dest => dest.PipeAccesoryDTO,
               act => { act.PreCondition(src => (src.PipeAccesory != null)); act.MapFrom(src => src.PipeAccesory); })
                .ForMember(dest => dest.EquipmentItemDTO,
               act => { act.PreCondition(src => (src.EquipmentItem != null)); act.MapFrom(src => src.EquipmentItem); })
                .ForMember(dest => dest.InstrumentItemDTO,
               act => { act.PreCondition(src => (src.InstrumentItem != null)); act.MapFrom(src => src.InstrumentItem); })
                .ForMember(dest => dest.PipingItemDTO,
               act => { act.PreCondition(src => (src.PipingItem != null)); act.MapFrom(src => src.PipingItem); });
            CreateMap<PipeDiameter, PipeDiameterDTO>()
                .ForMember(dest => dest.PipingItemsDTO,
               act => { act.PreCondition(src => (src.PipingItems != null)); act.MapFrom(src => src.PipingItems); })
                .ForMember(dest => dest.NozzlesDTO,
               act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); })
                .ForMember(dest => dest.ODDTO,
               act => { act.PreCondition(src => (src.OD != null)); act.MapFrom(src => src.OD); })
                .ForMember(dest => dest.IDDTO,
               act => { act.PreCondition(src => (src.ID != null)); act.MapFrom(src => src.ID); })
                .ForMember(dest => dest.ThicknessDTO,
               act => { act.PreCondition(src => (src.Thickness != null)); act.MapFrom(src => src.Thickness); });
            CreateMap<Unit, UnitDTO>()
                .ForMember(dest => dest.ODsDTO,
               act => { act.PreCondition(src => (src.ODs != null)); act.MapFrom(src => src.ODs); })
                .ForMember(dest => dest.IDsDTO,
               act => { act.PreCondition(src => (src.IDs != null)); act.MapFrom(src => src.IDs); })
                .ForMember(dest => dest.ThicknesssDTO,
               act => { act.PreCondition(src => (src.Thicknesss != null)); act.MapFrom(src => src.Thicknesss); })
                .ForMember(dest => dest.SpecificCpsDTO,
               act => { act.PreCondition(src => (src.SpecificCps != null)); act.MapFrom(src => src.SpecificCps); })
                .ForMember(dest => dest.ThermalConductivitysDTO,
               act => { act.PreCondition(src => (src.ThermalConductivitys != null)); act.MapFrom(src => src.ThermalConductivitys); })
                .ForMember(dest => dest.SpecificEnthalpysDTO,
               act => { act.PreCondition(src => (src.SpecificEnthalpys != null)); act.MapFrom(src => src.SpecificEnthalpys); })
                .ForMember(dest => dest.EnthalpyFlowsDTO,
               act => { act.PreCondition(src => (src.EnthalpyFlows != null)); act.MapFrom(src => src.EnthalpyFlows); })
                .ForMember(dest => dest.ViscositysDTO,
               act => { act.PreCondition(src => (src.Viscositys != null)); act.MapFrom(src => src.Viscositys); })
                .ForMember(dest => dest.DensitysDTO,
               act => { act.PreCondition(src => (src.Densitys != null)); act.MapFrom(src => src.Densitys); })
                .ForMember(dest => dest.VolumetricFlowsDTO,
               act => { act.PreCondition(src => (src.VolumetricFlows != null)); act.MapFrom(src => src.VolumetricFlows); })
                .ForMember(dest => dest.MassFlowsDTO,
               act => { act.PreCondition(src => (src.MassFlows != null)); act.MapFrom(src => src.MassFlows); })
                .ForMember(dest => dest.TemperaturesDTO,
               act => { act.PreCondition(src => (src.Temperatures != null)); act.MapFrom(src => src.Temperatures); })
                .ForMember(dest => dest.PressuresDTO,
               act => { act.PreCondition(src => (src.Pressures != null)); act.MapFrom(src => src.Pressures); })
                .ForMember(dest => dest.FrictionPipeAccesorysDTO,
               act => { act.PreCondition(src => (src.FrictionPipeAccesorys != null)); act.MapFrom(src => src.FrictionPipeAccesorys); })
                .ForMember(dest => dest.ReynoldPipeAccesorysDTO,
               act => { act.PreCondition(src => (src.ReynoldPipeAccesorys != null)); act.MapFrom(src => src.ReynoldPipeAccesorys); })
                .ForMember(dest => dest.LevelInletPipeAccesorysDTO,
               act => { act.PreCondition(src => (src.LevelInletPipeAccesorys != null)); act.MapFrom(src => src.LevelInletPipeAccesorys); })
                .ForMember(dest => dest.LevelOutletPipeAccesorysDTO,
               act => { act.PreCondition(src => (src.LevelOutletPipeAccesorys != null)); act.MapFrom(src => src.LevelOutletPipeAccesorys); })
                .ForMember(dest => dest.FrictionDropPressurePipeAccesorysDTO,
               act => { act.PreCondition(src => (src.FrictionDropPressurePipeAccesorys != null)); act.MapFrom(src => src.FrictionDropPressurePipeAccesorys); })
                .ForMember(dest => dest.OverallDropPressurePipeAccesorysDTO,
               act => { act.PreCondition(src => (src.OverallDropPressurePipeAccesorys != null)); act.MapFrom(src => src.OverallDropPressurePipeAccesorys); })
                .ForMember(dest => dest.ElevationChangePipeAccesorysDTO,
               act => { act.PreCondition(src => (src.ElevationChangePipeAccesorys != null)); act.MapFrom(src => src.ElevationChangePipeAccesorys); });

            CreateMap<ProcessFluid, ProcessFluidDTO>()
                .ForMember(dest => dest.EquipmentItemsDTO,
               act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); })
                .ForMember(dest => dest.InstrumentItemsDTO,
               act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); })
                .ForMember(dest => dest.PipingItemsDTO,
               act => { act.PreCondition(src => (src.PipingItems != null)); act.MapFrom(src => src.PipingItems); })
                .ForMember(dest => dest.ProcessConditionDTO,
               act => { act.PreCondition(src => (src.ProcessCondition != null)); act.MapFrom(src => src.ProcessCondition); });

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
                 .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); }).ForMember(dest => dest.ProcessFluidDTO, act => { act.PreCondition(src => (src.ProcessFluid != null)); act.MapFrom(src => src.ProcessFluid); })
                 .ForMember(dest => dest.ProcessConditionDTO, act => { act.PreCondition(src => (src.ProcessCondition != null)); act.MapFrom(src => src.ProcessCondition); })
                 .ForMember(dest => dest.NozzlesDTO, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); });

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
                 .ForMember(dest => dest.BrandDTO, act => { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); })
                 .ForMember(dest => dest.ProcessFluidDTO, act => { act.PreCondition(src => (src.ProcessFluid != null)); act.MapFrom(src => src.ProcessFluid); })
                 .ForMember(dest => dest.ProcessConditionDTO, act => { act.PreCondition(src => (src.ProcessCondition != null)); act.MapFrom(src => src.ProcessCondition); })
                 .ForMember(dest => dest.NozzlesDTO, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); });
            CreateMap<InsulationItem, InsulationItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<PaintingItem, PaintingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
            CreateMap<PipingItem, PipingItemDTO>()
               .ForMember(dest => dest.MWOItemDTOs, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.NozzlesDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.PipeAccesorysDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.MaterialDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.ProcessFluidDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.DiameterDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.NozzleStartDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.NozzleFinishDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.StartMWOItemDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.FinishMWOItemDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
               .ForMember(dest => dest.PipeClassDTO, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
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
            CreateMap<ProcessConditionDTO, ProcessCondition>();
            CreateMap<PipeClassDTO, PipeClass>();
            CreateMap<PipeAccesoryDTO, PipeAccesory>();
            CreateMap<NozzleDTO, Nozzle>();
            CreateMap<PipeDiameterDTO, PipeDiameter>();
            CreateMap<ProcessFluidDTO, ProcessFluid>();
            CreateMap<UnitDTO, Unit>();
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
