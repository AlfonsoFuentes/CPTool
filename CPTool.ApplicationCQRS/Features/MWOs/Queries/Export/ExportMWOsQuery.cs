using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.MWOs.Queries.Export
{

    public class ExportMWOsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandMWO, bool>? Filter { get; set; }
        public Func<CommandMWO, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandMWO, object?>> Dictionary = new Dictionary<string, Func<CommandMWO, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
