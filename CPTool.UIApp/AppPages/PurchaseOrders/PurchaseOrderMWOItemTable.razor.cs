using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.PurchaseOrders
{
    public partial class PurchaseOrderMWOItemTable
    {
        [CascadingParameter]
        public PurchaseOrderDialog Dialog { get; set; }
        public PurchaseOrderDialogData DialogData => Dialog.DialogData;
        async Task AddItem()
        {
            await Dialog.AddItem();

            StateHasChanged();
        }
    }
}
