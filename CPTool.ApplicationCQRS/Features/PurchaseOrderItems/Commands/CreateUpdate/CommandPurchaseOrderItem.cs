using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate
{
    public class CommandPurchaseOrderItem : CommandBase, IRequest<PurchaseOrderItemCommandResponse>
    {


       
        public override string Name { get => name; set => base.Name = name; }
        string name => MWOItem != null ? MWOItem.Name : "";
        public int? PurchaseOrderId => PurchaseOrder?.Id == 0 ? null : PurchaseOrder?.Id;
        public CommandPurchaseOrder? PurchaseOrder { get; set; }
        public string PurchaseorderName => PurchaseOrder == null ? "" : PurchaseOrder!.Name;
        public string PurchaseorderPONumber => PurchaseOrder == null ? "" : PurchaseOrder!.PONumber;
        public string PurchaseorderSupplier => PurchaseOrder!.pSupplier == null ? "" : PurchaseOrder!.pSupplier!.Name;
        public int? MWOItemId => MWOItem?.Id == 0 ? null : MWOItem?.Id;
        public CommandMWOItem? MWOItem { get; set; }
        public string MWOItemName => MWOItem == null ? "" : MWOItem!.Name;
        public string MWOItemTag => MWOItem == null ? "" : MWOItem!.TagId;
      
        public string CurrencyName => Currency.ToString();
        public Currency Currency => PurchaseOrder!.Currency;
       
        public double PrizeCurrency { get; set; }
        
        public double PrizeUSD
        {
            get => Currency == Currency.USD ? PrizeCurrency :
                Currency == Currency.COP ? Math.Round(PrizeCurrency / PurchaseOrder!.USDCOP, 2) : Math.Round(PrizeCurrency / PurchaseOrder!.USDEUR, 2);

        }
 
        public double Tax { get; set; } = 0.19;
    
        public double PrizeCurrencyTax => Tax * PrizeCurrency;
    
        public double TotalPrizeCurrency => PrizeCurrency + PrizeCurrencyTax;
     
        public double ValueExchangeRate => Currency == Currency.EUR ? Currency == Currency.USD ? 1 : PurchaseOrder!.USDEUR : PurchaseOrder!.USDCOP;

        public double ActualValue => (PurchaseOrder!.StatusPurchaseOrder == StatusPurchaseOrder.Actual) ? PrizeUSD : 0;
        public double CommitmentValue => (PurchaseOrder!.StatusPurchaseOrder == StatusPurchaseOrder.Commitment) ? PrizeUSD : 0;


    }

}
