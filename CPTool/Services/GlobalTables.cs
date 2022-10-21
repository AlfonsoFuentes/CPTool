using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.Query.GetList;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.Query.GetList;
using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;
using CPTool.Application.Features.ConnectionTypeFeatures.Query.GetList;
using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;
using CPTool.Application.Features.DeviceFunctionFeatures.Query.GetList;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetList;
using CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetList;
using CPTool.Application.Features.GasketFeatures.Query.GetList;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Query.GetList;
using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableFeatures.Query.GetList;
using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableModifierFeatures.Query.GetList;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetList;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Query.GetList;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.Query.GetList;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.Query.GetList;
using CPTool.Application.Features.ReadoutFeatures.CreateEdit;
using CPTool.Application.Features.ReadoutFeatures.Query.GetList;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.Query.GetList;
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.Query.GetList;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetList;
using CPTool.Application.Features.VendorCodeFeatures.CreateEdit;
using CPTool.Application.Features.VendorCodeFeatures.Query.GetList;
using CPTool.Domain.Entities;

namespace CPTool.Services
{
    public static class GlobalTables
    {
        public static List<EditMWOType> MWOTypes { get; set; } = new();
        public static List<EditMWO> MWOs { get; set; } = new();
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
        public static List<EditVendorCode> VendorCodes { get; set; } = new();

        public static List<EditPipeDiameter> PipeDiameters { get; set; } = new();

        public static List<EditPipeClass> PipeClasses { get; set; } = new();
        public static List<EditConnectionType> ConnectionTypes { get; set; } = new();
        public static List<EditProcessFluid> ProcessFluids { get; set; } = new();
        public static List<EditBrandSupplier> BrandSuppliers { get; set; } = new();
        public static List<EditMeasuredVariable> MeasuredVariables { get; set; } = new();
        public static List<EditMeasuredVariableModifier> MeasuredVariableModifiers { get; set; } = new();
        public static List<EditReadout> Readouts { get; set; } = new();
        public static List<EditDeviceFunction> DeviceFunctions { get; set; } = new();
        public static List<EditDeviceFunctionModifier> DeviceFunctionModifiers { get; set; } = new();
        public static async Task InitializeTables( IMediator mediator)
        {
          
            GetChapterListQuery ChapterList = new();
            GetMWOListQuery MWOList = new();
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
            GetVendorCodeListQuery VendorCodelist = new();
            GetProcessFluidListQuery ProcessFluidlist = new();
            GetBrandSupplierListQuery brandSupplierListQuery = new();
            GetMeasuredVariableListQuery getMeasuredVariableListQuery = new();
            GetMeasuredVariableModifierListQuery getMeasuredVariableModifierListQuery = new();
            GetReadoutListQuery getReadoutListQuery = new();
            GetDeviceFunctionListQuery getDeviceFunctionListQuery = new();
            GetDeviceFunctionModifierListQuery getDeviceFunctionModifierListQuery = new();
            Chapters = await mediator.Send(ChapterList);
            MWOs = await mediator.Send(MWOList);
            MWOTypes = await mediator.Send(MWOTypeList);
            UnitaryBasePrizes = await mediator.Send(unitarybaseprie);
            EquipmentTypes = await mediator.Send(EquipmenTypeList);
            EquipmentTypeSubs = await mediator.Send(EquipmenTypeSubList);
            Brands = await mediator.Send(brandlist);
            Suppliers = await mediator.Send(supplierlist);
            Materials = await mediator.Send(materiallist);
            Gaskets = await mediator.Send(gasketlist);
            PipeClasses = await mediator.Send(pipeclaslist);
            PipeDiameters = await mediator.Send(pipediamterlist);
           
            ConnectionTypes = await mediator.Send(connectiontypelist);
            TaxCodeLDs = await mediator.Send(TaxCodeLDlist);
            TaxCodeLPs = await mediator.Send(TaxCodeLPlist);
            VendorCodes = await mediator.Send(VendorCodelist);

            ProcessFluids = await mediator.Send(ProcessFluidlist);

            BrandSuppliers=await mediator.Send(brandSupplierListQuery);
            MeasuredVariables=await mediator.Send(getMeasuredVariableListQuery);
            MeasuredVariableModifiers = await mediator.Send(getMeasuredVariableModifierListQuery);
            Readouts = await mediator.Send(getReadoutListQuery);
            DeviceFunctions = await mediator.Send(getDeviceFunctionListQuery);
            DeviceFunctionModifiers=await mediator.Send(getDeviceFunctionModifierListQuery);
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
