using CPTool.Domain.Enums;

namespace CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate
{
    public class AddSignal
    {

       
        public string Name { get; set; } = string.Empty;
        public bool IsWired { get; set; }
        public int? SignalModifierId { get; set; }
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
