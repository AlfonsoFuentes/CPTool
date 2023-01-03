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

        public List<CommandAlterationItem> List { get; set; } = new();
        public string Type { get; set; } = string.Empty;
       
        public Dictionary<string, Func<CommandAlterationItem, object?>> Dictionary = new Dictionary<string, Func<CommandAlterationItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
