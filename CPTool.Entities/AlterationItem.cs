

using System.Linq.Expressions;

namespace CPTool.Entities
{
   
    public class AlterationItem : AuditableEntity
    {
        public AlterationItem()
        {
            
        }
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;


    }





}
