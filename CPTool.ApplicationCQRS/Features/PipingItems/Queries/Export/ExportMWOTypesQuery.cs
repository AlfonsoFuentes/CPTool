using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Queries.Export
{

    public class ExportPipingItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandPipingItem, bool>? Filter { get; set; }
        public Func<CommandPipingItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandPipingItem, object?>> Dictionary = new Dictionary<string, Func<CommandPipingItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
