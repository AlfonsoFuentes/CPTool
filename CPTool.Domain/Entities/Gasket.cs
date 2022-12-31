using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Domain.Entities
{
    public class Gasket : AuditableEntity
    {
        [ForeignKey("nGasketId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;

        [ForeignKey("eGasketId")]
        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        [ForeignKey("iGasketId")]
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
    }
}
