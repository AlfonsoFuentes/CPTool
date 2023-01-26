using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.PurchaseOrders.Dialog.DesignItems
{
    public partial class DesignItems
    {
        [CascadingParameter]
        public PurchaseOrderDialog Dialog { get; set; }
        public PurchaseOrderDialogData DialogData => Dialog.DialogData;
        async Task AddItem()
        {
            await Dialog.AddItemDesign();

            StateHasChanged();
        }
        public async Task UpdateTable()
        {
            await table.UpdateTable();
        }
    }
}
