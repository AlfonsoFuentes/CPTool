using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Domain.Entities
{
    public class Material : BaseDomainModel
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
        [ForeignKey("pMaterialId")]
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        [ForeignKey("nMaterialId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;


    }
}
