using CPTool.Domain.Entities;

namespace CPTool.Pages.Dialogs
{
    public partial class PurchaseOrderDialog
    {


        //[Parameter]
        //public PurchaseOrderMWOItemDTO Model { get; set; }
        //[Inject]
        //public IGetList<PurchaseOrderDTO, PurchaseOrder> POList { get; set; }
        //[Inject]
        //public IDTOManager<PurchaseOrderDTO,PurchaseOrder> POManager { get; set; }
        //[Inject]
        //public IDTOManager<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem> POItemManager { get; set; }
        //async Task Initializeform()
        //{
        //    Model.PurchaseOrderDTO.USDCOP = 4000;// Math.Round(_CurrencyService.RateList["COP"], 2);
        //    Model.PurchaseOrderDTO.USDEUR = 1;// Math.Round(_CurrencyService.RateList["EUR"], 2);
        //    if (Model.PurchaseOrderDTO.PurchaseOrderStatus == PurchaseOrderStatus.Ordering)
        //        Model.PurchaseOrderDTO.POEstimatedDate = DateTime.UtcNow;
        //    Model.PurchaseOrderDTO.SetButtonNameHistory();

        //   await Task.CompletedTask;

        //}
        //async Task BeforeClose()
        //{
        //    Model.PurchaseOrderDTO.ChangeStatusPO();

        //    if (!Model.PurchaseOrderCreated)
        //    {
        //        var result = await POManager.AddUpdate(Model.PurchaseOrderDTO, _cts.Token);
        //        if (result.Succeeded)
        //        {

        //            //Model.PurchaseOrderDTO = result.Data as PurchaseOrderDTO;
        //            await POItemManager.AddUpdate(Model, _cts.Token);

        //            TablesService.PurchaseOrders = await POList.Handle();
        //        }
        //    }
        //}

        //private string ValidateCurrency(Currency arg)
        //{
        //    if (arg == Currency.None)
        //        return "Must submit Currency";


        //    return null;
        //}
        //private string ValidatePONumber(string arg)
        //{


        //    if (arg == "")
        //        return "Must define PO number";
        //    if (!arg.StartsWith("850"))
        //        return "PO number must start with 850";
        //    if (arg.Length != 10)
        //        return "PO number must have ten numbers";
        //    if (TablesService.PurchaseOrderMWOItems.Where(x => x.MWOItemDTO.Id != Model.MWOItemDTO.Id).Any(x => x.PurchaseOrderDTO.PONumber == arg))
        //        return "PO number existing";
        //    return null;

        //}
        //private string ValidatePOAmount(double arg)
        //{
        //    if (arg <= 0)
        //        return "PO Value must be greater than zero";
        //    return null;
        //}
    }
}
