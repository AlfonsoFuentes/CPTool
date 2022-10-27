using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Query.GetById;
using CPTool.Application.Features.MWOItemFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Query.GetById;
using CPTool.Application.Features.PurchaseOrderFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetById;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Services;

namespace CPTool.NewPages.Dialogs.PurchaseOrder.List
{
    public partial class PurchaseOrderList
    {
        [Inject]
        public IMediator mediator { get; set; }

        EditPurchaseOrder SelectedPurchaseOrder { get; set; } = new();
        EditMWOItem SelectedMWOItem { get; set; } = new();

        List<EditPurchaseOrder> PurchaseOrders => GlobalTables.PurchaseOrders;
        List<EditMWOItem> MWOItems = new();
        GetPurchaseOrderListQuery purchaseorderList = new();
        GetMWOItemListQuery mWOItemList = new();


        protected override async Task OnInitializedAsync()
        {

            SelectedPurchaseOrder = PurchaseOrders.FirstOrDefault();
            await AsignPurchaseOrder(SelectedPurchaseOrder);
        }

        async Task RowClickedMaster(EditPurchaseOrder row)
        {

            await AsignPurchaseOrder(row);


        }
        async Task RowClickedDetails(EditMWOItem row)
        {

            await AsignMWOItem(row);


        }
        async Task<DialogResult> ShowPurchaseOrder(EditPurchaseOrderMWOItem pomwo)
        {

            return await ToolDialogService.ShowEditPurchaseOrderDialog(SelectedPurchaseOrder);
        }
        async Task AsignPurchaseOrder(EditPurchaseOrder PO)
        {
            if (PO.Id != 0)
            {
                GetByIdPurchaseOrderQuery query = new() { Id = PO.Id };

                SelectedPurchaseOrder = await mediator.Send(query);

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

                SelectedMWOItem = await mediator.Send(query);



            }
            else
            {
                SelectedMWOItem = new();
            }
        }
    }
}
