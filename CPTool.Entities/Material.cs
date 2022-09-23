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

        [ForeignKey("iInnerMaterialId")]
        public ICollection<InstrumentItem>? InstrumentItemInnerMaterials { get; set; } = null!;

        [ForeignKey("iOuterMaterialId")]
        public ICollection<InstrumentItem>? InstrumentItemOuterMaterials { get; set; } = null!;

        [ForeignKey("eInnerMaterialId")]
        public ICollection<EquipmentItem>? EquipmentItemInnerMaterials { get; set; } = null!;

        [ForeignKey("eOuterMaterialId")]
        public ICollection<EquipmentItem>? EquipmentItemOuterMaterials { get; set; } = null!;

        public ICollection<PipingItem>? PipingItems { get; set; } = null!;

        public ICollection<Nozzle>? Nozzles { get; set; } = null!;


    }
}
