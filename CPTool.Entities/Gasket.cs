using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Entities
{
    public class Gasket :AuditableEntity
    {

        public virtual ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;
    }
}
