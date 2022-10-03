



namespace CPTool.DTOS
{
    
    public class InsulationItemDTO : AuditableEntityDTO, IMapFrom<InsulationItem>
    {
        public List<MWOItemDTO>? MWOItemsDTO { get; set; } = new();
    }





}
