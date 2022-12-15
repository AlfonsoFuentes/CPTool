
using CPTool.Domain.Enums;


namespace CPTool.Application.Features.NozzleFeatures.CreateEdit
{
    public class AddNozzle : AddCommand
    {
       
        public int? PipeAccesoryId { get; set; }
        public int Order { get; set; }

        public int? ConnectedToId { get; set; }
        public int? EquipmentItemId { get; set; }
        public int? InstrumentItemId { get; set; }

        public int? PipingItemId { get; set; }

        public int? PipeDiameterId { get; set; }
        public int? ConnectionTypeId { get; set; }
        public int? nGasketId { get; set; }
        public int? nMaterialId { get; set; }
        public StreamType StreamType { get; set; }
        public int? nPipeClassId { get; set; }
        public string? Description { get; set; } = string.Empty;
    }
}
