using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class PipeDiameterDTO : AuditableEntityDTO
    {
        public List<PipingItemDTO>? PipingItemsDTO { get; set; } = new();
        public List<NozzleDTO>? NozzlesDTO { get; set; } = new();

        public UnitDTO? ODDTO { get; set; }
        public UnitDTO? IDDTO { get; set; }
        public UnitDTO? ThicknessDTO { get; set; }


        public int? ODId => ODDTO ?. Id;
        public int? IDId => IDDTO?.Id;
        public int? ThicknessId => ThicknessDTO?.Id;
    }
}
