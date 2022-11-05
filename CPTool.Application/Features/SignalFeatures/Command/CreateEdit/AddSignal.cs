

using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;
using CPTool.Application.Features.WireFeatures.CreateEdit;

namespace CPTool.Application.Features.SignalsFeatures.CreateEdit
{
    public class AddSignal : AddCommand
    {

        public int? SignalTypeId { get; set; }
        public IOType IOType { get; set; }

        public int? WireId { get; set; }

        public int? FieldLocationId { get; set; }
        public int? ElectricalBoxId { get; set; }

        public int? MWOItemId { get; set; }
        public int? MWOId { get; set; }

        public bool Disconect { get; set; }
        public bool InstrumentAir { get; set; }
        public bool FrequencyInverter { get; set; }

    }
}