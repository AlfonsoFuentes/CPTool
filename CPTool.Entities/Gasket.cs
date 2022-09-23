using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Entities
{
    public class Gasket :AuditableEntity
    {
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;

        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
    }
}
