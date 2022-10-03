using CPTool.DTOS;
using CPTool.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    
    public class GasketDTO : AuditableEntityDTO, IMapFrom<Gasket>
    {
        public List<InstrumentItem>? InstrumentItemsDTO { get; set; } = null!;
        public List<EquipmentItemDTO>? EquipmentItemsDTO { get; set; } = null!;
        public List<NozzleDTO>? NozzlesDTO { get; set; } = null!;

    }

}
