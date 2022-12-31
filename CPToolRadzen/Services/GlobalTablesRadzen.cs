using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;
using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;
using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.Application.Features.MOTypeFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Application.Features.ReadoutFeatures.CreateEdit;
using CPTool.Application.Features.SignalModifiersFeatures.CreateEdit;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;
using CPTool.Application.Features.WireFeatures.CreateEdit;
using CPTool.Application.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPToolRadzen.Services.Tables
{
    public  class RadzenTables
    {
        ICommandQuery<EditMWOType> EditMWOType;
        ICommandQuery<EditMWO> EditMWO;
        ICommandQuery<EditMWOItem> EditMWOItem;
        ICommandQuery<EditPipeAccesory> EditPipeAccesory;
        ICommandQuery<EditChapter> EditChapter;
        ICommandQuery<EditUnitaryBasePrize> EditUnitaryBasePrize;
        ICommandQuery<EditEquipmentType> EditEquipmentType;
        ICommandQuery<EditEquipmentTypeSub> EditEquipmentTypeSub;
        ICommandQuery<EditBrand> EditBrand;
        ICommandQuery<EditSupplier> EditSupplier;
        ICommandQuery<EditGasket> EditGasket;
        ICommandQuery<EditMaterial> EditMaterial;
        ICommandQuery<EditTaxCodeLD> EditTaxCodeLD;
        ICommandQuery<EditTaxCodeLP> EditTaxCodeLP;
        ICommandQuery<EditPipeDiameter> EditPipeDiameter;
        ICommandQuery<EditPurchaseOrder> EditPurchaseOrder;
        ICommandQuery<EditPurchaseOrderItem> EditPurchaseOrderItem;
        ICommandQuery<EditDownPayment> EditDownPayment;
        ICommandQuery<EditPipeClass> EditPipeClass;
        ICommandQuery<EditConnectionType> EditConnectionType;
        ICommandQuery<EditProcessFluid> EditProcessFluid;
        ICommandQuery<EditPropertyPackage> EditPropertyPackage;
        ICommandQuery<EditMeasuredVariable> EditMeasuredVariable;
        ICommandQuery<EditMeasuredVariableModifier> EditMeasuredVariableModifier;
        ICommandQuery<EditReadout> EditReadout;
        ICommandQuery<EditDeviceFunction> EditDeviceFunction;
        ICommandQuery<EditDeviceFunctionModifier> EditDeviceFunctionModifier;
        ICommandQuery<EditTaks> EditTaks;
        ICommandQuery<EditUserRequirementType> EditUserRequirementType;
     
        ICommandQuery<EditUserRequirement> EditUserRequirement;
        ICommandQuery<EditUser> EditUser;
        ICommandQuery<EditSignal> EditSignal;
        ICommandQuery<EditElectricalBox> EditElectricalBox;
        ICommandQuery<EditFieldLocation> EditFieldLocation;
        ICommandQuery<EditWire> EditWire;
        ICommandQuery<EditNozzle> EditNozzle;
        ICommandQuery<EditSignalType> EditSignalType;
        ICommandQuery<EditSignalModifier> EditSignalModifier;
        ICommandQuery<EditControlLoop> EditControlLoop;
        ICommandQuery<EditBrandSupplier> EditBrandSupplier;

        public RadzenTables(ICommandQuery<EditMWOItem> editMWOItem,ICommandQuery<EditMWOType> editMWOType, ICommandQuery<EditMWO> editMWO, ICommandQuery<EditPipeAccesory> editPipeAccesory, ICommandQuery<EditChapter> editChapter, ICommandQuery<EditUnitaryBasePrize> editUnitaryBasePrize, ICommandQuery<EditEquipmentType> editEquipmentType, ICommandQuery<EditEquipmentTypeSub> editEquipmentTypeSub, ICommandQuery<EditBrand> editBrand, ICommandQuery<EditSupplier> editSupplier, ICommandQuery<EditGasket> editGasket, ICommandQuery<EditMaterial> editMaterial, ICommandQuery<EditTaxCodeLD> editTaxCodeLD, ICommandQuery<EditTaxCodeLP> editTaxCodeLP, ICommandQuery<EditPipeDiameter> editPipeDiameter, ICommandQuery<EditPurchaseOrder> editPurchaseOrder, ICommandQuery<EditPurchaseOrderItem> editPurchaseOrderItem, ICommandQuery<EditDownPayment> editDownPayment, ICommandQuery<EditPipeClass> editPipeClass, ICommandQuery<EditConnectionType> editConnectionType, ICommandQuery<EditProcessFluid> editProcessFluid, ICommandQuery<EditPropertyPackage> editPropertyPackage, ICommandQuery<EditMeasuredVariable> editMeasuredVariable, ICommandQuery<EditMeasuredVariableModifier> editMeasuredVariableModifier, ICommandQuery<EditReadout> editReadout, ICommandQuery<EditDeviceFunction> editDeviceFunction, ICommandQuery<EditDeviceFunctionModifier> editDeviceFunctionModifier, ICommandQuery<EditTaks> editTaks, ICommandQuery<EditUserRequirementType> editUserRequirementType, ICommandQuery<EditUserRequirement> editUserRequirement, ICommandQuery<EditUser> editUser, ICommandQuery<EditSignal> editSignal, ICommandQuery<EditElectricalBox> editElectricalBox, ICommandQuery<EditFieldLocation> editFieldLocation, ICommandQuery<EditWire> editWire, ICommandQuery<EditNozzle> editNozzle, ICommandQuery<EditSignalType> editSignalType, ICommandQuery<EditSignalModifier> editSignalModifier, ICommandQuery<EditControlLoop> editControlLoop, ICommandQuery<EditBrandSupplier> editBrandSupplier)
        {
            EditMWOItem = editMWOItem;
            EditMWOType = editMWOType;
            EditMWO = editMWO;
            EditPipeAccesory = editPipeAccesory;
            EditChapter = editChapter;
            EditUnitaryBasePrize = editUnitaryBasePrize;
            EditEquipmentType = editEquipmentType;
            EditEquipmentTypeSub = editEquipmentTypeSub;
            EditBrand = editBrand;
            EditSupplier = editSupplier;
            EditGasket = editGasket;
            EditMaterial = editMaterial;
            EditTaxCodeLD = editTaxCodeLD;
            EditTaxCodeLP = editTaxCodeLP;
            EditPipeDiameter = editPipeDiameter;
            EditPurchaseOrder = editPurchaseOrder;
            EditPurchaseOrderItem = editPurchaseOrderItem;
            EditDownPayment = editDownPayment;
            EditPipeClass = editPipeClass;
            EditConnectionType = editConnectionType;
            EditProcessFluid = editProcessFluid;
            EditPropertyPackage = editPropertyPackage;
            EditMeasuredVariable = editMeasuredVariable;
            EditMeasuredVariableModifier = editMeasuredVariableModifier;
            EditReadout = editReadout;
            EditDeviceFunction = editDeviceFunction;
            EditDeviceFunctionModifier = editDeviceFunctionModifier;
            EditTaks = editTaks;
            EditUserRequirementType = editUserRequirementType;
            EditUserRequirement = editUserRequirement;
            EditUser = editUser;
            EditSignal = editSignal;
            EditElectricalBox = editElectricalBox;
            EditFieldLocation = editFieldLocation;
            EditWire = editWire;
            EditNozzle = editNozzle;
            EditSignalType = editSignalType;
            EditSignalModifier = editSignalModifier;
            EditControlLoop = editControlLoop;
            EditBrandSupplier = editBrandSupplier;
        }

        public async Task Initialize()
        {
            PipeAccesorys = await EditPipeAccesory.GetAll();
            MWOTypes = await EditMWOType.GetAll();
            MWOs = await EditMWO.GetAll();
            MWOItems = await EditMWOItem.GetAll();
            Chapters = await EditChapter.GetAll();
            UnitaryBasePrizes = await EditUnitaryBasePrize.GetAll();
            EquipmentTypes = await EditEquipmentType.GetAll();
            EquipmentTypeSubs = await EditEquipmentTypeSub.GetAll();
            Brands = await EditBrand.GetAll();
            Suppliers = await EditSupplier.GetAll();
            Gaskets = await EditGasket.GetAll();
            Materials = await EditMaterial.GetAll();
            TaxCodeLDs = await EditTaxCodeLD.GetAll();
            TaxCodeLPs = await EditTaxCodeLP.GetAll();
            PipeDiameters = await EditPipeDiameter.GetAll();
            PurchaseOrders = await EditPurchaseOrder.GetAll();
            PurchaseOrderItems = await EditPurchaseOrderItem.GetAll();
            DownPayments = await EditDownPayment.GetAll();
            PipeClasses = await EditPipeClass.GetAll();
            ConnectionTypes = await EditConnectionType.GetAll();
            ProcessFluids = await EditProcessFluid.GetAll();
            PropertyPackages = await EditPropertyPackage.GetAll();
            BrandSuppliers = await EditBrandSupplier.GetAll();
            MeasuredVariables = await EditMeasuredVariable.GetAll();
            MeasuredVariableModifiers = await EditMeasuredVariableModifier.GetAll();
            Readouts = await EditReadout.GetAll();
            DeviceFunctions = await EditDeviceFunction.GetAll();
            DeviceFunctionModifiers = await EditDeviceFunctionModifier.GetAll();
            Takss = await EditTaks.GetAll();
            UserRequirementTypes = await EditUserRequirementType.GetAll();
            UserRequirements = await EditUserRequirement.GetAll();
            Users = await EditUser.GetAll();
            Signals = await EditSignal.GetAll();
            ElectricalBoxs = await EditElectricalBox.GetAll();
            FieldLocations = await EditFieldLocation.GetAll();
            Wires = await EditWire.GetAll();
            Nozzles = await EditNozzle.GetAll();
            SignalTypes = await EditSignalType.GetAll();
            SignalModifiers = await EditSignalModifier.GetAll();
            ControlLoops = await EditControlLoop.GetAll();

        }
        public  List<EditMWOType> MWOTypes { get; set; } = new();
       
        public  List<EditMWO> MWOs { get; set; } = new();
        public  List<EditMWOItem> MWOItems { get; set; } = new();
        public  List<EditChapter> Chapters { get; set; } = new();
        public  List<EditUnitaryBasePrize> UnitaryBasePrizes { get; set; } = new();
        public  List<EditEquipmentType> EquipmentTypes { get; set; } = new();
        public  List<EditEquipmentTypeSub> EquipmentTypeSubs { get; set; } = new();
        public  List<EditBrand> Brands { get; set; } = new();
        public  List<EditSupplier> Suppliers { get; set; } = new();
        public  List<EditGasket> Gaskets { get; set; } = new();
        public  List<EditMaterial> Materials { get; set; } = new();
        public  List<EditTaxCodeLD> TaxCodeLDs { get; set; } = new();
        public  List<EditTaxCodeLP> TaxCodeLPs { get; set; } = new();
        //public  List<EditVendorCode> VendorCodes { get; set; } = new();

        public  List<EditPipeDiameter> PipeDiameters { get; set; } = new();
        public  List<EditPurchaseOrder> PurchaseOrders { get; set; } = new();
        public  List<EditPurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
        public  List<EditDownPayment> DownPayments { get; set; } = new();

        public  List<EditPipeClass> PipeClasses { get; set; } = new();
        public  List<EditConnectionType> ConnectionTypes { get; set; } = new();
        public  List<EditProcessFluid> ProcessFluids { get; set; } = new();
        public  List<EditPropertyPackage> PropertyPackages { get; set; } = new();
        public  List<EditBrandSupplier> BrandSuppliers { get; set; } = new();
        public  List<EditMeasuredVariable> MeasuredVariables { get; set; } = new();
        public  List<EditMeasuredVariableModifier> MeasuredVariableModifiers { get; set; } = new();
        public  List<EditReadout> Readouts { get; set; } = new();
        public  List<EditDeviceFunction> DeviceFunctions { get; set; } = new();
        public  List<EditDeviceFunctionModifier> DeviceFunctionModifiers { get; set; } = new();

        public  List<EditTaks> Takss { get; set; } = new();
        public  List<EditUserRequirementType> UserRequirementTypes { get; set; } = new();
        public  List<EditUserRequirement> UserRequirements { get; set; } = new();
        public  List<EditUser> Users { get; set; } = new();
        public  List<EditSignal> Signals { get; set; } = new();
        public  List<EditElectricalBox> ElectricalBoxs { get; set; } = new();
        public  List<EditFieldLocation> FieldLocations { get; set; } = new();
        public  List<EditWire> Wires { get; set; } = new();
        public  List<EditNozzle> Nozzles { get; set; } = new();
        public  List<EditSignalType> SignalTypes { get; set; } = new();
        public  List<EditSignalModifier> SignalModifiers { get; set; } = new();
        public  List<EditControlLoop> ControlLoops { get; set; } = new();
        public  List<EditPipeAccesory> PipeAccesorys { get; set; } = new();
     

        

       
    }
}
