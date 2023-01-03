using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Readouts.Queries.Export
{

    public class ExportReadoutsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandReadout> List { get; set; } = new();
        public Dictionary<string, Func<CommandReadout, object?>> Dictionary = new Dictionary<string, Func<CommandReadout, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
