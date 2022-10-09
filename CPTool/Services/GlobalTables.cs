using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.Query.GetList;
using CPTool.Application.Features.ConnectionTypeFeatures.Command.CreateEdit;
using CPTool.Application.Features.ConnectionTypeFeatures.Query.GetList;
using CPTool.Application.Features.GasketFeatures.Query.GetList;
using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Query.GetList;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetList;
using CPTool.Application.Features.PipeClassFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Query.GetList;
using CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.Query.GetList;
using CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.Query.GetList;
using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Application.Features.TaxCodeLDFeatures.Command.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.Query.GetList;
using CPTool.Application.Features.TaxCodeLPFeatures.Command.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.Query.GetList;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Command.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetList;
using CPTool.Application.Features.VendorCodeFeatures.Command.CreateEdit;
using CPTool.Application.Features.VendorCodeFeatures.Query.GetList;
using CPTool.Domain.Entities;

namespace CPTool.Services
{
    public static class GlobalTables
    {
        public static List<AddEditMWOTypeCommand> MWOTypes { get; set; } = new();
        public static List<AddEditMWOCommand> MWOs { get; set; } = new();
        public static List<AddEditChapterCommand> Chapters { get; set; } = new();
        public static List<AddEditUnitaryBasePrizeCommand> UnitaryBasePrizes { get; set; } = new();
        public static List<AddEditEquipmentTypeCommand> EquipmentTypes { get; set; } = new();
        public static List<AddEditBrandCommand> Brands { get; set; } = new();
        public static List<AddEditSupplierCommand> Suppliers { get; set; } = new();
        public static List<AddEditGasketCommand> Gaskets { get; set; } = new();
        public static List<AddEditMaterialCommand> Materials { get; set; } = new();
        public static List<AddEditTaxCodeLDCommand> TaxCodeLDs { get; set; } = new();
        public static List<AddEditTaxCodeLPCommand> TaxCodeLPs { get; set; } = new();
        public static List<AddEditVendorCodeCommand> VendorCodes { get; set; } = new();

        public static List<AddEditPipeDiameterCommand> PipeDiameters { get; set; } = new();

        public static List<AddEditPipeClassCommand> PipeClasses { get; set; } = new();
        public static List<AddEditConnectionTypeCommand> ConnectionTypes { get; set; } = new();
        public static List<AddEditProcessFluidCommand> ProcessFluids { get; set; } = new();
     
        public static async Task InitializeTables( IMediator mediator)
        {
          
            GetChapterListQuery ChapterList = new();
            GetMWOListQuery MWOList = new();
            GetMWOTypeListQuery MWOTypeList = new();
            GetEquipmentTypeListQuery EquipmenTypeList = new();
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
            Chapters = await mediator.Send(ChapterList);
            MWOs = await mediator.Send(MWOList);
            MWOTypes = await mediator.Send(MWOTypeList);
            UnitaryBasePrizes = await mediator.Send(unitarybaseprie);
            EquipmentTypes = await mediator.Send(EquipmenTypeList);
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
        public static string ValidatePipeDiameter(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!PipeDiameters.Any(x => x.Name == arg))
                return $"Diameter: {arg} is not in the list";

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
