using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetById;
using CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetList;
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.SignalFeatures.Query.GetById;
using CPTool.Application.Features.SignalFeatures.Query.GetList;
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;
using CPTool.Application.Features.WireFeatures.CreateEdit;

namespace CPTool.Application.Features.SignalsFeatures.CreateEdit
{
    public class EditSignal : EditCommand, IRequest<Result<int>>
    {

        public int? SignalTypeId => SignalType == null ? null : SignalType.Id;
        public EditSignalType? SignalType { get; set; }
        public IOType IOType { get; set; }

        public int? WireId => Wire == null ? null : Wire.Id;
        public EditWire? Wire { get; set; }

        public int? FieldLocationId => FieldLocation == null ? null : FieldLocation.Id;
        public EditFieldLocation? FieldLocation { get; set; }
        public int? ElectricalBoxId => ElectricalBox == null ? null : ElectricalBox.Id;
        public EditElectricalBox? ElectricalBox { get; set; }

        public int? MWOItemId => MWOItem == null ? null : MWOItem.Id;
        public EditMWOItem? MWOItem { get; set; }
        public int? MWOId => MWO == null ? null : MWO.Id;
        public EditMWO? MWO { get; set; }

        public bool Disconect { get; set; }
        public bool InstrumentAir { get; set; }
        public bool FrequencyInverter { get; set; }

    }
}