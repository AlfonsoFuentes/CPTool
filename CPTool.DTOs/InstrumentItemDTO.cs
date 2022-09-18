



namespace CPTool.DTOS
{
   
    public class InstrumentItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
        public MaterialsGroupDTO? MaterialsGroupDTO { get; set; } = new();
        public MeasuredVariableDTO? MeasuredVariableDTO { get; set; } = new();
        public MeasuredVariableModifierDTO? MeasuredVariableModifierDTO { get; set; } = new();
        public DeviceFunctionDTO? DeviceFunctionDTO { get; set; } = new();
        public DeviceFunctionModifierDTO? DeviceFunctionModifierDTO { get; set; } = new();
        public ReadoutDTO? ReadoutDTO { get; set; } = new();
        public BrandDTO? BrandDTO { get; set; } = new();
        public SupplierDTO? SupplierDTO { get; set; } = new();

       
        public int? MaterialsGroupId => MaterialsGroupDTO?.Id;
        public int? MeasuredVariableId => MeasuredVariableDTO?.Id;
        public int? MeasuredVariableModifierId => MeasuredVariableModifierDTO?.Id;
        public int? DeviceFunctionId => DeviceFunctionDTO?.Id;
        public int? DeviceFunctionModifierId => DeviceFunctionModifierDTO?.Id;
        public int? ReadoutId => ReadoutDTO?.Id;
        public int? BrandId => BrandDTO?.Id;
        public int? SupplierId => SupplierDTO?.Id;


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
