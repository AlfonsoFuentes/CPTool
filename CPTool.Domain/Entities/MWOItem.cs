namespace CPTool.Domain.Entities
{
    public class MWOItem  : AuditableEntity
    {
        [ForeignKey("ConnectedToId")]
        public ICollection<Nozzle>? NozzlesConnecteds { get; set; }

        [ForeignKey("StartMWOItemId")]
        public ICollection<MWOItem>? StartMWOItems { get; set; }
        [ForeignKey("FinishMWOItemId")]
        public ICollection<MWOItem>? FinishMWOItems { get; set; }


        [ForeignKey("MWOItemId")]
        public ICollection<PropertySpecification>? PropertySpecifications { get; set; }

        [ForeignKey("MWOItemId")]
        public ICollection<PurchaseOrderItem>? PurchaseOrderItems { get; set; }
        [ForeignKey("MWOItemId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
        [ForeignKey("MWOItemId")]
        public ICollection<Taks> Taks { get; set; } = null!;
        public int? ChapterId { get; set; }
        public Chapter? Chapter { get; set; } = null!;
        public int? MWOId { get; set; }
        public MWO? MWO { get; set; } = null!;
        public int? UnitaryBasePrizeId { get; set; }
        public UnitaryBasePrize? UnitaryBasePrize { get; set; }

      
        public int Order { get; set; }
        public string? Nomenclatore { get; set; }
        public double BudgetPrize { get; set; }
        public bool Existing { get; set; }

        public double Assigned { get; set; }
        public bool BudgetItem { get; set; }

        public int? EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; } = null!;
        public int? EquipmentTypeSubId { get; set; }
        public EquipmentTypeSub? EquipmentTypeSub { get; set; } = null!;

        public int? ProcessConditionId { get; set; }
        public ProcessCondition? ProcessCondition { get; set; } = null!;

        public int? ProcessFluidId { get; set; }
        public ProcessFluid? ProcessFluid { get; set; } = null!;

        public int? InnerMaterialId { get; set; }
        public Material? InnerMaterial { get; set; } = null!;
        public int? MaterialOuterId { get; set; }
        public Material? MaterialOuter { get; set; } = null!;

        public int? BrandId { get; set; }
        public Brand? Brand { get; set; } = null!;
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; } = null!;
 
       

        public int? MeasuredVariableId { get; set; }
        public MeasuredVariable? MeasuredVariable { get; set; }
        public int? MeasuredVariableModifierId { get; set; }
        public MeasuredVariableModifier? MeasuredVariableModifier { get; set; }
        public int? DeviceFunctionId { get; set; }
        public DeviceFunction? DeviceFunction { get; set; }
        public int? DeviceFunctionModifierId { get; set; }
        public DeviceFunctionModifier? DeviceFunctionModifier { get; set; }
        public int? ReadoutId { get; set; }
        public Readout? Readout { get; set; }
        public string TagId { get; set; } = string.Empty;
        public string? TagLetter { get; set; }
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }

        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;

        public int? NozzleStartId { get; set; }
        public Nozzle? NozzleStart { get; set; }
        public int? NozzleFinishId { get; set; }
        public Nozzle? NozzleFinish { get; set; }

        public int? StartMWOItemId { get; set; }
        public MWOItem? StartMWOItem { get; set; }
        public int? FinishMWOItemId { get; set; }
        public MWOItem? FinishMWOItem { get; set; }

        public int? DiameterId { get; set; }
        public PipeDiameter? Diameter { get; set; }
        public int? PipeClassId { get; set; }
        public PipeClass? PipeClass { get; set; }
        public string CostCenter { get; set; } = string.Empty;
        public bool Insulation { get; set; }
    }




}
