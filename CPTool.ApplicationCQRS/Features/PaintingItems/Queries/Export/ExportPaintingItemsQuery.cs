using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PaintingItems.Queries.Export
{

    public class ExportPaintingItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandPaintingItem, bool>? Filter { get; set; }
        public Func<CommandPaintingItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandPaintingItem, object?>> Dictionary = new Dictionary<string, Func<CommandPaintingItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
