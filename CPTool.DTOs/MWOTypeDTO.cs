

namespace CPTool.DTOS
{
    public class MWOTypeDTO : AuditableEntityDTO, IMapFrom<MWOType>
    {
      
        public List<MWODTO>? MWODTOs { get; set; } = new();
    }





}
