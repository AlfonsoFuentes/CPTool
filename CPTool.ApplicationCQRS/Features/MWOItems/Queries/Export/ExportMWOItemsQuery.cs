using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Queries.Export
{

    public class ExportMWOItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandMWOItem, bool>? Filter { get; set; }
        public Func<CommandMWOItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandMWOItem, object?>> Dictionary = new Dictionary<string, Func<CommandMWOItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
