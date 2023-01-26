
using Azure;
using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;


using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;


using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Entities;
using MediatR;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class CommandMWOItem : CommandBase, IRequest<MWOItemCommandResponse>
    {

        public string CostCenter { get; set; } = string.Empty;
        public List<CommandSignal> Signals { get; set; } = new();

        public int? UnitaryBasePrizeId => UnitaryBasePrize?.Id == 0 ? null : UnitaryBasePrize?.Id;
        public CommandUnitaryBasePrize? UnitaryBasePrize { get; set; } = new();

        public string UnitaryBasePrizeName => UnitaryBasePrize == null ? "" : UnitaryBasePrize!.Name;
        public int Order { get; set; }

        public string? Nomenclatore => BudgetItem == true ? $"{Chapter?.Letter}{Order}" : "";



        public List<CommandPropertySpecification> PropertySpecifications { get; set; } = new();
        public List<CommandPurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
        public List<CommandPurchaseOrder> PurchaseOrders => PurchaseOrderItems.Select(x => x.PurchaseOrder!).ToList();


        public int? ChapterId => Chapter?.Id == 0 ? null : Chapter?.Id;
        public CommandChapter? Chapter { get; set; } = new();

        public string ChapterName => Chapter == null ? "" : Chapter!.Name;

        public double BudgetPrize { get; set; }

        public string BudgetPrizeString => BudgetPrize.ToString("C0");

        public bool Existing { get; set; }
        public bool BudgetItem { get; set; }
        public string ActualString => Actual.ToString("C0");
        public double Actual => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.ActualValue);

        public double Assigned => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.PrizeUSD);

        public string AssignedPrizeString => Assigned.ToString("C0");
        public double Commitment => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.CommitmentValue);
        public string CommitmentString => Commitment.ToString("C0");
        public string PendingString => Pending.ToString("C0");
        public double Pending => BudgetPrize - Assigned;
        public CommandMWO? MWO { get; set; } = new();
        public int? MWOId => MWO?.Id == 0 ? null : MWO?.Id;
        public string MWOName => MWO == null ? "" : MWO!.Name;
        public string MWOCECName => MWO == null ? "" : MWO!.CECName;


        string GetTagId()
        {

            switch (Chapter?.Id)
            {
                case 4:
                    _TagId = GetTagIdEquipment();
                    break;
                case 7:
                    _TagId = GetTagIdInstrument();
                    break;
                case 6:
                    _TagId = GetTagIdPiping();
                    break;
                default:
                    _TagId = "";
                    break;
            }
            return _TagId;
        }
        public List<CommandPipeAccesory> PipeAccesorys { get; set; } = new();
        public List<CommandNozzle> Nozzles { get; set; } = new();

        public CommandNozzle AddNewNozzle(CommandNozzle nozzle)
        {

            nozzle.MWOItem = this;


            nozzle.Order = Nozzles!.Count == 0 ? 1 : this.Nozzles.OrderBy(x => x.Order).Last().Order + 1;
            nozzle.Name = $"N{nozzle.Order}";



            return nozzle;

        }

        public void AssignInternalItem()
        {

            var list = MWO!.MWOItems!.Where(x => x.ChapterId == ChapterId && x.BudgetItem == true).OrderBy(x=>x.Order).ToList();

           
            Order = list.Count == 0 ? 1 : list.Last().Order + 1;



        }

        public CommandProcessCondition? ProcessCondition { get; set; } = new();
        public int? eProcessFluidId => ProcessFluid?.Id == 0 ? null : ProcessFluid?.Id;
        public CommandProcessFluid? ProcessFluid { get; set; }

        public string ProcessFluidName => ProcessFluid == null ? "" : ProcessFluid!.Name;



        public int? InnerMaterialId => InnerMaterial?.Id == 0 ? null : InnerMaterial?.Id;
        public CommandMaterial? InnerMaterial { get; set; } = new();

        public string InnerMaterialName => InnerMaterial == null ? "" : InnerMaterial!.Name;
        public int? MaterialOuterId => _OuterMaterial?.Id == 0 ? null : _OuterMaterial?.Id;
        CommandMaterial? _OuterMaterial = new();
        public CommandMaterial? MaterialOuter
        {
            get
            {
                return _OuterMaterial;
            }
            set
            {
                _OuterMaterial = value;
            }
        }

        public string OuterMaterialName => _OuterMaterial == null ? "" : _OuterMaterial!.Name;
        public int? EquipmentTypeId => _EquipmentType?.Id == 0 ? null : _EquipmentType?.Id;
        CommandEquipmentType? _EquipmentType = new();

        public CommandEquipmentType? EquipmentType
        {
            get
            {
                return _EquipmentType;
            }
            set
            {
                _EquipmentType = value;

                //_TagId = GetTagIdEquipment();
            }
        }

        public string EquipmentTypeName => _EquipmentType == null ? "" : _EquipmentType!.Name;
        public int? EquipmentTypeSubId => _EquipmentTypeSub?.Id == 0 ? null : _EquipmentTypeSub?.Id;

        public string EquipmentTypeSubName => _EquipmentTypeSub == null ? "" : _EquipmentTypeSub!.Name;
        CommandEquipmentTypeSub? _EquipmentTypeSub = new();
        public CommandEquipmentTypeSub? EquipmentTypeSub
        {
            get
            {
                return _EquipmentTypeSub;
            }
            set
            {
                _EquipmentTypeSub = value;


                //_TagId = GetTagIdEquipment();
            }
        }
        public int? BrandId => Brand?.Id == 0 ? null : Brand?.Id;

        public CommandBrand? Brand { get; set; } = new();

        public string BrandName => Brand == null ? "" : Brand!.Name;
        public int? SupplierId => Supplier?.Id == 0 ? null : Supplier?.Id;
        public CommandSupplier? Supplier { get; set; } = new();

        public string SupplierName => Supplier == null ? "" : Supplier!.Name;
        string _TagNumber = string.Empty;
        public string TagNumber
        {
            get { return _TagNumber; }
            set
            {
                _TagNumber = value;
                //_TagId = GetTagId();
            }
        }



        public string Model { get; set; } = "";

        public string Reference { get; set; } = "";

        public string SerialNumber { get; set; } = "";



        public int? MeasuredVariableId => MeasuredVariable?.Id == 0 ? null : MeasuredVariable?.Id;
        CommandMeasuredVariable? _MeasuredVariable = new();
        public CommandMeasuredVariable? MeasuredVariable
        {
            get { return _MeasuredVariable; }
            set
            {
                _MeasuredVariable = value;

                //_TagId = GetTagIdInstrument();


            }
        }

        public string MeasuredVariableName => MeasuredVariable == null ? "" : MeasuredVariable!.Name;
        public int? MeasuredVariableModifierId => MeasuredVariableModifier?.Id == 0 ? null : MeasuredVariableModifier?.Id;
        CommandMeasuredVariableModifier? _MeasuredVariableModifier = new();
        public CommandMeasuredVariableModifier? MeasuredVariableModifier
        {
            get { return _MeasuredVariableModifier; }
            set
            {
                _MeasuredVariableModifier = value;

                //_TagId = GetTagIdInstrument();


            }
        }

        public string MeasuredVariableModifierName => MeasuredVariableModifier == null ? "" : MeasuredVariableModifier!.Name;
        public int? DeviceFunctionId => DeviceFunction?.Id == 0 ? null : DeviceFunction?.Id;
        CommandDeviceFunction? _DeviceFunction = new();
        public CommandDeviceFunction? DeviceFunction
        {
            get { return _DeviceFunction; }
            set
            {
                _DeviceFunction = value;

                //_TagId = GetTagIdInstrument();


            }
        }

        public string DeviceFunctionName => DeviceFunction == null ? "" : DeviceFunction!.Name;
        public int? DeviceFunctionModifierId => DeviceFunctionModifier?.Id == 0 ? null : DeviceFunctionModifier?.Id;
        CommandDeviceFunctionModifier? _DeviceFunctionModifier = new();
        public CommandDeviceFunctionModifier? DeviceFunctionModifier
        {
            get { return _DeviceFunctionModifier; }
            set
            {
                _DeviceFunctionModifier = value;

                //_TagId = GetTagIdInstrument();


            }
        }

        public string DeviceFunctionModifierName => DeviceFunctionModifier == null ? "" : DeviceFunctionModifier!.Name;
        public int? ReadoutId => Readout?.Id == 0 ? null : Readout?.Id;
        CommandReadout? _Readout = new();
        public CommandReadout? Readout
        {
            get { return _Readout; }
            set
            {
                _Readout = value;




            }
        }

        public string ReadoutName => Readout == null ? "" : Readout!.Name;


        string _TagId = string.Empty;

        string? _TagLetter = string.Empty;
        public string? TagLetter { get => _TagLetter; set => _TagLetter = value; }
        public string TagId { get => GetTagId(); set => _TagId = GetTagId(); }




        public string MaterialPipingName => InnerMaterial == null ? "" : InnerMaterial.Name;
        public CommandMaterial? MaterialPiping
        {
            get { return InnerMaterial; }
            set
            {
                InnerMaterial = value;

                //_TagId = GetTagIdPiping();
            }
        }


        public CommandProcessFluid? ProcessFluidPiping
        {
            get { return ProcessFluid; }
            set
            {
                ProcessFluid = value;

                //_TagId = GetTagIdPiping();
            }
        }
        public int? DiameterId => Diameter?.Id == 0 ? null : Diameter?.Id;
        CommandPipeDiameter? _Diameter = new();
        public string DiameterName => _Diameter == null ? "" : _Diameter.Name;
        public CommandPipeDiameter? Diameter
        {
            get { return _Diameter; }
            set
            {
                _Diameter = value;

                //_TagId = GetTagIdPiping();
            }
        }
        public int? NozzleStartId => NozzleStart?.Id == 0 ? null : NozzleStart?.Id;

        public string NozzleStartName => NozzleStart! == null ? "" : NozzleStart!.NameDescription;
        public CommandNozzle? NozzleStart { get; set; }
        public int? NozzleFinishId => NozzleFinish?.Id == 0 ? null : NozzleFinish?.Id;

        public string NozzleFinishName => NozzleFinish! == null ? "" : NozzleFinish!.NameDescription;
        public CommandNozzle? NozzleFinish { get; set; }
        public int? StartMWOItemId => StartMWOItem?.Id == 0 ? null : StartMWOItem?.Id;
        public string StartMWOItemName => StartMWOItem == null ? "" : StartMWOItem.TagId;
        public CommandMWOItem? StartMWOItem { get; set; }
        public int? FinishMWOItemId => FinishMWOItem?.Id == 0 ? null : FinishMWOItem?.Id;

        public string FinishMWOItemName => FinishMWOItem == null ? "" : FinishMWOItem.TagId;
        public CommandMWOItem? FinishMWOItem { get; set; }
        public int? PipeClassId => PipeClass?.Id == 0 ? null : PipeClass?.Id;
        public string ClassName => PipeClass == null ? "" : PipeClass.Name;
        public CommandPipeClass? PipeClass { get; set; } = new();


        bool _Insulation;
        public bool Insulation
        {
            get
            {
                return _Insulation;
            }
            set
            {
                _Insulation = value;

                _TagId = GetTagIdPiping();
            }
        }

        string GetTagIdPiping()
        {
            StringBuilder tag = new();
            _TagLetter = GetTagLetterPiping();
            if (TagLetter != "") tag.Append(TagLetter);
            tag.Append("-");
            if (_TagNumber != "") tag.Append(_TagNumber);
            tag.Append("-");
            tag.Append((_Insulation ? 1 : 0));
            return tag.ToString();



        }
        string GetTagLetterPiping()
        {

            StringBuilder tag = new();
            if (_Diameter != null) tag.Append(_Diameter!.Name);
            tag.Append("-");
            if (InnerMaterial != null) tag.Append(InnerMaterial!.Abbreviation);
            tag.Append("-");
            if (ProcessFluid != null) tag.Append(ProcessFluid!.TagLetter);





            return tag.ToString();
        }
        string GetTagLetterInstrument()
        {
            StringBuilder tag = new();
            if (MeasuredVariable != null) tag.Append(MeasuredVariable!.TagLetter);
            if (MeasuredVariableModifier != null) tag.Append(MeasuredVariableModifier!.TagLetter);
            if (Readout != null) tag.Append(Readout!.TagLetter);
            if (DeviceFunction != null) tag.Append(DeviceFunction!.TagLetter);
            if (DeviceFunctionModifier != null) tag.Append(DeviceFunctionModifier!.TagLetter);



            return tag.ToString();
        }
        string GetTagIdInstrument()
        {
            StringBuilder tag = new();
            _TagLetter = GetTagLetterInstrument();
            if (_TagLetter != "") tag.Append(_TagLetter);
            tag.Append("_");

            if (_TagNumber != "") tag.Append(_TagNumber);
            return tag.ToString();


        }
        public string GetTagIdEquipment()
        {
            StringBuilder tag = new();
            _TagLetter = GetTagLetterEquipment();
            if (_TagLetter != "") tag.Append(_TagLetter);
            tag.Append("_");
            if (_TagNumber != "") tag.Append(_TagNumber);

            return tag.ToString();


        }
        string GetTagLetterEquipment()
        {
            StringBuilder tag = new();
            if (EquipmentType != null) tag.Append(EquipmentType!.TagLetter);
            if (EquipmentTypeSub != null) tag.Append(EquipmentTypeSub!.TagLetter);


            return tag.ToString();
        }
    }

}
