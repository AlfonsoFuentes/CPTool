using CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.FoundationItems.Queries.Export
{

    public class ExportFoundationItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandFoundationItem, bool>? Filter { get; set; }
        public Func<CommandFoundationItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandFoundationItem, object?>> Dictionary = new Dictionary<string, Func<CommandFoundationItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
