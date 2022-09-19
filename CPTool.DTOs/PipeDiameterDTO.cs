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

        public UnitDTO? ODDTO { get; set; } = new() { Amount = new Length(LengthUnits.Inch) };
        public UnitDTO? IDDTO { get; set; } = new() { Amount = new Length(LengthUnits.Inch) };
        public UnitDTO? ThicknessDTO { get; set; } = new() { Amount = new Length(LengthUnits.Inch) };


        public int? ODId => ODDTO ?. Id;
        public int? IDId => IDDTO?.Id;
        public int? ThicknessId => ThicknessDTO?.Id;
    }
}
