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
   
    public class EquipmentTypeDTO : AuditableEntityDTO, IAuditableEntityDTO
    {

        public string? TagLetter { get; set; } = "";
        public  List<EquipmentItemDTO>? EquipmentItemsDTO { get; set; } = new();
        public List<EquipmentTypeSubDTO>? EquipmentTypeSubsDTO
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
