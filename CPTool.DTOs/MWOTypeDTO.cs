

namespace CPTool.DTOS
{
    public class MWOTypeDTO : AuditableEntityDTO, IMapFrom<MWOType>
    {
      
        public List<MWODTO>? MWOsDTO { get; set; } = new();
    }





}
