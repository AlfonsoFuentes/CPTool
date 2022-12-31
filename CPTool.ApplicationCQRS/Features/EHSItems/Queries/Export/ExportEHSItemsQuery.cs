using CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.EHSItems.Queries.Export
{

    public class ExportEHSItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandEHSItem, bool>? Filter { get; set; }
        public Func<CommandEHSItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandEHSItem, object?>> Dictionary = new Dictionary<string, Func<CommandEHSItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
