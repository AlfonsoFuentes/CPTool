namespace CPTool.Domain.Entities
{
    public class PipingItem : BaseDomainModel
    {
        [ForeignKey("PipingItemId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        [ForeignKey("PipingItemId")]
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
        [ForeignKey("pPipingItemId")]
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;

        public int? pProcessConditionId { get; set; }
        public ProcessCondition? pProcessCondition { get; set; }
       
        public int? pProcessFluidId { get; set; }
        public ProcessFluid? pProcessFluid { get; set; }
       
        public int? NozzleStartId { get; set; }
        public Nozzle? NozzleStart { get; set; }
        public int? NozzleFinishId { get; set; }
        public Nozzle? NozzleFinish { get; set; }
        public int? StartMWOItemId { get; set; }
        public MWOItem? StartMWOItem { get; set; }
        public int? FinishMWOItemId { get; set; }
        public MWOItem? FinishMWOItem { get; set; }

        public int? pMaterialId { get; set; }
        public Material? pMaterial { get; set; }
        public int? pDiameterId { get; set; }
        public PipeDiameter? pDiameter { get; set; }
        public int? pPipeClassId { get; set; }
        public PipeClass? pPipeClass { get; set; }
        public string TagId { get; set; } = String.Empty;
        public bool Insulation { get; set; }
        public string TagNumber { get; set; } = String.Empty;

    }

}
