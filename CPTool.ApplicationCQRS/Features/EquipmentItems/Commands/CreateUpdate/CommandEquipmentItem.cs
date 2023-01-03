using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate
{
    public class CommandEquipmentItem : CommandBase, IRequest<EquipmentItemCommandResponse>
    {

        public CommandMWOItem MWOItem { get; set; } = new();
        public List<CommandNozzle>? Nozzles { get; set; } = new();
        public int? eProcessConditionId => eProcessCondition?.Id == 0 ? null : eProcessCondition?.Id;

        public CommandProcessCondition? eProcessCondition { get; set; } = new();
        public int? eProcessFluidId => eProcessFluid?.Id == 0 ? null : eProcessFluid?.Id;
        public CommandProcessFluid? eProcessFluid { get; set; }

        public string ProcessFluidName => eProcessFluid == null ? "" : eProcessFluid!.Name;
        public int? eGasketId => eGasket?.Id == 0 ? null : eGasket?.Id;
        public CommandGasket? eGasket { get; set; } = new();

        public string GasketName => eGasket == null ? "" : eGasket!.Name;
        public int? eInnerMaterialId => eInnerMaterial?.Id == 0 ? null : eInnerMaterial?.Id;
        public CommandMaterial? eInnerMaterial { get; set; } = new();

        public string InnerMaterialName => eInnerMaterial == null ? "" : eInnerMaterial!.Name;
        public int? eOuterMaterialId => eOuterMaterial?.Id == 0 ? null : eOuterMaterial?.Id;

        public CommandMaterial? eOuterMaterial { get; set; } = new();

        public string OuterMaterialName => eOuterMaterial == null ? "" : eOuterMaterial!.Name;
        public int? eEquipmentTypeId => eEquipmentType?.Id == 0 ? null : eEquipmentType?.Id;
        CommandEquipmentType? _eEquipmentType = new();

        public CommandEquipmentType? eEquipmentType
        {
            get
            {
                return _eEquipmentType;
            }
            set
            {
                _eEquipmentType = value;
                tagletter = SetTagLetter();
                tagid = GetTagId();
            }
        }

        public string EquipmentTypeName => eEquipmentType == null ? "" : eEquipmentType!.Name;
        public int? eEquipmentTypeSubId => eEquipmentTypeSub?.Id == 0 ? null : eEquipmentTypeSub?.Id;

        public string EquipmentTypeSubName => eEquipmentTypeSub == null ? "" : eEquipmentTypeSub!.Name;
        CommandEquipmentTypeSub? _eEquipmentTypeSub = new();
        public CommandEquipmentTypeSub? eEquipmentTypeSub
        {
            get
            {
                return _eEquipmentTypeSub;
            }
            set
            {
                _eEquipmentTypeSub = value;

                tagletter = SetTagLetter();
                tagid = GetTagId();
            }
        }
        public int? eBrandId => eBrand?.Id == 0 ? null : eBrand?.Id;

        public CommandBrand? eBrand { get; set; } = new();

        public string BrandName => eBrand == null ? "" : eBrand!.Name;
        public int? eSupplierId => eSupplier?.Id == 0 ? null : eSupplier?.Id;
        public CommandSupplier? eSupplier { get; set; } = new();

        public string SupplierName => eSupplier == null ? "" : eSupplier!.Name;
        string _TagNumber = string.Empty;
        public string TagNumber
        {
            get { return _TagNumber; }
            set
            {
                _TagNumber = value;
                tagid = GetTagId();
            }
        }

        string tagletter = string.Empty;
        public string TagLetter => SetTagLetter();

        string tagid = string.Empty;
        public string TagId
        {
            get => tagid;
            set => tagid = value;

        }


        public string Model { get; set; } = "";

        public string Reference { get; set; } = "";

        public string SerialNumber { get; set; } = "";

        public string GetTagId()
        {
            if (TagLetter == "") return "";
            if (TagNumber == "") return $"{TagLetter}";
            return $"{TagLetter}_{TagNumber}";


        }
        string SetTagLetter()
        {
            if (eEquipmentType == null) return "";
            if (eEquipmentTypeSub == null) return $"{eEquipmentType?.TagLetter}";

            string tag = $"{eEquipmentType?.TagLetter}{eEquipmentTypeSub?.TagLetter}";
            return tag;
        }


    }

}
