using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Domain.Entities
{
    public class UnitaryBasePrize : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }
}
