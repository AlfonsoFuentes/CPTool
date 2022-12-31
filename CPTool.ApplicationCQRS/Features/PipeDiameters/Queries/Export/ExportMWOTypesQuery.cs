using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Queries.Export
{

    public class ExportPipeDiametersQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandPipeDiameter, bool>? Filter { get; set; }
        public Func<CommandPipeDiameter, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandPipeDiameter, object?>> Dictionary = new Dictionary<string, Func<CommandPipeDiameter, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
