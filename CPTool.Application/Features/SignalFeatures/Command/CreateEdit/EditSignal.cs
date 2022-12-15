using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;

using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

using CPTool.Application.Features.SignalModifiersFeatures.CreateEdit;
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;
using CPTool.Application.Features.WireFeatures.CreateEdit;
using CPTool.Domain.Enums;

namespace CPTool.Application.Features.SignalsFeatures.CreateEdit
{
    public class EditSignal : EditCommand, IRequest<Result<int>>
    {
        [Report]
        public bool IsWired { get; set; }
        public int? SignalTypeId => SignalType?.Id == 0 ? null : SignalType?.Id;
        public EditSignalType? SignalType { get; set; } = new();
        [Report]
        public string SignalTypeName => SignalType!.Name;
        [Report]
        public string IOTypeName => IOType.ToString();
        public IOType IOType { get; set; }

        public int? WireId => Wire == null ? null : Wire?.Id;
        public EditWire? Wire { get; set; } = new();
        [Report]
        public string WireName => Wire == null ? "" : Wire!.Name;
        public int? FieldLocationId => FieldLocation == null ? null : FieldLocation?.Id;
        public EditFieldLocation? FieldLocation { get; set; } = new();
        [Report]
        public string FieldLocationName => FieldLocation==null?"": FieldLocation!.Name;
        public int? ElectricalBoxId => ElectricalBox == null ? null : ElectricalBox?.Id;
        public EditElectricalBox? ElectricalBox { get; set; } = new();
        [Report]
        public string ElectricalBoxName => ElectricalBox == null ? "" : ElectricalBox!.Name;
        public int? MWOItemId => MWOItem?.Id == 0 ? null : MWOItem?.Id;
        public EditMWOItem? MWOItem { get; set; } = new();
        [Report]
        public string MWOItemName => MWOItem == null ? "" : MWOItem!.Name;
        [Report]
        public string MWOItemTagId => MWOItem == null ? "" : MWOItem!.TagId;
        public int? MWOId => MWO?.Id == 0 ? null : MWO?.Id;
        public EditMWO? MWO { get; set; } = new();
        [Report]
        public string MWOName => MWO == null ? "" : MWO!.Name;
        public int? SignalModifierId => SignalModifier == null ? null : SignalModifier?.Id;
        public EditSignalModifier? SignalModifier { get; set; } = new();
        [Report]
        public string SignalModifierName => SignalModifier == null ? "":SignalModifier!.Name;
        [Report]
        public bool Disconect { get; set; }
        [Report]
        public bool InstrumentAir { get; set; }
        [Report]
        public bool FrequencyInverter { get; set; }
        public List<EditControlLoop>? ProcessVariables { get; set; } = new();
        public List<EditControlLoop>? ControlledVariables { get; set; } = new();
        public override string Name { get => GetName(); set => base.Name = value; }
        string GetName()
        {
            if (MWOItem == null) return "";
            if (MWOItem.TagId == "") return "";
            if (SignalModifier == null) return MWOItem.TagId;
            return $"{MWOItem.TagId}.{SignalModifier.Name}";
        }

    }
}