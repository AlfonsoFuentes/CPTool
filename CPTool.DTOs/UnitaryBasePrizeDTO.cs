using CPTool.DTOS;
using CPTool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class UnitaryBasePrizeDTO  :AuditableEntityDTO
    {
        public virtual ICollection<MWOItemDTO> MWOItemDTOs { get; set; }
    }
}
