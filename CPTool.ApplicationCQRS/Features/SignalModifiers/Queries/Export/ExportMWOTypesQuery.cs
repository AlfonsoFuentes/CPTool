using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Queries.Export
{

    public class ExportSignalModifiersQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandSignalModifier, bool>? Filter { get; set; }
        public Func<CommandSignalModifier, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandSignalModifier, object?>> Dictionary = new Dictionary<string, Func<CommandSignalModifier, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
