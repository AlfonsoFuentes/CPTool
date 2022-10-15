using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Domain.Common
{
   
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdateBy { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
