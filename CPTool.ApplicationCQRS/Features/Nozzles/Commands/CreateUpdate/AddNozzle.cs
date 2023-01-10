using CPTool.Domain.Enums;

namespace CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate
{
    public class AddNozzle
    {

       
        public string Name { get; set; } = string.Empty;
        public int? PipeAccesoryId { get; set; }
        public int Order { get; set; }

        public int? ConnectedToId { get; set; }
        //public int? EquipmentItemId { get; set; }
        //public int? InstrumentItemId { get; set; }

        public int? MWOItemId { get; set; }

        public int? PipeDiameterId { get; set; }
        public int? ConnectionTypeId { get; set; }
        public int? nGasketId { get; set; }
        public int? nMaterialId { get; set; }
        public StreamType StreamType { get; set; }
        public int? nPipeClassId { get; set; }
        public string? Description { get; set; } = string.Empty;
    }

}
