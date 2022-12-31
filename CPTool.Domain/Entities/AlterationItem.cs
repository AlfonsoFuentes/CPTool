

namespace CPTool.Domain.Entities
{

    public class AlterationItem : AuditableEntity
    {

        [ForeignKey("AlterationItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

        public string? CostCenter { get; set; } = null!;
    }




}
