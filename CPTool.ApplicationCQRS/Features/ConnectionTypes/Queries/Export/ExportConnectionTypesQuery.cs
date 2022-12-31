using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ConnectionTypes.Queries.Export
{

    public class ExportConnectionTypesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandConnectionType, bool>? Filter { get; set; }
        public Func<CommandConnectionType, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandConnectionType, object?>> Dictionary = new Dictionary<string, Func<CommandConnectionType, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
