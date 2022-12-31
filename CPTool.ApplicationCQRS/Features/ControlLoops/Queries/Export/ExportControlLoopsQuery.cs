using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ControlLoops.Queries.Export
{

    public class ExportControlLoopsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandControlLoop, bool>? Filter { get; set; }
        public Func<CommandControlLoop, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandControlLoop, object?>> Dictionary = new Dictionary<string, Func<CommandControlLoop, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
