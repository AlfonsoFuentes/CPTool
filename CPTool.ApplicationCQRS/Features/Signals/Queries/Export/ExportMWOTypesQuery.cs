using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Signals.Queries.Export
{

    public class ExportSignalsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandSignal, bool>? Filter { get; set; }
        public Func<CommandSignal, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandSignal, object?>> Dictionary = new Dictionary<string, Func<CommandSignal, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
