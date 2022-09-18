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
        public ICollection<MaterialsGroup>? InnerMaterials { get; set; } = null!;

        [ForeignKey("OuterMaterialId")]
        public ICollection<MaterialsGroup>? OuterMaterials { get; set; } = null!;

        public ICollection<PipingItem>? PipingItems { get; set; } = null!;



    }
}
