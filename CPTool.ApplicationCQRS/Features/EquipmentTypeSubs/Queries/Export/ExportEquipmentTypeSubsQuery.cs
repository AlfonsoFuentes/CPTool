using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Queries.Export
{

    public class ExportEquipmentTypeSubsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandEquipmentTypeSub, bool>? Filter { get; set; }
        public Func<CommandEquipmentTypeSub, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandEquipmentTypeSub, object?>> Dictionary = new Dictionary<string, Func<CommandEquipmentTypeSub, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
