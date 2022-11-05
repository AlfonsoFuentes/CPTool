





namespace CPTool.Services
{

    public static class GlobalTables
    {
        public static List<EditMWOType> MWOTypes { get; set; } = new();
        public static List<EditMWO> MWOs { get; set; } = new();
        public static List<EditMWOItem> MWOItems { get; set; } = new();
        public static List<EditChapter> Chapters { get; set; } = new();
        public static List<EditUnitaryBasePrize> UnitaryBasePrizes { get; set; } = new();
        public static List<EditEquipmentType> EquipmentTypes { get; set; } = new();
        public static List<EditEquipmentTypeSub> EquipmentTypeSubs { get; set; } = new();
        public static List<EditBrand> Brands { get; set; } = new();
        public static List<EditSupplier> Suppliers { get; set; } = new();
        public static List<EditGasket> Gaskets { get; set; } = new();
        public static List<EditMaterial> Materials { get; set; } = new();
        public static List<EditTaxCodeLD> TaxCodeLDs { get; set; } = new();
        public static List<EditTaxCodeLP> TaxCodeLPs { get; set; } = new();
        //public static List<EditVendorCode> VendorCodes { get; set; } = new();

        public static List<EditPipeDiameter> PipeDiameters { get; set; } = new();
        public static List<EditPurchaseOrder> PurchaseOrders { get; set; } = new();
        public static List<EditDownPayment> DownPayments { get; set; } = new();
        public static List<EditPurchaseOrderMWOItem> PurchaseOrderMWOItems { get; set; } = new();
        public static List<EditPipeClass> PipeClasses { get; set; } = new();
        public static List<EditConnectionType> ConnectionTypes { get; set; } = new();
        public static List<EditProcessFluid> ProcessFluids { get; set; } = new();
        public static List<EditPropertyPackage> PropertyPackages { get; set; } = new();
        public static List<EditBrandSupplier> BrandSuppliers { get; set; } = new();
        public static List<EditMeasuredVariable> MeasuredVariables { get; set; } = new();
        public static List<EditMeasuredVariableModifier> MeasuredVariableModifiers { get; set; } = new();
        public static List<EditReadout> Readouts { get; set; } = new();
        public static List<EditDeviceFunction> DeviceFunctions { get; set; } = new();
        public static List<EditDeviceFunctionModifier> DeviceFunctionModifiers { get; set; } = new();

        public static List<EditTaks> Takss { get; set; } = new();
        public static List<EditUserRequirementType> UserRequirementTypes { get; set; } = new();
        public static List<EditUserRequirement> UserRequirements { get; set; } = new();
        public static List<EditUser> Users { get; set; } = new();
        public static List<EditSignal> Signals { get; set; } = new();
        public static List<EditElectricalBox> ElectricalBoxs { get; set; } = new();
        public static List<EditFieldLocation> FieldLocations { get; set; } = new();
        public static List<EditWire> Wires { get; set; } = new();
        public static List<EditSignalType> SignalTypes { get; set; } = new();

        public static async Task InitializeTables(IMediator Mediator)
        {

            GetChapterListQuery ChapterList = new();
            GetMWOListQuery MWOList = new();
            GetMWOItemListQuery MWOItemList = new();
            GetMWOTypeListQuery MWOTypeList = new();
            GetEquipmentTypeListQuery EquipmenTypeList = new();
            GetEquipmentTypeSubListQuery EquipmenTypeSubList = new();
            GetUnitaryBasePrizeListQuery unitarybaseprie = new();
            GetBrandListQuery brandlist = new();
            GetSupplierListQuery supplierlist = new();
            GetMaterialListQuery materiallist = new();
            GetGasketListQuery gasketlist = new();
            GetPipeDiameterListQuery pipediamterlist = new();
            GetPipeClassListQuery pipeclaslist = new();
            GetConnectionTypeListQuery connectiontypelist = new();

            GetTaxCodeLDListQuery TaxCodeLDlist = new();
            GetTaxCodeLPListQuery TaxCodeLPlist = new();
            //GetVendorCodeListQuery VendorCodelist = new();
            GetProcessFluidListQuery ProcessFluidlist = new();
            GetPropertyPackageListQuery propertyPackageListQuery = new();
            GetBrandSupplierListQuery brandSupplierListQuery = new();
            GetMeasuredVariableListQuery getMeasuredVariableListQuery = new();
            GetMeasuredVariableModifierListQuery getMeasuredVariableModifierListQuery = new();
            GetReadoutListQuery getReadoutListQuery = new();
            GetDeviceFunctionListQuery getDeviceFunctionListQuery = new();
            GetDeviceFunctionModifierListQuery getDeviceFunctionModifierListQuery = new();
            GetPurchaseOrderListQuery getPurchaseOrderListQuery = new();
            GetPurchaseOrderMWOItemListQuery getPurchaseOrderMWOItemListQuery = new();
            GetDownPaymentListQuery getDownPaymentListQuery = new();
            GetTaksListQuery getTaksListQuery = new();
            GetUserRequirementTypeListQuery getUserRequirementType = new();
            GetUserRequirementListQuery getUserRequirementListQuery = new();
            GetUserListQuery getRequestedByListQuery = new();
            GetSignalListQuery getSignalsListQuery = new();
            GetElectricalBoxListQuery getElectricalBoxsListQuery = new();
            GetFieldLocationListQuery getFieldLocationListQuery = new();
            GetWireListQuery getWireListQuery = new();
            GetSignalTypeListQuery getSignalTypeListQuery = new();
            MWOTypes = await Mediator.Send(MWOTypeList);
            Chapters = await Mediator.Send(ChapterList);
            MWOs = await Mediator.Send(MWOList);
            MWOItems = await Mediator.Send(MWOItemList);

            UnitaryBasePrizes = await Mediator.Send(unitarybaseprie);
            EquipmentTypes = await Mediator.Send(EquipmenTypeList);
            EquipmentTypeSubs = await Mediator.Send(EquipmenTypeSubList);
            Brands = await Mediator.Send(brandlist);
            Suppliers = await Mediator.Send(supplierlist);
            BrandSuppliers = await Mediator.Send(brandSupplierListQuery);
            Materials = await Mediator.Send(materiallist);
            Gaskets = await Mediator.Send(gasketlist);
            PipeClasses = await Mediator.Send(pipeclaslist);
            PipeDiameters = await Mediator.Send(pipediamterlist);

            ConnectionTypes = await Mediator.Send(connectiontypelist);
            TaxCodeLDs = await Mediator.Send(TaxCodeLDlist);
            TaxCodeLPs = await Mediator.Send(TaxCodeLPlist);
            //VendorCodes = await Mediator.Send(VendorCodelist);

            ProcessFluids = await Mediator.Send(ProcessFluidlist);

           
            MeasuredVariables = await Mediator.Send(getMeasuredVariableListQuery);
            MeasuredVariableModifiers = await Mediator.Send(getMeasuredVariableModifierListQuery);
            Readouts = await Mediator.Send(getReadoutListQuery);
            DeviceFunctions = await Mediator.Send(getDeviceFunctionListQuery);
            DeviceFunctionModifiers = await Mediator.Send(getDeviceFunctionModifierListQuery);
            PropertyPackages = await Mediator.Send(propertyPackageListQuery);
            PurchaseOrders = await Mediator.Send(getPurchaseOrderListQuery);
            PurchaseOrderMWOItems = await Mediator.Send(getPurchaseOrderMWOItemListQuery);
            DownPayments = await Mediator.Send(getDownPaymentListQuery);
            Takss = await Mediator.Send(getTaksListQuery);
            UserRequirementTypes = await Mediator.Send(getUserRequirementType);
            UserRequirements = await Mediator.Send(getUserRequirementListQuery);
            Users = await Mediator.Send(getRequestedByListQuery);
           
            Signals = await Mediator.Send(getSignalsListQuery);
            ElectricalBoxs = await Mediator.Send(getElectricalBoxsListQuery);
            FieldLocations = await Mediator.Send(getFieldLocationListQuery);
            Wires = await Mediator.Send(getWireListQuery);
            SignalTypes = await Mediator.Send(getSignalTypeListQuery);
        }
        public static string ValidateGasket(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!Gaskets.Any(x => x.Name == arg))
                return $"Gasket: {arg} is not in the list";

            return null;
        }
        public static string ValidateMaterial(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!Materials.Any(x => x.Name == arg))
                return $"Material: {arg} is not in the list";

            return null;
        }
        public static string ValidateMaterialName(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (Materials.Any(x => x.Name == arg))
                return $"Material: {arg} is in the list";

            return null;
        }
        public static string ValidateMaterialAbbName(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (Materials.Any(x => x.Abbreviation == arg))
                return $"Material: {arg} is in the list";

            return null;
        }

        public static string ValidatePipeClass(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!PipeClasses.Any(x => x.Name == arg))
                return $"Class: {arg} is not in the list";

            return null;
        }
        public static string ValidateProcessFluid(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!ProcessFluids.Any(x => x.Name == arg))
                return $"Process fluid: {arg} is not in the list";

            return null;
        }
        public static string ValidateConnectionType(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!ConnectionTypes.Any(x => x.Name == arg))
                return $"Class: {arg} is not in the list";

            return null;
        }

        public static string ReviewTaxCodeLD(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Tax Code LD";
            if (!TaxCodeLDs.Any(x => x.Name == arg))
                return $"Tax Code LD: {arg} is not in the list";
            return null;
        }
        public static string ReviewTaxCodeLP(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Tax Code LP";
            if (!TaxCodeLPs.Any(x => x.Name == arg))
                return $"Tax Code LP: {arg} is not in the list";
            return null;
        }
    }
}
