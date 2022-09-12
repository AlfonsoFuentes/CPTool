﻿using CPTool.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
   
    public class EquipmentTypeDTO : AuditableEntityDTO
    {

        public string? TagLetter { get; set; } = "";
        public virtual List<EquipmentItemDTO> EquipmentItemDTOs { get; set; } = new();
        public List<EquipmentTypeSubDTO> EquipmentTypeSubDTOs { get; set; } = new();
    }
}
