using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.StructuralItems.Queries.Export
{

    public class ExportStructuralItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandStructuralItem, bool>? Filter { get; set; }
        public Func<CommandStructuralItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandStructuralItem, object?>> Dictionary = new Dictionary<string, Func<CommandStructuralItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
