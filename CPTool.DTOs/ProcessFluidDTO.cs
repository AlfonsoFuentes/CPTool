using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class ProcessFluidDTO : AuditableEntityDTO, IMapFrom<ProcessFluid>
    {
        public ProcessFluidDTO()
        {

        }
        public List<EquipmentItemDTO>? EquipmentItemsDTO { get; set; } = null;
        public List<InstrumentItemDTO>? InstrumentItemsDTO { get; set; } = null;
        public List<PipingItemDTO>? PipingItemsDTO { get; set; } = null;
        //public List<ProcessConditionDTO>? ProcessConditionDTO { get; set; } = null;
    }
}
