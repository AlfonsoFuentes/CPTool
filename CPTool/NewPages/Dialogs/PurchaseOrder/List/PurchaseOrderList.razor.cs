
namespace CPTool.NewPages.Dialogs.PurchaseOrder.List
{
    public partial class PurchaseOrderList
    {
      

        EditPurchaseOrder SelectedPurchaseOrder { get; set; } = new();
        EditMWOItem SelectedMWOItem { get; set; } = new();

        List<EditPurchaseOrder> PurchaseOrders => GlobalTables.PurchaseOrders;
        List<EditMWOItem> MWOItems = new();
        GetPurchaseOrderListQuery purchaseorderList = new();
       


        async Task RowClickedMaster(EditPurchaseOrder row)
        {

            await AsignPurchaseOrder(row);


        }
        async Task RowClickedDetails(EditMWOItem row)
        {

            await AsignMWOItem(row);


        }
        async Task AddDownPayment()
        {
            EditDownPayment model = new();
            model.PurchaseOrder = SelectedPurchaseOrder;
            var result = await   ToolDialogService.ShowDownpaymentDialog(model);

            if (!result.Cancelled)
            {
                GetDownPaymentListQuery getDownPaymentListQuery = new GetDownPaymentListQuery();
                GlobalTables.DownPayments = await Mediator.Send(getDownPaymentListQuery);

                GetTaksListQuery getTaksListQuery = new();
                GlobalTables.Takss = await Mediator.Send(getTaksListQuery);
            }

        }
        async Task<DialogResult> ShowPurchaseOrder(EditPurchaseOrderMWOItem pomwo)
        {

            var result = await ToolDialogService.ShowEditPurchaseOrderDialog(SelectedPurchaseOrder);
            if (!result.Cancelled)
            {
                GlobalTables.PurchaseOrders = await Mediator.Send(purchaseorderList);
                GetTaksListQuery getTaksListQuery = new();
                GlobalTables.Takss = await Mediator.Send(getTaksListQuery);
            }
            return result;
        }
        async Task AsignPurchaseOrder(EditPurchaseOrder PO)
        {
            if (PO != null && PO.Id != 0)
            {
                GetByIdPurchaseOrderQuery query = new() { Id = PO.Id };

                SelectedPurchaseOrder = await Mediator.Send(query);

                MWOItems = GlobalTables.PurchaseOrderMWOItems.Where(x => x.PurchaseOrderId == SelectedPurchaseOrder.Id).Select(x => x.MWOItem).ToList();// SelectedBrand.BrandSuppliers.Select(x => x.Supplier).ToList();

            }
            else
            {
                SelectedPurchaseOrder = new();

            }

        }
        async Task AsignMWOItem(EditMWOItem mwoitem)
        {
            if (mwoitem.Id != 0)
            {
                GetByIdMWOItemQuery query = new() { Id = mwoitem.Id };

                SelectedMWOItem = await Mediator.Send(query);



            }
            else
            {
                SelectedMWOItem = new();
            }
        }
    }
}
