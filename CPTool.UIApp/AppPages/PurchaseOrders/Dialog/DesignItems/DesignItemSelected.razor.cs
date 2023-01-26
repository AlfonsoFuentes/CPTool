using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace CPTool.UIApp.AppPages.PurchaseOrders.Dialog.DesignItems
{
    public partial class DesignItemSelected
    {
        [CascadingParameter]
        public PurchaseOrderDialog Dialog { get; set; }
        public PurchaseOrderDialogData DialogData => Dialog.DialogData;

        public async Task UpdateTable()
        {
            await table.UpdateTable();
        }
        public async Task SaveRow(CommandPurchaseOrderItem order)
        {
            await table.SaveRow(order);
        }
    }
}
