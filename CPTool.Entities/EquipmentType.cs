using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Entities
{
    public class EquipmentType   :AuditableEntity
    {
        public string? TagLetter { get; set; } = "";
        public virtual ICollection<EquipmentTypeSub>? EquipmentTypeSubs { get; set; }
        public virtual ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;

    }
}
