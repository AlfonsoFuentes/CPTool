using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.TestingItems.Queries.Export
{

    public class ExportTestingItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandTestingItem> List { get; set; } = new();
        public Dictionary<string, Func<CommandTestingItem, object?>> Dictionary = new Dictionary<string, Func<CommandTestingItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
