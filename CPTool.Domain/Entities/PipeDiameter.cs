﻿namespace CPTool.Domain.Entities
{
    public class PipeDiameter : AuditableEntity
    {
        [ForeignKey("paDiameterId")]
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;

        public int? dPipeClassId { get; set; }
        public PipeClass? dPipeClass { get; set; }

        //[ForeignKey("pDiameterId")]
        //public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        [ForeignKey("DiameterId")]
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
        [ForeignKey("PipeDiameterId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        public int? OuterDiameterId { get; set; }
        public EntityUnit? OuterDiameter { get; set; }
        public int? InternalDiameterId { get; set; }
        public EntityUnit? InternalDiameter { get; set; }

        public int? ThicknessId { get; set; }
        public EntityUnit? Thickness { get; set; }


       
      

    }

}
