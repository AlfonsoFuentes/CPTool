using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Queries.Export
{

    public class ExportEquipmentItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandEquipmentItem, bool>? Filter { get; set; }
        public Func<CommandEquipmentItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandEquipmentItem, object?>> Dictionary = new Dictionary<string, Func<CommandEquipmentItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
