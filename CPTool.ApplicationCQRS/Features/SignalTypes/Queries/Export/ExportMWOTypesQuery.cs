using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.SignalTypes.Queries.Export
{

    public class ExportSignalTypesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandSignalType, bool>? Filter { get; set; }
        public Func<CommandSignalType, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandSignalType, object?>> Dictionary = new Dictionary<string, Func<CommandSignalType, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
