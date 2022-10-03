

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class PipingItemDTO : AuditableEntityDTO, IMapFrom<PipingItem>
    {
        public PipingItemDTO() { }
        public List<MWOItemDTO>? MWOItemsDTO { get; set; } = null!;
        public List<NozzleDTO>? NozzlesDTO { get; set; } = new();
      
        public List<PipeAccesoryDTO>? PipeAccesorysDTO { get; set; } = new();
        public MaterialDTO? MaterialDTO { get; set; } = new();
        public ProcessFluidDTO? ProcessFluidDTO { get; set; } = new();
        public PipeDiameterDTO? DiameterDTO { get; set; } = new();
        public NozzleDTO? NozzleStartDTO { get; set; } = null!;
        public NozzleDTO? NozzleFinishDTO { get; set; } = null!;
        public MWOItemDTO? StartMWOItemDTO { get; set; } = null!;
        public MWOItemDTO? FinishMWOItemDTO { get; set; } = null!;
        public PipeClassDTO? PipeClassDTO { get; set; } = new();
        //public int? MaterialId => MaterialDTO?.Id;
        //public int? ProcessFluidId => ProcessFluidDTO?.Id;
        //public int? DiameterId => DiameterDTO?.Id;
        //public int? NozzleStartId => NozzleStartDTO?.Id;
        //public int? NozzleFinishId => NozzleFinishDTO?.Id;
        //public int? StartMWOItemId => StartMWOItemDTO?.Id;
        //public int? FinishMWOItemId => FinishMWOItemDTO?.Id;
        //public int? PipeClassId => PipeClassDTO?.Id;
        public bool Insulation { get; set; }
    }





}
