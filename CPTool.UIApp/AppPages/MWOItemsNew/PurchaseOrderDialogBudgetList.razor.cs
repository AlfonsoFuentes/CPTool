using Autofac.Core;

using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.UIApp.AppPages.MWOs;
using CPTool.UIApp.AppPages.PurchaseOrders;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.MWOItemsNew
{
    public partial class PurchaseOrderDialogBudgetList
    {
        [CascadingParameter]
        protected MWOItemDialogNew DialogParent { get; set; }

        protected MWOItemDialogData DialogData => DialogParent.DialogData;

        Task<bool> ShowTableDialog(CommandPurchaseOrder model)
        {
            if (model.Id == 0)
            {
                NavigationManager.NavigateTo($"/PurchaseOrderDialogBudget/{DialogParent.Model.Id}");
            }
            else
            {
                NavigationManager.NavigateTo($"/PurchaseOrderDialogBudget/{DialogParent.Model.Id}/{model.Id}");
            }


            return Task.FromResult(true);

        }
    }
}
