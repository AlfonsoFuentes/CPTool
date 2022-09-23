

namespace CPTool.Entities
{
    public class PipeDiameter : AuditableEntity
    {
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        public int? ODId { get; set; }
        public Unit? OD { get; set; }
        public int? IDId { get; set; }
        public Unit? ID { get; set; }

        public int? ThicknessId { get; set; }
        public Unit? Thickness { get; set; }


       
       
    }

}
