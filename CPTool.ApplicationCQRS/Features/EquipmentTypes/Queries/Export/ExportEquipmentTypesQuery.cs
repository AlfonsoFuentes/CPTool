using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypes.Queries.Export
{

    public class ExportEquipmentTypesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandEquipmentType, bool>? Filter { get; set; }
        public Func<CommandEquipmentType, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandEquipmentType, object?>> Dictionary = new Dictionary<string, Func<CommandEquipmentType, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
