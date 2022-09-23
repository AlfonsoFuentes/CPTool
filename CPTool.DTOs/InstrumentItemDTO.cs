



namespace CPTool.DTOS
{
   
    public class InstrumentItemDTO : AuditableEntityDTO, IMapFrom<InstrumentItem>
    {
       
        public List<NozzleDTO>? NozzlesDTO { get; set; } = new();
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = null!;

        public MeasuredVariableDTO? MeasuredVariableDTO { get; set; } = new();
        public MeasuredVariableModifierDTO? MeasuredVariableModifierDTO { get; set; } = new();
        public DeviceFunctionDTO? DeviceFunctionDTO { get; set; } = new();
        public DeviceFunctionModifierDTO? DeviceFunctionModifierDTO { get; set; } = new();
        public ReadoutDTO? ReadoutDTO { get; set; } = new();
      
       
        public ProcessConditionDTO? ProcessConditionDTO { get; set; } = new();
        public ProcessFluidDTO? ProcessFluidDTO { get; set; } = new();
        public GasketDTO? GasketDTO { get; set; } = new();
        public MaterialDTO? InnerMaterialDTO { get; set; } = new();
        public MaterialDTO? OuterMaterialDTO { get; set; } = new();
        public BrandDTO? BrandDTO { get; set; } = new();
        public SupplierDTO? SupplierDTO { get; set; } = new();
        //public int? GasketId => GasketDTO?.Id == 0 ? null : GasketDTO?.Id;
        //public int? InnerMaterialId => InnerMaterialDTO?.Id == 0 ? null : InnerMaterialDTO?.Id;
        //public int? OuterMaterialId => OuterMaterialDTO?.Id == 0 ? null : OuterMaterialDTO?.Id;
        //public int? ProcessConditionId => ProcessConditionDTO?.Id == 0 ? null : ProcessConditionDTO?.Id;
        //public int? ProcessFluidId => ProcessFluidDTO?.Id == 0 ? null : ProcessFluidDTO?.Id;
        //public int? BrandId => BrandDTO?.Id == 0 ? null : BrandDTO?.Id;
        //public int? SupplierId => SupplierDTO?.Id == 0 ? null : SupplierDTO?.Id; 
        public string TagLetter => SetTagLetter();

        public string TagId => SetTagId();
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }

        string SetTagLetter()
        {
            string tag = $"{MeasuredVariableDTO?.TagLetter}{MeasuredVariableModifierDTO?.TagLetter}{ReadoutDTO?.TagLetter}{DeviceFunctionDTO?.TagLetter}{DeviceFunctionModifierDTO?.TagLetter}";

            return tag;
        }
        string SetTagId()
        {
            var tag = $"{TagLetter}_{TagNumber}";

            return tag;
        }
    }

    public class MeasuredVariableDTO : AuditableEntityDTO
    {
        public ICollection<InstrumentItemDTO> InstrumentItemDTOs { get; set; } = null!;
        public string? TagLetter { get; set; }
    }
    public class MeasuredVariableModifierDTO : AuditableEntityDTO
    {
        public ICollection<InstrumentItemDTO> InstrumentItemDTOs { get; set; } = null!;
        public string? TagLetter { get; set; }
    }
    public class DeviceFunctionDTO : AuditableEntityDTO
    {
        public ICollection<InstrumentItemDTO> InstrumentItemDTOs { get; set; } = null!;
        public string? TagLetter { get; set; }
    }
    public class DeviceFunctionModifierDTO : AuditableEntityDTO
    {
        public ICollection<InstrumentItemDTO> InstrumentItemDTOs { get; set; } = null!;
        public string? TagLetter { get; set; }
    }
    public class ReadoutDTO : AuditableEntityDTO
    {
        public ICollection<InstrumentItemDTO> InstrumentItemDTOs { get; set; } = null!;
        public string? TagLetter { get; set; }
    }



}
