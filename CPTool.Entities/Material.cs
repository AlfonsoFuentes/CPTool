using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Entities
{
    public class Material :AuditableEntity
    {
        public string? Abbreviation { get; set; }

        [ForeignKey("InnerMaterialId")]
        public virtual ICollection<EquipmentItem> InnerMaterials { get; set; } = null!;

        [ForeignKey("OuterMaterialId")]
        public virtual ICollection<EquipmentItem> OuterMaterials { get; set; } = null!;
    }
}
