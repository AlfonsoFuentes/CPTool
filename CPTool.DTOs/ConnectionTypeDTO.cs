﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class ConnectionTypeDTO : AuditableEntityDTO, IMapFrom<ConnectionType>
    {
        public List<NozzleDTO>? NozzlesDTO { get; set; } = new();
    }
}
