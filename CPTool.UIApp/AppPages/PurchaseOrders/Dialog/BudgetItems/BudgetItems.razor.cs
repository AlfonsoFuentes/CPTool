using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.PurchaseOrders.Dialog.BudgetItems
{
    public partial class BudgetItems
    {
        [CascadingParameter]
        public PurchaseOrderDialog Dialog { get; set; }
        public PurchaseOrderDialogData DialogData => Dialog.DialogData;
        async Task AddItem()
        {
            await Dialog.AddItemBudget();

            StateHasChanged();
        }
        public async Task UpdateTable()
        {
            await table.UpdateTable();
        }
    }
}
