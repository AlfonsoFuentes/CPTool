

namespace CPTool.Entities
{
    public class PipingItem : AuditableEntity
    {
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;
        public int? MaterialId { get; set; }
        public Material? Material { get; set; }
        public int? ProcessFluidId { get; set; }
        public ProcessFluid? ProcessFluid { get; set; }
        public int? DiameterId { get; set; }
        public PipeDiameter? Diameter { get; set; }
        public int? NozzleStartId { get; set; }
        public Nozzle? NozzleStart { get; set; }
        public int? NozzleFinishId { get; set; }
        public Nozzle? NozzleFinish { get; set; }
        public int? StartMWOItemId { get; set; }
        public MWOItem? StartMWOItem { get; set; }
        public int? FinishMWOItemId { get; set; }
        public MWOItem? FinishMWOItem { get; set; }
        public int? PipeClassId { get; set; }
        public PipeClass? PipeClass { get; set; }
       
        public bool Insulation { get; set; }


    }

}
