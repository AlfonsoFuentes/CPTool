using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Queries.Export
{

    public class ExportPurchaseOrderItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandPurchaseOrderItem, bool>? Filter { get; set; }
        public Func<CommandPurchaseOrderItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandPurchaseOrderItem, object?>> Dictionary = new Dictionary<string, Func<CommandPurchaseOrderItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
