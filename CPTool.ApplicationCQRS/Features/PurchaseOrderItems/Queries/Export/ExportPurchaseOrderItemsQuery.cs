using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
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
        public List<CommandPurchaseOrderItem> List { get; set; } = new();
        public Dictionary<string, Func<CommandPurchaseOrderItem, object?>> Dictionary = new Dictionary<string, Func<CommandPurchaseOrderItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Item TagId",item => item.MWOItemTag}
            ,
                    { "Item Name",item => item.MWOItemName}
            ,
                    { "$Value PO Currency",item => item.PrizeCurrency}
            ,
                    { "$Value USD",item => item.PrizeUSD}
            ,
                  
                };
    }
}
