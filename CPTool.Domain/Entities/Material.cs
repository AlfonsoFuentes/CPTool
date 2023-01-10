using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Domain.Entities
{
    public class Material : AuditableEntity
    {


        [ForeignKey("paMaterialId")]
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;
        public string? Abbreviation { get; set; }

       
        [ForeignKey("nMaterialId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;

        [ForeignKey("InnerMaterialId")]
        public ICollection<MWOItem>? MWOItemInnerMaterials { get; set; } = null!;

        [ForeignKey("MaterialOuterId")]
        public ICollection<MWOItem>? MWOItemOuterMaterials { get; set; } = null!;
    }
}
