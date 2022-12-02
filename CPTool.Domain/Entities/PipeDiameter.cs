namespace CPTool.Domain.Entities
{
    public class PipeDiameter : BaseDomainModel
    {
        [ForeignKey("paDiameterId")]
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;

        public int? dPipeClassId { get; set; }
        public PipeClass? dPipeClass { get; set; }

        [ForeignKey("pDiameterId")]
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        [ForeignKey("PipeDiameterId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        public int? OuterDiameterId { get; set; }
        public Unit? OuterDiameter { get; set; }
        public int? InternalDiameterId { get; set; }
        public Unit? InternalDiameter { get; set; }

        public int? ThicknessId { get; set; }
        public Unit? Thickness { get; set; }


       
      

    }

}
