using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Entities
{
    public class UnitaryBasePrize  :AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }
}
