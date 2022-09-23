using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class PipeDiameterDTO : AuditableEntityDTO, IMapFrom<PipeDiameter>
    {
        public PipeDiameterDTO() 
        {
        }
        public List<PipingItemDTO>? PipingItemsDTO { get; set; } = null!;
        public List<NozzleDTO>? NozzlesDTO { get; set; } = null!;

        public UnitDTO? ODDTO { get; set; } = new(LengthUnits.Inch);
        public UnitDTO? IDDTO { get; set; } = new(LengthUnits.Inch) ;
        public UnitDTO? ThicknessDTO { get; set; } = new(LengthUnits.Inch) ;


        
    }
}
