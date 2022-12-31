using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Gaskets.Queries.Export
{

    public class ExportGasketsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandGasket, bool>? Filter { get; set; }
        public Func<CommandGasket, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandGasket, object?>> Dictionary = new Dictionary<string, Func<CommandGasket, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
