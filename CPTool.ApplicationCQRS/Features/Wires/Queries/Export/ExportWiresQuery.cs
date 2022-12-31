using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Wires.Queries.Export
{

    public class ExportWiresQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandWire, bool>? Filter { get; set; }
        public Func<CommandWire, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandWire, object?>> Dictionary = new Dictionary<string, Func<CommandWire, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
