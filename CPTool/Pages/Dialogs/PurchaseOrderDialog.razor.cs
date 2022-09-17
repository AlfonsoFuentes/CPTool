using CPTool.Entities;

namespace CPTool.Pages.Dialogs
{
    public partial class PurchaseOrderDialog
    {


        [Parameter]
        public PurchaseOrderMWOItemDTO Model { get; set; }

        

        async Task Initializeform()
        {
            await Task.Run(() =>
            {
                Model.PurchaseOrderDTO.USDCOP = 4000;// Math.Round(_CurrencyService.RateList["COP"], 2);
                Model.PurchaseOrderDTO.USDEUR = 1;// Math.Round(_CurrencyService.RateList["EUR"], 2);
                if (Model.PurchaseOrderDTO.PurchaseOrderStatus == PurchaseOrderStatus.Ordering)
                    Model.PurchaseOrderDTO.POEstimatedDate = DateTime.UtcNow;
                Model.PurchaseOrderDTO.SetButtonNameHistory();

            });

        }
        async Task BeforeClose()
        {
            Model.PurchaseOrderDTO.ChangeStatusPO();

            if (!Model.PurchaseOrderCreated)
            {
                var result = await TablesService.ManPurchaseOrder.AddUpdate(Model.PurchaseOrderDTO, _cts.Token);
                if (result.Succeeded)
                {

                    Model.PurchaseOrderDTO = result.Data;
                    await TablesService.ManPurchaseOrderMWOItem.AddUpdate(Model, _cts.Token);
                    await TablesService.ManPurchaseOrderMWOItem.UpdateList();
                    await TablesService.ManPurchaseOrder.UpdateList();
                }
            }
        }

        private string ValidateCurrency(Currency arg)
        {
            if (arg == Currency.None)
                return "Must submit Currency";


            return null;
        }
        private string ValidatePONumber(string arg)
        {


            if (arg == "")
                return "Must define PO number";
            if (!arg.StartsWith("850"))
                return "PO number must start with 850";
            if (arg.Length != 10)
                return "PO number must have ten numbers";
            if (TablesService.ManPurchaseOrderMWOItem.List.Where(x => x.MWOItemId != Model.MWOItemDTO.Id).Any(x => x.PurchaseOrderDTO.PONumber == arg))
                return "PO number existing";
            return null;

        }
        private string ValidatePOAmount(double arg)
        {
            if (arg <= 0)
                return "PO Value must be greater than zero";
            return null;
        }
    }
}
