
using CPTool.Application.Features.MWOFeatures.Query.GetById;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeatures.Query.GetList;

namespace CPTool.NewPages.Dialogs.PurchaseOrder.List
{
    public partial class PurchaseOrderListByMWO
    {

        [Parameter]
        public int MWOId { get; set; }
        EditPurchaseOrderItem SelectedPurchaseOrderItem { get; set; } = new();
        EditPurchaseOrder SelectedPurchaseOrder { get; set; } = new();


        List<EditPurchaseOrder> PurchaseOrders => GetPurchaseOrders();// GlobalTables.PurchaseOrders.Where(x => x.MWOId == MWOId).ToList();
        List<EditPurchaseOrderItem> PurchaseOrderItems => SelectedPurchaseOrder.Id == 0 ? new() :
            GlobalTables.PurchaseOrderItems.Where(x => x.PurchaseOrderId == SelectedPurchaseOrder.Id).ToList();

       
        List<EditPurchaseOrder> GetPurchaseOrders()
        {
            List<EditPurchaseOrder> retorno = GlobalTables.PurchaseOrders.Where(x => x.MWOId == MWOId).ToList();
            if (SelectedPurchaseOrderItem.Id != 0)
            {
                
                var mwoitem = SelectedPurchaseOrderItem.MWOItem;
                var purchaseorderitems = GlobalTables.PurchaseOrderItems.Where(x => x.MWOItemId == mwoitem.Id).Select(x => x.PurchaseOrder).ToList();
                retorno = retorno.Where(x => x.PurchaseOrderItems.Any(x => x.MWOItemId == SelectedPurchaseOrderItem.MWOItem.Id)).ToList();
            }

            return retorno;
        }
        EditMWO MWO => GlobalTables.MWOs.FirstOrDefault(x => x.Id == MWOId);
     
        async Task AddPurchaseOrder()
        {
            EditPurchaseOrder CreatePurchaseOrder = new EditPurchaseOrder();
            CreatePurchaseOrder.MWO = MWO;


            var result = await ToolDialogService.ShowAddPurchaseOrderDialog(CreatePurchaseOrder);

            if (!result.Cancelled)
            {
                var resultdata = result.Data as EditPurchaseOrder;
                await UpdateMaster(resultdata);

            }

        }
        async Task EditPurchaseOrder()
        {
            var result = await ToolDialogService.ShowEditPurchaseOrderDialog(SelectedPurchaseOrder);
            if (!result.Cancelled)
            {
                await UpdateMaster(result.Data as EditPurchaseOrder);

            }
        }
        async Task UpdateTables()
        {
            GetMWOListQuery getMWOList = new();
            GlobalTables.MWOs = await Mediator.Send(getMWOList);



            GetPurchaseOrderItemListQuery getPurchaseOrderItemListQuery = new();
            GlobalTables.PurchaseOrderItems = await Mediator.Send(getPurchaseOrderItemListQuery);

            GetPurchaseOrderListQuery getPurchaseOrderListQuery = new();
            GlobalTables.PurchaseOrders = await Mediator.Send(getPurchaseOrderListQuery);

            GetTaksListQuery getTaksListQuery = new();
            GlobalTables.Takss = await Mediator.Send(getTaksListQuery);
        }
        async Task UpdateMaster(EditPurchaseOrder data)
        {

            await UpdateTables();
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

       
        async Task UpdateDetail(EditMWOItem data)
        {
            await UpdateTables();



            GetByIdPurchaseOrderQuery getByIdPurchaseOrderQuery = new GetByIdPurchaseOrderQuery() { Id = SelectedPurchaseOrder.Id };
            SelectedPurchaseOrder = await Mediator.Send(getByIdPurchaseOrderQuery);

        }
    }
}
