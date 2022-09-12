﻿using CPTool.DTOS;
using CPTool.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    
    public class GasketDTO : AuditableEntityDTO
    {
        public virtual List<EquipmentItemDTO> EquipmentItemDTOs { get; set; } = new();

    }

}