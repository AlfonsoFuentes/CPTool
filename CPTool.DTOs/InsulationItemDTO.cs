﻿

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class InsulationItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO> MWOItemDTOs { get; set; } = new();
    }





}
