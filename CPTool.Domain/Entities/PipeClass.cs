namespace CPTool.Domain.Entities
{
    public class PipeClass  : AuditableEntity
    {
        [ForeignKey("PipeClassId")]
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
        //[ForeignKey("pPipeClassId")]
        //public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        [ForeignKey("nPipeClassId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        [ForeignKey("dPipeClassId")]
        public ICollection<PipeDiameter>? PipeDiameters { get; set; } = null!;

        [ForeignKey("paPipeClassId")]
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;
        //Actualizar el DTO las 3 clases arriba


    }

}
