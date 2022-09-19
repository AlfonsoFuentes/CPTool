using CPTool.Entities;
using CPTool.Interfaces;
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
        public  List<EquipmentItemDTO>? EquipmentItemDTOs { get; set; } = new();
        public List<EquipmentTypeSubDTO>? EquipmentTypeSubDTOs
        {
            get
            {
                var values = Details.Select(x => x as EquipmentTypeSubDTO).ToList();
                return values!;
            }
            set
            {
                Details = value!.Select(x => x as AuditableEntityDTO).ToList();
            }
        }


    }
}
