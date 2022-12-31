using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.AlterationItems.Queries.Export
{

    public class ExportAlterationItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandAlterationItem, bool>? Filter { get; set; }
        public Func<CommandAlterationItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandAlterationItem, object?>> Dictionary = new Dictionary<string, Func<CommandAlterationItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
