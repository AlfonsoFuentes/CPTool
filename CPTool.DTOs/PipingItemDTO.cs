

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class PipingItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
        public List<NozzleDTO>? NozzlesDTO { get; set; } = new();
      
        public List<PipeAccesoryDTO>? PipeAccesorysDTO { get; set; } = new();
        public MaterialDTO? MaterialDTO { get; set; }
        public ProcessFluidDTO? ProcessFluidDTO { get; set; }
        public PipeDiameterDTO? DiameterDTO { get; set; }
        public NozzleDTO? NozzleStartDTO { get; set; }
        public NozzleDTO? NozzleFinishDTO { get; set; }
        public MWOItemDTO? StartMWOItemDTO { get; set; }
        public MWOItemDTO? FinishMWOItemDTO { get; set; }
        public PipeClassDTO? PipeClassDTO { get; set; }
        public int? MaterialId => MaterialDTO?.Id;
        public int? ProcessFluidId => ProcessFluidDTO?.Id;
        public int? DiameterId => DiameterDTO?.Id;
        public int? NozzleStartId => NozzleStartDTO?.Id;
        public int? NozzleFinishId => NozzleFinishDTO?.Id;
        public int? StartMWOItemId => StartMWOItemDTO?.Id;
        public int? FinishMWOItemId => FinishMWOItemDTO?.Id;
        public int? PipeClassId => PipeClassDTO?.Id;
        public bool Insulation { get; set; }
    }





}
