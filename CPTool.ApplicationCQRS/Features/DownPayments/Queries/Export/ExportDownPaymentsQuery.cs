using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.DownPayments.Queries.Export
{

    public class ExportDownPaymentsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandDownPayment> List { get; set; } = new();
        public Dictionary<string, Func<CommandDownPayment, object?>> Dictionary = new Dictionary<string, Func<CommandDownPayment, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Description",item => item.DownpaymentDescrption},
                    { "Name",item => item.DownpaymentName},
                    { "MWO#",item => item.PurchaseorderMWOName},
                    { "PO#",item => item.PurchaseOrderPO}
            ,
                    { "PO Name",item => item.PurchaseOrderName}
            
            
            ,
                    { "Vendor",item => item.PurchaseOrderSupplier}
            ,
                    { "Vendor Code",item => item.PurchaseOrderSupplierVendorCode}
            ,
                    { "Request Date",item => item.RequestDateText}
             ,
                    { "CBS Request No",item => item.CBSRequesNo}
            
           
            ,
                    { "Status",item => item.DownpaymentStatusName}
            ,
                    { "PayTerms",item => item.Payterms}
            ,
                    { "Percentage",item => item.Percentage},
                    { "Amount Paid",item => item.DownPaymentAmount}
            

                };
    }
}
