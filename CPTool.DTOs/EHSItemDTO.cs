﻿

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
  
    public class EHSItemDTO : AuditableEntityDTO, IMapFrom<EHSItem>
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
    }





}
