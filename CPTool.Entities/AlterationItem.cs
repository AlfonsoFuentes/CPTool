

using System.Linq.Expressions;

namespace CPTool.Entities
{
   
    public class AlterationItem : AuditableEntity
    {
       
        public  ICollection<MWOItem> MWOItems { get; set; } = null!;

        public string CostCenter { get; set; } = null!;
    }





}
