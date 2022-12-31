using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Nozzles.Queries.Export
{

    public class ExportNozzlesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandNozzle, bool>? Filter { get; set; }
        public Func<CommandNozzle, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandNozzle, object?>> Dictionary = new Dictionary<string, Func<CommandNozzle, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
