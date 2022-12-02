
using CPTool.Application.Features.MWOFeatures.Query.GetById;

namespace CPTool.NewPages.Dialogs.PurchaseOrder.List
{
    public partial class PurchaseOrderList
    {


        EditPurchaseOrder SelectedPurchaseOrder { get; set; } = new();
      

        List<EditPurchaseOrder> PurchaseOrders => GlobalTables.PurchaseOrders;
      
       
        async Task EditPurchaseOrder()
        {
            var result = await ToolDialogService.ShowEditPurchaseOrderDialog(SelectedPurchaseOrder);
            if (!result.Cancelled)
            {
                await UpdateMaster(result.Data as EditPurchaseOrder);

            }
        }
        
        async Task UpdateMaster(EditPurchaseOrder data)
        {

            GetPurchaseOrderListQuery getPurchaseOrderListQuery = new();
            GlobalTables.PurchaseOrders = await Mediator.Send(getPurchaseOrderListQuery);

            GetTaksListQuery getTaksListQuery = new();
            GlobalTables.Takss = await Mediator.Send(getTaksListQuery);
            GetByIdPurchaseOrderQuery getById = new();
            getById.Id = data.Id;
            SelectedPurchaseOrder = await Mediator.Send(getById);


          


        }
        async Task AddDownPayment()
        {
            EditDownPayment model = new();
            model.PurchaseOrder = SelectedPurchaseOrder;
            var result = await ToolDialogService.ShowDownpaymentDialog(model);

            if (!result.Cancelled)
            {
                GetDownPaymentListQuery getDownPaymentListQuery = new GetDownPaymentListQuery();
                GlobalTables.DownPayments = await Mediator.Send(getDownPaymentListQuery);

                GetTaksListQuery getTaksListQuery = new();
                GlobalTables.Takss = await Mediator.Send(getTaksListQuery);
            }

        }

      
    }
}
