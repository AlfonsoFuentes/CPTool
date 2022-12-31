using CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.InsulationItems.Queries.Export
{

    public class ExportInsulationItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandInsulationItem, bool>? Filter { get; set; }
        public Func<CommandInsulationItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandInsulationItem, object?>> Dictionary = new Dictionary<string, Func<CommandInsulationItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
