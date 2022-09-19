using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class ProcessFluidDTO : AuditableEntityDTO
    {
        public List<EquipmentItemDTO>? EquipmentItemsDTO { get; set; } = new();
        public List<InstrumentItemDTO>? InstrumentItemsDTO { get; set; } = new();
        public List<PipingItemDTO>? PipingItemsDTO { get; set; } = new();
        public List<ProcessConditionDTO>? ProcessConditionDTO { get; set; } = new();
    }
}
