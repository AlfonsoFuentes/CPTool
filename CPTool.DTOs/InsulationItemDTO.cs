



namespace CPTool.DTOS
{
    
    public class InsulationItemDTO : AuditableEntityDTO, IMapFrom<InsulationItem>
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
    }





}
