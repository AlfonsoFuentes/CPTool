

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool2.NewPages.Dialogs.PurchaseOrder.Dialog
{
    public partial class CreatePurchaseOrderDialog
    {
        List<EditMWOItem> EditMWOItemsOriginal => Model.PurchaseOrder.MWO.MWOItems;
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public CreateEditPurchaseOrder Model { get; set; } = null!;

        [Inject]
        public IMediator mediator { get; set; }

        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task ValidateForm()
        {
            await form.Validate();
        }

        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {
                Model.PurchaseOrder.POCreatedDate = DateTime.UtcNow;
                Model.PurchaseOrder.PurchaseOrderStatus = CPTool.Domain.Entities.PurchaseOrderStatus.Ordering;
                await mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();

        private string ValidatePurchaseOrderName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Purchase Order name";

            return null;
        }
        private string ValidatePurchaseRequisition(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Purchase Requistion Name";

            if (arg.StartsWith("PR") || arg.StartsWith("RFQ"))
                return null;
            else
                return "Must submit Valid code PR or RFQ";

        }
        void BrandChanged(EditBrand brand)
        {

            Model.PurchaseOrder.pSupplier = new();
            StateHasChanged();
        }
        public class DropItem
        {
            public EditMWOItem MWOItem { get; set; }
            public string Name { get; init; }
            public string Identifier { get; set; }
        }
        private async Task ItemUpdated(MudItemDropInfo<DropItem> dropItem)
        {
            dropItem.Item.Identifier = dropItem.DropzoneIdentifier;
         
           Model.PurchaseOrder.MWOItem = dropItem.Item.MWOItem;
         
            var result = await ToolDialogService.ShowAddDataToPurchaseOrderDialog(Model.PurchaseOrder);
            if (!result.Cancelled)
            {
                var retorno = result.Data as EditPurchaseOrder;
                Model.MWOItems.Add(retorno.MWOItem);
               
            }


        }
        List<DropItem> _items = new();
        protected override void OnInitialized()
        {
            foreach (var row in Model.PurchaseOrder.MWO.MWOItems)
            {
                _items.Add(new DropItem()
                {
                    Name = $"{row.TagId} {row.Name}",
                    Identifier = "Drop Zone 2",
                    MWOItem = row
                });
            }
        }
    }
}