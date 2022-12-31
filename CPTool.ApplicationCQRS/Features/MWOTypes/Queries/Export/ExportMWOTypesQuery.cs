using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.MWOTypes.Queries.Export
{

    public class ExportMWOTypesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandMWOType, bool>? Filter { get; set; }
        public Func<CommandMWOType, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandMWOType, object?>> Dictionary = new Dictionary<string, Func<CommandMWOType, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
