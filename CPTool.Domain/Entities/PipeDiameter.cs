namespace CPTool.Domain.Entities
{
    public class PipeDiameter  : BaseDomainModel
    {
        public int? PipeClassId { get; set; }
        public PipeClass?  PipeClass { get; set; }
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        public int? OuterDiameterId { get; set; }
        public Unit? OuterDiameter { get; set; }
        public int? InternalDiameterId { get; set; }
        public Unit? InternalDiameter { get; set; }

        public int? ThicknessId { get; set; }
        public Unit? Thickness { get; set; }




    }

}
