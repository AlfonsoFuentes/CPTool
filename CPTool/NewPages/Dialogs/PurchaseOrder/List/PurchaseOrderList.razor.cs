
using CPTool.Application.Features.MWOFeatures.Query.GetById;

namespace CPTool.NewPages.Dialogs.PurchaseOrder.List
{
    public partial class PurchaseOrderList
    {

        [Parameter]
        public int MWOId { get; set; }

        EditPurchaseOrder SelectedPurchaseOrder { get; set; } = new();
        EditMWOItem SelectedMWOItem { get; set; } = new();

        List<EditPurchaseOrder> PurchaseOrders => GetPurchaseOrder();
        List<EditMWOItem> MWOItems => SelectedPurchaseOrder.Id == 0 ? new() :
            GlobalTables.PurchaseOrderMWOItems.Where(x => x.PurchaseOrderId == SelectedPurchaseOrder.Id).Select(x => x.MWOItem).ToList();

        List<EditPurchaseOrder> GetPurchaseOrder()
        {

            return SelectedMWOItem.Id != 0 ?
                GlobalTables.PurchaseOrderMWOItems.Where(x => x.MWOItemId == SelectedMWOItem.Id).Select(x => x.PurchaseOrder).ToList()
                 : MWOId != 0 ? 
                 GlobalTables.PurchaseOrders.Where(x => x.MWOId == MWOId).ToList() :
                 GlobalTables.PurchaseOrders;

        }
        EditMWO MWO { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            GetByIdMWOQuery getByIdMWO = new() { Id = MWOId };
            MWO = await Mediator.Send(getByIdMWO);
            if (MWOId == 0) ShowTableDetails = false;
        }

        async Task AddPurchaseOrder()
        {
            CreateEditPurchaseOrder CreatePurchaseOrder = new CreateEditPurchaseOrder();
            CreatePurchaseOrder.PurchaseOrder.MWO = MWO;


            var result = await ToolDialogService.ShowAddPurchaseOrderDialog(CreatePurchaseOrder);

            if (!result.Cancelled)
            {
                var resultdata = result.Data as CreateEditPurchaseOrder;
                await UpdateMaster(resultdata.PurchaseOrder);

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

            GetPurchaseOrderMWOItemListQuery getPurchaseOrderMWOItemListQuery = new();
            GlobalTables.PurchaseOrderMWOItems = await Mediator.Send(getPurchaseOrderMWOItemListQuery);

            GetMWOItemListQuery getMWOItemListQuery = new();
            GlobalTables.MWOItems = await Mediator.Send(getMWOItemListQuery);

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


            GetByIdMWOItemQuery getByIdMWOItem = new() { Id = SelectedMWOItem.Id };

            SelectedMWOItem = await Mediator.Send(getByIdMWOItem);


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

        async Task EditMWOItem()
        {

            var result = await ToolDialogService.ShowMWOItem(SelectedMWOItem);
            if (!result.Cancelled)
            {
                await UpdateDetail(result.Data as EditMWOItem);

            }
        }
        async Task UpdateDetail(EditMWOItem data)
        {
            await UpdateTables();

            GetByIdMWOItemQuery getByIdMWOItem = new() { Id = data.Id };

            SelectedMWOItem = await Mediator.Send(getByIdMWOItem);

            GetByIdPurchaseOrderQuery getByIdPurchaseOrderQuery = new GetByIdPurchaseOrderQuery() { Id = SelectedPurchaseOrder.Id };
            SelectedPurchaseOrder = await Mediator.Send(getByIdPurchaseOrderQuery);

        }
    }
}
