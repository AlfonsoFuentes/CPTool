namespace CPTool.Domain.Entities
{
    public class Signal : BaseDomainModel
    {
        public int SignalTypeId { get; set; } 
        public SignalType? SignalType { get; set; }
        public IOType IOType { get; set; }
       
        public int? WireId { get; set; }
        public Wire? Wire { get; set; }

        public int FieldLocationId { get; set; }
        public FieldLocation? FieldLocation { get; set; }
        public int? ElectricalBoxId { get; set; }
        public ElectricalBox? ElectricalBox { get; set; }

        public int? MWOItemId { get; set; }
        public MWOItem? MWOItem { get; set; }
        public int? MWOId { get; set; }
        public MWO? MWO { get; set; }

        public bool Disconect { get; set; }
        public bool InstrumentAir { get; set; }
        public bool FrequencyInverter { get; set; }

     
       
    }

}
