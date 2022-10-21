using CPTool.Domain.Common;
using System.Linq.Expressions;

namespace CPTool.Domain.Entities
{

    public class AlterationItem : BaseDomainModel
    {

        [ForeignKey("AlterationItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

        public string CostCenter { get; set; } = null!;
    }





}
