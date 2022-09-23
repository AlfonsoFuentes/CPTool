using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class PipeClassDTO : AuditableEntityDTO, IMapFrom<PipeClass>
    {

        
        public List<PipingItemDTO>? PipingItemsDTO { get; set; } = null!;
        public List<NozzleDTO>? NozzlesDTO { get; set; } = null!;
    }
}
