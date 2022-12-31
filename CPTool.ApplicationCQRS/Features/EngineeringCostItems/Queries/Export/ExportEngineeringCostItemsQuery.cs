using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.EngineeringCostItems.Queries.Export
{

    public class ExportEngineeringCostItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandEngineeringCostItem, bool>? Filter { get; set; }
        public Func<CommandEngineeringCostItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandEngineeringCostItem, object?>> Dictionary = new Dictionary<string, Func<CommandEngineeringCostItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
