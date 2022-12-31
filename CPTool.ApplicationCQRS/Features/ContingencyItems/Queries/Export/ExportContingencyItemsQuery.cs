using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ContingencyItems.Queries.Export
{

    public class ExportContingencyItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandContingencyItem, bool>? Filter { get; set; }
        public Func<CommandContingencyItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandContingencyItem, object?>> Dictionary = new Dictionary<string, Func<CommandContingencyItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
