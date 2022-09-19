using CPTool.DTOS;
using CPTool.Entities;
using CPTool.Implementations;
using CPTool.Interfaces;
using System.Threading;

namespace CPTool.Shared
{
    public class TablesService : IDisposable
    {
        public IDTOManager<PurchaseOrderDTO, PurchaseOrder> ManPurchaseOrder { get; set; }
        public IDTOManager<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem> ManPurchaseOrderMWOItem { get; set; }
        public IDTOManager<VendorCodeDTO, VendorCode> ManVendorCode { get; set; }
        public IDTOManager<TaxCodeLDDTO, TaxCodeLD> ManTaxCodeLD { get; set; }
        public IDTOManager<TaxCodeLPDTO, TaxCodeLP> ManTaxCodeLP { get; set; }

        public IDTOManager<BrandDTO, Brand> ManBrand { get; set; }
        public IDTOManager<SupplierDTO, Supplier> ManSupplier { get; set; }
        public IDTOManager<BrandSupplierDTO, BrandSupplier> ManBrandSupplier { get; set; }


        public IDTOManager<MaterialDTO, Material> ManMaterial { get; set; }
        public IDTOManager<GasketDTO, Gasket> ManGasket { get; set; }
        public IDTOManager<UnitaryBasePrizeDTO, UnitaryBasePrize> ManUnitaryPrize { get; set; }
        public IDTOManager<ChapterDTO, Chapter> ManChapter { get; set; }
        public IDTOManager<MWOTypeDTO, MWOType> ManMWOType { get; set; }
        public IDTOManager<MWODTO, MWO> ManMWO { get; set; }
        public IDTOManager<MWOItemDTO, MWOItem> ManMWOItem { get; set; }
        public IDTOManager<EquipmentTypeDTO, EquipmentType> ManEquipmentType { get; set; }
        public IDTOManager<EquipmentTypeSubDTO, EquipmentTypeSub> ManEquipmentTypeSub { get; set; }
        public IDTOManager<EquipmentItemDTO, EquipmentItem> ManEquipmentItem { get; set; }
        public IDTOManager<InstrumentItemDTO, InstrumentItem> ManInstrumentItem { get; set; }
        public IDTOManager<DownPaymentDTO, DownPayment> ManDownPayment { get; set; }

        public IDTOManager<MeasuredVariableDTO, MeasuredVariable> ManMeasuredVariable { get; set; }
        public IDTOManager<MeasuredVariableModifierDTO, MeasuredVariableModifier> ManMeasuredVariableModifier { get; set; }
        public IDTOManager<DeviceFunctionDTO, DeviceFunction> ManDeviceFunction { get; set; }
        public IDTOManager<DeviceFunctionModifierDTO, DeviceFunctionModifier> ManDeviceFunctionModifier { get; set; }
        public IDTOManager<ReadoutDTO, Readout> ManReadout { get; set; }

        public IDTOManager<MaterialsGroupDTO, MaterialsGroup> ManMaterialsGroup { get; set; }
        public IDTOManager<UnitDTO, Unit> ManUnit { get; set; }
        public IDTOManager<ProcessFluidDTO, ProcessFluid> ManProcessFluid { get; set; }
        public IDTOManager<PipeDiameterDTO, PipeDiameter> ManPipeDiameter { get; set; }
        public IDTOManager<NozzleDTO, Nozzle> ManNozzle { get; set; }
        public IDTOManager<PipeAccesoryDTO, PipeAccesory> ManPipeAccesory { get; set; }
        public IDTOManager<PipeClassDTO, PipeClass> ManPipeClass { get; set; }
        public IDTOManager<ProcessConditionDTO, ProcessCondition> ManProcessCondition { get; set; }
        
        public TablesService(
            IDTOManager<BrandSupplierDTO, BrandSupplier> manBrandSupplier,
            IDTOManager<MWOTypeDTO, MWOType> manMWOType,
            IDTOManager<MWODTO, MWO> manMWO,
            IDTOManager<MWOItemDTO, MWOItem> manMWOItem,
            IDTOManager<EquipmentTypeDTO, EquipmentType> manEquipmentType,
            IDTOManager<EquipmentTypeSubDTO, EquipmentTypeSub> manEquipmentTypeSub,
            IDTOManager<ChapterDTO, Chapter> manChapter,
            IDTOManager<UnitaryBasePrizeDTO, UnitaryBasePrize> manUnitaryPrize,
            IDTOManager<GasketDTO, Gasket> manGasket,
            IDTOManager<MaterialDTO, Material> manMaterial,
            IDTOManager<BrandDTO, Brand> manBrand,
            IDTOManager<SupplierDTO, Supplier> manSupplier,
            IDTOManager<EquipmentItemDTO, EquipmentItem> manEquipmentItem,
            IDTOManager<InstrumentItemDTO, InstrumentItem> manInstrumentItem,
            IDTOManager<VendorCodeDTO, VendorCode> manVendorCode,
            IDTOManager<TaxCodeLDDTO, TaxCodeLD> manTaxCodeLD,
            IDTOManager<TaxCodeLPDTO, TaxCodeLP> manTaxCodeLP,
            IDTOManager<PurchaseOrderDTO, PurchaseOrder> manPurchaseOrder,
            IDTOManager<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem> manPurchaseOrderMWOItem,
            IDTOManager<DownPaymentDTO, DownPayment> manDownPayment,
            IDTOManager<MeasuredVariableDTO, MeasuredVariable> manMeasuredVariable,
            IDTOManager<MeasuredVariableModifierDTO, MeasuredVariableModifier> manMeasuredVariableModifier,
            IDTOManager<DeviceFunctionDTO, DeviceFunction> manDeviceFunction,
            IDTOManager<DeviceFunctionModifierDTO, DeviceFunctionModifier> manDeviceFunctionModifier,
            IDTOManager<ReadoutDTO, Readout> manReadout,
            IDTOManager<MaterialsGroupDTO, MaterialsGroup> manMaterialsGroup,
            IDTOManager<UnitDTO, Unit> manUnit,
            IDTOManager<ProcessFluidDTO, ProcessFluid> manProcessFluid,
            IDTOManager<PipeDiameterDTO, PipeDiameter> manPipeDiameter,
            IDTOManager<NozzleDTO, Nozzle> manNozzle,
            IDTOManager<PipeAccesoryDTO, PipeAccesory> manPipeAccesory,
            IDTOManager<PipeClassDTO, PipeClass> manPipeClass,
            IDTOManager<ProcessConditionDTO, ProcessCondition> manProcessCondition


            )

        {

            ManEquipmentType = manEquipmentType;
            ManEquipmentTypeSub = manEquipmentTypeSub;

            ManMWOType = manMWOType;
            ManMWO = manMWO;
            ManMWOItem = manMWOItem;
            ManChapter = manChapter;
            ManUnitaryPrize = manUnitaryPrize;
            ManGasket = manGasket;
            ManMaterial = manMaterial;
            ManBrand = manBrand;
            ManSupplier = manSupplier;
            ManEquipmentItem = manEquipmentItem;
            ManInstrumentItem = manInstrumentItem;
            ManBrandSupplier = manBrandSupplier;
            ManVendorCode = manVendorCode;
            ManTaxCodeLD = manTaxCodeLD;
            ManTaxCodeLP = manTaxCodeLP;
            ManPurchaseOrder = manPurchaseOrder;
            ManPurchaseOrderMWOItem = manPurchaseOrderMWOItem;
            ManDownPayment = manDownPayment;
            ManDeviceFunction = manDeviceFunction;
            ManDeviceFunctionModifier = manDeviceFunctionModifier;
            ManMeasuredVariable = manMeasuredVariable;
            ManMeasuredVariableModifier = manMeasuredVariableModifier;
            ManReadout = manReadout;
            ManMaterialsGroup = manMaterialsGroup;
            ManUnit = manUnit;
            ManProcessFluid = manProcessFluid;
            ManPipeDiameter = manPipeDiameter;
            ManNozzle = manNozzle;
            ManPipeAccesory = manPipeAccesory;
            ManPipeClass = manPipeClass;
            ManProcessCondition = manProcessCondition;
        }

        public async Task Initialize()
        {
            await ManProcessCondition.UpdateList();
            await ManPipeClass.UpdateList();
            await ManPipeAccesory.UpdateList();
            await ManNozzle.UpdateList();
            await ManPipeDiameter.UpdateList();
            await ManProcessFluid.UpdateList();
            await ManUnit.UpdateList();
            await ManChapter.UpdateList();
            await ManUnitaryPrize.UpdateList();
            await ManGasket.UpdateList();
            await ManMaterial.UpdateList();
            await ManEquipmentType.UpdateList();
            await ManEquipmentTypeSub.UpdateList();
            await ManMWOType.UpdateList();
            await ManBrandSupplier.UpdateList();
            await ManBrand.UpdateList();
            await ManSupplier.UpdateList();


            await ManEquipmentItem.UpdateList();
            await ManInstrumentItem.UpdateList();
            await ManMWO.UpdateList();
            await ManMWOItem.UpdateList();

            await ManVendorCode.UpdateList();
            await ManTaxCodeLD.UpdateList();
            await ManTaxCodeLP.UpdateList();
            await ManPurchaseOrder.UpdateList();
            await ManPurchaseOrderMWOItem.UpdateList();
            await ManDownPayment.UpdateList();

            await ManDeviceFunction.UpdateList();
            await ManDeviceFunctionModifier.UpdateList();
            await ManMeasuredVariable.UpdateList();
            await ManMeasuredVariableModifier.UpdateList();
            await ManReadout.UpdateList();
            await ManMaterialsGroup.UpdateList();
        }

        public Func<IAuditableEntityDTO, Task<IResult<IAuditableEntityDTO>>> Save { get; set; }
        public Func<IAuditableEntityDTO, Task<IResult<int>>> Delete { get; set; }
        //public Action UpdateForm { get; set; }
        public async Task<IResult<IAuditableEntityDTO>> OnSave(IAuditableEntityDTO result)
        {
            if (Save != null)
            {
                return await Save!.Invoke(result);

            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not Event");
        }
        public async Task<IResult<int>> OnDelete(IAuditableEntityDTO result)
        {
            if (Delete != null)
            {
                return await Delete!.Invoke(result);

            }


            return await Result<int>.FailAsync("Not Event");
        }


        public void Dispose()
        {

        }
    }
}