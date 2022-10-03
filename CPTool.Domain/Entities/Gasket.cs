using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Domain.Entities
{
    public class Gasket : BaseDomainModel
    {
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;

        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
    }
}
