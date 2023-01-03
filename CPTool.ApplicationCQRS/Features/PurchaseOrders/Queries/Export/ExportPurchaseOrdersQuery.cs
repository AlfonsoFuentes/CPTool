using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrders.Queries.Export
{

    public class ExportPurchaseOrdersQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandPurchaseOrder> List { get; set; } = new();
        public Dictionary<string, Func<CommandPurchaseOrder, object?>> Dictionary = new Dictionary<string, Func<CommandPurchaseOrder, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "CEC#",item => item.MWOCECName},
                    { "MWO Description",item => item.MWOName},
               
                    { "PO#",item => item.PONumber},
                    { "PR#",item => item.PurchaseRequisition},
                    { "Status",item => item.PurchaseOrderApprovalStatusName},
                    { "PO Currency",item => item.CurrencyName},
                    { "$Value Currency",item => item.PrizeCurrencyValue},
                    { "$Value USD",item => item.PrizeUSDValue},
                    { "Vendor Code",item => item.VendorCode},
                    { "Vendor Name",item => item.SupplierName},
                    { "Tax Code",item => item.TaxCode},
                    { "Cost Center",item => item.CostCenter},
                    { "USD/COP",item => item.USDCOP},
                    { "USD/EUR",item => item.USDEUR},
                    { "Currency date",item => item.CurrencyDate?.ToShortDateString()}

                };
    }
}
