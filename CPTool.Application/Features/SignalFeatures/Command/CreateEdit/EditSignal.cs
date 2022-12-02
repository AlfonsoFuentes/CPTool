using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetById;
using CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetList;
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.SignalFeatures.Query.GetById;
using CPTool.Application.Features.SignalFeatures.Query.GetList;
using CPTool.Application.Features.SignalModifiersFeatures.CreateEdit;
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;
using CPTool.Application.Features.WireFeatures.CreateEdit;

namespace CPTool.Application.Features.SignalsFeatures.CreateEdit
{
    public class EditSignal : EditCommand, IRequest<Result<int>>
    {
        public bool IsWired { get; set; }
        public int? SignalTypeId => SignalType?.Id == 0 ? null : SignalType?.Id;
        public EditSignalType? SignalType { get; set; } = new();
        public IOType IOType { get; set; }

        public int? WireId => Wire?.Id == 0 ? null : Wire?.Id;
        public EditWire? Wire { get; set; } = new();

        public int? FieldLocationId => FieldLocation?.Id == 0 ? null : FieldLocation?.Id;
        public EditFieldLocation? FieldLocation { get; set; } = new();
        public int? ElectricalBoxId => ElectricalBox?.Id == 0 ? null : ElectricalBox?.Id;
        public EditElectricalBox? ElectricalBox { get; set; } = new();

        public int? MWOItemId => MWOItem?.Id == 0 ? null : MWOItem?.Id;
        public EditMWOItem? MWOItem { get; set; } = new();
        public int? MWOId => MWO?.Id == 0 ? null : MWO?.Id;
        public EditMWO? MWO { get; set; } = new();

        public int? SignalModifierId => SignalModifier?.Id == 0 ? null : SignalModifier?.Id;
        public EditSignalModifier? SignalModifier { get; set; } = new(); 
        public bool Disconect { get; set; }
        public bool InstrumentAir { get; set; }
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